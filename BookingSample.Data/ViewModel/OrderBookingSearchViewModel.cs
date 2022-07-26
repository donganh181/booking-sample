using System;

namespace BookingSample.Data.ViewModel
{
    public class OrderBookingSearchViewModel
    {
        public Guid? RouteId { get; set; }
        public string OnTime { get; set; }
        public string OnDate { get; set; }
    }
}