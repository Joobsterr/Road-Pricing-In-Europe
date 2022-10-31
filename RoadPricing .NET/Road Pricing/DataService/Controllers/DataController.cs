using Microsoft.AspNetCore.Mvc;
using DataService.DTO;

namespace DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataProcessingService _dataService;

        public DataController(IDataProcessingService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("getAllDataPoints")]
        public async Task<IActionResult> GetAllDataPoints()
        {
            List<DataModel> datapoints = _dataService.getAllDataPoints();
            return Ok(datapoints);
        }

        [HttpGet("getDataPointsPerCar")]
        public async Task<IActionResult> getDataPointsPerCar(int carId)
        {
            List<DataModel> datapoints = _dataService.getDataPointsPerCar(carId);
            return Ok(datapoints);
        }

        [HttpGet("getTransformedDataCar")]
        public async Task<IActionResult> GetTransformedDataCar(int CarId)
        {
            return Ok();
        }
    }
}