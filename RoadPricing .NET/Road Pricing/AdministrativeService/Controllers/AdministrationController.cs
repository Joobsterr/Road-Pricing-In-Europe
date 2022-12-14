using Microsoft.AspNetCore.Mvc;
using AdministrativeService.Models;
using AdministrativeService.Service;

namespace AdministrativeService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdministrationController : ControllerBase
    {
        private readonly IAdministrationService _administrativeService;

        public AdministrationController(IAdministrationService administrationService)
        {
            _administrativeService = administrationService;
        }
        [HttpGet("FilterPrices")]
        public List<AdministrationPrices> FilterAdministrationPrices(string fuelType, string carType, string roadType, DateOnly timeFrame)
        {
            return new List<AdministrationPrices>();
        }

        [HttpPost("message")]
        public void message()
        {
            Console.WriteLine("Oke");
        }

        [HttpPost("CreateNewPrice")]
        public async Task<ActionResult> CreatePrice(AdministrationPrices administrationPrices)
        {
            return  await _administrativeService.CreateNewPrice(administrationPrices);
        }
        [HttpGet("getAllPrices")]
        public async Task<ActionResult<List<AdministrationPrices>>>GetPrices()
        {
            return await _administrativeService.GetAllPrices();
        }
        [HttpPut]
        public async Task<ActionResult> UpdatePrice(int id, [FromBody]AdministrationPrices administrationPrices)
        {
            return null;
        }
    }
}