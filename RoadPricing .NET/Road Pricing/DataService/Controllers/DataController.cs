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

        [HttpGet("getDataPointsPerCarPerRoute/{carId}/{routeId}")]
        public async Task<IActionResult> getDataPointsPerCarPerRoute(int carId, int routeId)
        {
            List<DataModel> datapoints = _dataService.getDataPointsPerCarPerRoute(carId, routeId);
            return Ok(datapoints);
        }

        [HttpGet("getDataPointsPerCarWithTimeframe")]
        public async Task<IActionResult> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate)
        {
            List<DataModel> datapoints = _dataService.getDataPointsPerCarWithTimeframe(carId, startDate, endDate);
            return Ok(datapoints);
        }
        [HttpGet("getdataPointsForUser/{userId}")]
        public async Task<IActionResult> getDataPointsForUser(int userId)
        {
            List<DataModel> datapoints = _dataService.getDataPointsForUser(userId);
            return Ok(datapoints);
        }
    }
}