using Microsoft.AspNetCore.Mvc;
using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillingController : ControllerBase
    {
        public List<Bill> FilterBills(string Month, string Year)
        {
            return new List<Bill>();
        }
        public bool AddRouteToBill(Models.DTO.Route)
        {
            return true;
        }
    }
}