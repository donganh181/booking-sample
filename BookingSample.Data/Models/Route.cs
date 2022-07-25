using System;
using System.Collections.Generic;

#nullable disable

namespace BookingSample.Data.Models
{
    public partial class Route
    {
        public Route()
        {
            OrderBookings = new HashSet<OrderBooking>();
        }

        public Guid Id { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public double? Price { get; set; }

        public virtual ICollection<OrderBooking> OrderBookings { get; set; }
    }
}
