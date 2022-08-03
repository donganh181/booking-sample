using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BookingSample.Business.Services;
using BookingSample.Data.Responses;
using BookingSample.Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookingSample.Controllers
{
    [Route("api/v{version:apiVersion}/orderBookings")]
    [ApiController]
    [ApiVersion("1")]
    public class OrderBookingController : Controller
    {
        private readonly IOrderBookingService _orderBookingService;
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;

        public OrderBookingController(IOrderBookingService orderBookingService, IConfiguration configuration)
        {
            _orderBookingService = orderBookingService;
            _configuration = configuration;
        }

        [HttpPost]
        [MapToApiVersion("1")]
        public async Task<IActionResult> Create([FromBody] OrderBookingCreateViewModel model)
        {
            var request = Request;

            var result = await _orderBookingService.Create(model);
            return Ok(new SuccessResponse<List<OrderBookingViewModel>>((int) HttpStatusCode.OK,
                "Create success.", result));
        }

        [HttpGet]
        [MapToApiVersion("1")]
        public async Task Test()
        {
            await client.GetAsync(_configuration.GetSection("KIOSK")["HOST"] + "/test");
        }
    }
}