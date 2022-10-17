using Microsoft.AspNetCore.Mvc;
using AdministrativeService.Models;
using AdministrativeService.Service;

namespace AdministrativeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdministartionService _administrativeService;

        public AdministrationController(IAdministartionService administartionService)
        {
            _administrativeService = administartionService;
        }
        public List<AdministrationPrices> FilterAdministrationPrices(string fuelType, string carType, string roadType, DateOnly timeFrame)
        {
            return new List<AdministrationPrices>();
        }

        [HttpPost("CreateNewPrice")]
        public async Task<ActionResult> CreatePrice([FromBody] AdministrationPrices administrationPrices)
        {
            return await _administrativeService.CreateNewPrice(administrationPrices);
        }
        [HttpGet]
        public async Task<ActionResult<List<AdministrationPrices>>>GetPrices()
        {
            return await _administrativeService.GetAllPrices();
        }

    }
}