using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSample.Data.ViewModel;

namespace BookingSample.Business.Services
{
    public interface ISeatService
    {
        public Task<List<SeatViewModel>> Get(OrderBookingSearchViewModel model);
        public Task Create();
    }
}