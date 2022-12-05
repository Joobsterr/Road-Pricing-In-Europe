using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Services;
using BillingService.Models.DTO;

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

        [HttpGet("getUserBills/{userId}")]
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
            priceLinkDTO priceLinkDTO = await _billService.GeneratePriceForTrip(datapoints);
            return Ok(priceLinkDTO);
        }

        [HttpGet("getUserBills/{userId}/{month}/{year}")]
        public async Task<IActionResult> GetUserSpecificBills(int userId, int month, int year)
        {
            Bill specificBill = _billService.GetUserSpecificBill(userId, month, year);

            return Ok(specificBill);
        }
        [HttpGet("getPaymentLink/{userId}/{billId}")]
        public async Task<IActionResult> getPaymentLink(int userId, int billId)
        {
            string paymentLink = await _billService.getPaymentLink(userId, billId);
            return Ok(paymentLink);
        }
    }
}