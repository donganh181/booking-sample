using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookingSample.Data.Repositories;
using BookingSample.Data.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace BookingSample.Business.Services.impl
{
    public class RouteService : IRouteService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public RouteService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<RouteViewModel>> GetAll()
        {
            var list = await _unitOfWork.RouteRepository.Get().OrderBy(r=>r.FromPlace).ProjectTo<RouteViewModel>(_mapper.ConfigurationProvider).ToListAsync();
            return list;
        }
    }
}