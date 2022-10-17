using Microsoft.AspNetCore.Mvc;
using DataService.DTO;

namespace DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        [HttpGet("transformInputData")]
        public async Task<IActionResult> TransformInputData(DataInputModel dataInputModel)
        {
            return Ok();
        }

        [HttpGet("getTransformedDataTimeFrame")]
        public async Task<IActionResult> GetTransformedDataTimeFrame(DateTime TimeFrame)
        {
            return Ok();
        }

        [HttpGet("getTransformedDataCar")]
        public async Task<IActionResult> GetTransformedDataCar(int CarId)
        {
            return Ok();
        }
    }
}