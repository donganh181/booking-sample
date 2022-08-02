using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSample.Data.ViewModel;

namespace BookingSample.Business.Services
{
    public interface IOrderBookingService
    {
        public Task<List<OrderBookingViewModel>> GetListExist(OrderBookingSearchViewModel model);
        public Task<List<OrderBookingViewModel>> Create(OrderBookingCreateViewModel model);
    }
}