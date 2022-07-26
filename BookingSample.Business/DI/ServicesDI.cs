using BookingSample.Data.Context;
using BookingSample.Data.Repositories;
using BookingSample.Data.Repositories.impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using BookingSample.Business.Services;
using BookingSample.Business.Services.impl;

namespace BookingSample.Business.DI
{
    public static class ServicesDI
    {
        public static void ConfigServicesDI(this IServiceCollection services)
        {
            services.AddScoped<DbContext, BookingSampleContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRouteRepository, RouteRepository>();
            services.AddScoped<IRouteService, RouteService>();

            services.AddScoped<ISeatRepository, SeatRepository>();
            services.AddScoped<ISeatService, SeatService>();

            services.AddScoped<IOrderBookingRepository, OrderBookingRepository>();
            services.AddScoped<IOrderBookingService, OrderBookingService>();
        }
    }
    
}
