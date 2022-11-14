using Microsoft.AspNetCore.Mvc;
using DataService.DTO;

namespace DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        public DataOutputModel TransformInputData(DataInputModel data)
        {
            // WIP
            return null;
        }

        public List<DataOutputModel> GetTransformedDataTimeFrame(string TimeFrame)
        {
            // WIP
            return null;
        }

        public List<DataOutputModel> GetTransformedDataCar(int CarId)
        {
            // WIP
            return null;
        }
    }
}