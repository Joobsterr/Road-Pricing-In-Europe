using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Models.DTO;
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

        [HttpGet("getSpecificBills")]
        public List<Bill> FilterBills(string Month, string Year)
        {
            return new List<Bill>();
        }

        [HttpPost("addTripToBill")]
        public async Task<IActionResult> AddTripToBill(List<DataModel> datapoints, int userBsn)
        {
            bool result = _billService.AddTripToBill(datapoints, userBsn);

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