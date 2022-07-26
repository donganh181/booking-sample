using System;
using System.Collections.Generic;

#nullable disable

namespace BookingSample.Data.Models
{
    public partial class Seat
    {
        public Seat()
        {
            OrderBookings = new HashSet<OrderBooking>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrderBooking> OrderBookings { get; set; }
    }
}
