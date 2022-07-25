using BookingSample.Data.Context;
using BookingSample.Data.Repositories;
using BookingSample.Data.Repositories.impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingSample.Business.DI
{
    public static class ServicesDI
    {
        public static void ConfigServicesDI(this IServiceCollection services)
        {
            services.AddScoped<DbContext, BookingSampleContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
    
}
