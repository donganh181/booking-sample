using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookingSample.Data.ViewModel;

namespace BookingSample.Business.Services
{
    public interface IRouteService
    {
        public Task<List<RouteViewModel>> GetAll();
        public Task<RouteViewModel> GetById(Guid routeId);
    }
}