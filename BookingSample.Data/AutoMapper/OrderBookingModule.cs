using AutoMapper;
using BookingSample.Data.Models;
using BookingSample.Data.ViewModel;

namespace BookingSample.Data.AutoMapper
{
    public static class OrderBookingModule
    {
        public static void ConfigOrderBookingModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<OrderBooking, OrderBookingViewModel>();
            mc.CreateMap<OrderBookingViewModel, OrderBooking>();
        }
    }
}