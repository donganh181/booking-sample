using BookingSample.Data.Context;
using BookingSample.Data.Models;

namespace BookingSample.Data.Repositories.impl
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(BookingSampleContext dbContext) : base(dbContext)
        {
        }
    }
}