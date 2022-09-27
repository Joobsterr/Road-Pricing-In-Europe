using Microsoft.AspNetCore.Mvc;
using AdministrativeService.Models;

namespace AdministrativeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : ControllerBase
    {
        public List<AdministrationPrices> FilterAdministrationPrices(string fuelType, string carType, string roadType, DateOnly timeFrame)
        {
            return new List<AdministrationPrices>();
        }
    }
}