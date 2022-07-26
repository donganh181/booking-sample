using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSample.Data.Repositories
{
    public interface IUnitOfWork
    {
        IRouteRepository RouteRepository { get; }
        ISeatRepository SeatRepository { get; }
        IOrderBookingRepository OrderBookingRepository { get; }
        void Save();
        Task SaveAsync();
    }
}
