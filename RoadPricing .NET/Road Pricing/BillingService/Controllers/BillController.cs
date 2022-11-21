using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Services;

namespace BillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;

        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet("getUserBills")]
        public async Task<IActionResult> GetUserBills(int userId)
        {
            List<Bill> userBills = _billService.GetUserBills(userId);

            return Ok(userBills);
        }

        [HttpPost("addTripToBill")]
        public async Task<IActionResult> AddTripToBill(int userId, List<DataModel> datapoints)
        {
            bool result = _billService.AddTripToBill(userId, datapoints);

            if (result) return Ok("Data succesfully added"); else return BadRequest("Something went wrong, try again...");
        }


        [HttpPost("generatePriceForTrip")]
        public async Task<IActionResult> GeneratePriceForTrip(List<DataModel> datapoints)
        {
            double resultPrice = _billService.GeneratePriceForTrip(datapoints);

            return Ok(resultPrice);
        }

    }
}