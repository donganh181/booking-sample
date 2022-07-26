using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookingSample.Business.Services;
using BookingSample.Data.Responses;
using BookingSample.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookingSample.Controllers
{
    [Route("api/v{version:apiVersion}/seats")]
    [ApiController]
    [ApiVersion("1")]
    public class SeatController : Controller
    {
        private readonly ISeatService _seatService;

        public SeatController(ISeatService seatService)
        {
            _seatService = seatService;
        }


        [HttpGet]
        [MapToApiVersion("1")]
        public async Task<IActionResult> GetAll([FromQuery]OrderBookingSearchViewModel model)
        {
            var result = await _seatService.Get(model);
            return Ok(new SuccessResponse<List<SeatViewModel>>((int)HttpStatusCode.OK,"get success", result));
        }
    }
}