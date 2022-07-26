using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookingSample.Business.Services;
using BookingSample.Data.Responses;
using BookingSample.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookingSample.Controllers
{
    [Route("api/v{version:apiVersion}/routes")]
    [ApiController]
    [ApiVersion("1")]
    public class RouteController : Controller
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }
        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAll()
        {
            var request = Request;

            var result = await _routeService.GetAll();
            return Ok(new SuccessResponse<List<RouteViewModel>>((int)HttpStatusCode.OK,
                "Search success.", result));
        }
    }
}