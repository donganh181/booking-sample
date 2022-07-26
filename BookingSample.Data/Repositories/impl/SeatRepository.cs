using BookingSample.Data.Context;
using BookingSample.Data.Models;

namespace BookingSample.Data.Repositories.impl
{
    public class SeatRepository : BaseRepository<Seat>, ISeatRepository
    {
        public SeatRepository(BookingSampleContext dbContext) : base(dbContext)
        {
        }
    }
}