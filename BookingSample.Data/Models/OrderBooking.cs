using System;
using System.Collections.Generic;

#nullable disable

namespace BookingSample.Data.Models
{
    public partial class OrderBooking
    {
        public Guid Id { get; set; }
        public Guid? SeatId { get; set; }
        public Guid? RouteId { get; set; }
        public TimeSpan? OnTime { get; set; }
        public DateTime? OnDate { get; set; }

        public virtual Route Route { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
