using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingSample.Data.Models;
using BookingSample.Data.Repositories;
using BookingSample.Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BookingSample.Business.Services.impl
{
    public class SeatService : ISeatService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderBookingService _orderBookingService;

        public SeatService(IMapper mapper, IUnitOfWork unitOfWork, IOrderBookingService orderBookingService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _orderBookingService = orderBookingService;
        }

        public async Task<List<SeatViewModel>> Get(OrderBookingSearchViewModel model)
        {
            try
            {
                var listAll = await _unitOfWork.SeatRepository.Get().OrderBy(x => x.Name)
                    .ProjectTo<SeatViewModel>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                var listExist = await _orderBookingService.GetListExist(model);
                if (listExist.Count != 0)
                    foreach (var x in listExist)
                    {
                        var index = listAll.FindIndex(s => s.Id.Equals(x.SeatId));
                        if (listAll.FindIndex(s => s.Id.Equals(x.SeatId)) != -1)
                        {
                            listAll[index].Status = "unavailable";
                        }
                    }

                return listAll;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Create()
        {
            try
            {
                var list = new List<string>() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L"};
                foreach (string num in list)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        await _unitOfWork.SeatRepository.InsertAsync(new Seat() {Name = num + i});
                    }
                }

                await _unitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}