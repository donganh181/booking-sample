using System;

namespace BookingSample.Data.Models
{
    public class OrderKiosk
    {
        public string OrderDetail { get; set; }
        public Guid KioskId { get; set; }
        public Guid ServiceApplicationId { get; set; }
    }
}