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

        [HttpGet("getDataPointsPerCarWithTimeframe")]
        public async Task<IActionResult> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate)
        {
            List<DataModel> datapoints = _dataService.getDataPointsPerCarWithTimeframe(carId, startDate, endDate);
            return Ok(datapoints);
        }
    }
}