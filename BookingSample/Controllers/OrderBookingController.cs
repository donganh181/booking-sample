using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using BookingSample.Business.Services;
using BookingSample.Data.Responses;
using BookingSample.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BookingSample.Controllers
{
    [Route("api/v{version:apiVersion}/orderBookings")]
    [ApiController]
    [ApiVersion("1")]
    public class OrderBookingController : Controller
    {
        private readonly IOrderBookingService _orderBookingService;

        public OrderBookingController(IOrderBookingService orderBookingService)
        {
            _orderBookingService = orderBookingService;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Create([FromBody] OrderBookingCreateViewModel model)
        {
            var request = Request;

            var result = await _orderBookingService.Create(model);
            return Ok(new SuccessResponse<List<OrderBookingViewModel>>((int)HttpStatusCode.OK,
                "Create success.", result));
        }
    }
}