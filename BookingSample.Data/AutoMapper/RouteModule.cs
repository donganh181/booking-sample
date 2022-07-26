using AutoMapper;
using BookingSample.Data.Models;
using BookingSample.Data.ViewModel;

namespace BookingSample.Data.AutoMapper
{
    public static class RouteModule
    {
        public static void ConfigRouteModule(this IMapperConfigurationExpression mc)
        {
            mc.CreateMap<Route, RouteViewModel>();
            mc.CreateMap<RouteViewModel, Route>();
        }
    }
}