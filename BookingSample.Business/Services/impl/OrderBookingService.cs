﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingSample.Business.Hubs;
using BookingSample.Data.Models;
using BookingSample.Data.Repositories;
using BookingSample.Data.Responses;
using BookingSample.Data.ViewModel;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BookingSample.Business.Services.impl
{
    public class OrderBookingService : IOrderBookingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IRouteService _routeService;
        private readonly IHubContext<SystemEventHub> _eventHub;
        private readonly HttpClient client = new HttpClient();
        private string Host;

        public OrderBookingService(IMapper mapper, IUnitOfWork unitOfWork, IConfiguration configuration, IRouteService routeService,IHubContext<SystemEventHub> eventHub)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _routeService = routeService;
            _eventHub = eventHub;
            Host = _configuration.GetSection("KIOSK")["HOST"];
        }

        public async Task<List<OrderBookingViewModel>> GetListExist(OrderBookingSearchViewModel model)
        {
            var list = await _unitOfWork.OrderBookingRepository.Get(o =>
                    o.OnDate.Equals(DateTime.Parse(model.OnDate)) &&
                    o.OnTime.Equals(TimeSpan.Parse(model.OnTime)) && o.RouteId.Equals(model.RouteId))
                .ProjectTo<OrderBookingViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }

        public async Task<List<OrderBookingViewModel>> Create(OrderBookingCreateViewModel model)
        {
            var result = new List<OrderBookingViewModel>();
            var listOrder = new ListOrder();
            var route = await _routeService.GetById(model.RouteId); 
            try
            {
                foreach (var seatId in model.SeatIds)
                {
                    var order = _mapper.Map<OrderBooking>(model);
                    order.SeatId = seatId;
                    order.OnTime = TimeSpan.Parse(model.StringOnTime);
                    await _unitOfWork.OrderBookingRepository.InsertAsync(order);
                    
                    await _unitOfWork.SaveAsync();
                    result.Add(_mapper.Map<OrderBookingViewModel>(order));
                    listOrder.items.Add(new OrderDetail(){Id = order.Id, Price = (double) route.Price});
                }
                

                var obj = new OrderKiosk()
                {
                    OrderDetail = JsonConvert.SerializeObject(listOrder),
                    KioskId = model.KioskId,
                    ServiceApplicationId = model.ServiceApplicationId
                };
                var json = JsonConvert.SerializeObject(obj);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var url = Host;
                await client.PostAsync(url, data);
                Console.WriteLine(model.KioskId);
                await _eventHub.Clients.Group(model.KioskId.ToString().ToUpper())
                    .SendAsync(SystemEventHub.WEB_BOOKING_CHANNEL,
                        SystemEventHub.SYSTEM_BOT, true);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ErrorResponse((int)HttpStatusCode.BadRequest,e.Message);
            }
        }
    }
}