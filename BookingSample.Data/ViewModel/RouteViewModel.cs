using System;

namespace BookingSample.Data.ViewModel
{
    public class RouteViewModel
    {
        public Guid Id { get; set; }
        public string FromPlace { get; set; }
        public string ToPlace { get; set; }
        public double? Price { get; set; }
    }
}