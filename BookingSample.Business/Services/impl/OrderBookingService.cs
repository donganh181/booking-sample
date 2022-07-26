using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingSample.Data.Repositories;
using BookingSample.Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BookingSample.Business.Services.impl
{
    public class OrderBookingService : IOrderBookingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OrderBookingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<OrderBookingViewModel>> GetListExist(OrderBookingSearchViewModel model)
        {
            var list = await _unitOfWork.OrderBookingRepository.Get(o =>
                    o.OnDate.Equals(DateTime.Parse(model.OnDate)) &&
                    o.OnTime.Equals(TimeSpan.Parse(model.OnTime)) && o.RouteId.Equals(model.RouteId))
                .ProjectTo<OrderBookingViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }
    }
}