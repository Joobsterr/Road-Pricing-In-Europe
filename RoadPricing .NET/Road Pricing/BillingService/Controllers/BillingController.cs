using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.RabbitMQ;

namespace BillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillingController : ControllerBase
    {
        [HttpGet("getSpecificBills")]
        public List<Bill> FilterBills(string Month, string Year)
        {
            return new List<Bill>();
        }

        [HttpPost("addRouteToBill")]
        public bool AddRouteToBill(Models.DTO.Route route)
        {
            return true;
        }
    }
}