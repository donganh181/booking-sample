using System;

namespace BookingSample.Data.ViewModel
{
    public class OrderBookingViewModel
    {
        public Guid Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? RouteId { get; set; }
        public TimeSpan? OnTime { get; set; }
        public DateTime? OnDate { get; set; }
    }
}