using AutoMapper;
using BookingSample.Data.Models;
using BookingSample.Data.ViewModel;

namespace BookingSample.Data.AutoMapper
{
    public static class SeatModule
    {
        public static void ConfigSeatModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Seat, SeatViewModel>();
            mc.CreateMap<SeatViewModel, Seat>();
        }
    }
}