using System;
using System.Collections.Generic;

namespace BookingSample.Data.ViewModel
{
    public class OrderBookingCreateViewModel
    {
        public List<Guid> SeatIds { get; set; }
        public Guid RouteId { get; set; }
        public string StringOnTime { get; set; }
        public DateTime OnDate { get; set; }
        public Guid KioskId { get; set; }
        public Guid ServiceApplicationId { get; set; }
    }
}