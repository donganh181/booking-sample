using BookingSample.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSample.Data.Repositories.impl
{
    public class UnitOfWork : IUnitOfWork
    {
        public BookingSampleContext _context { get; set; }
        public IRouteRepository RouteRepository { get; }
        public ISeatRepository SeatRepository { get; }
        public IOrderBookingRepository OrderBookingRepository { get; }

        public UnitOfWork(BookingSampleContext context, IRouteRepository routeRepository, ISeatRepository seatRepository, IOrderBookingRepository orderBookingRepository)
        {
            _context = context;
            RouteRepository = routeRepository;
            SeatRepository = seatRepository;
            OrderBookingRepository = orderBookingRepository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}
