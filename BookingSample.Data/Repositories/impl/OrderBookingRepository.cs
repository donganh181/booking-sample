using BookingSample.Data.Context;
using BookingSample.Data.Models;

namespace BookingSample.Data.Repositories.impl
{
    public class OrderBookingRepository : BaseRepository<OrderBooking>, IOrderBookingRepository
    {
        public OrderBookingRepository(BookingSampleContext dbContext) : base(dbContext)
        {
        }
    }
}