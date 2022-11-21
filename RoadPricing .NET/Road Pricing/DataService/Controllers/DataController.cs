using Microsoft.AspNetCore.Mvc;
using DataService.DTO;

namespace DataService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        public DataOutputModel TransformInputData(DataInputModel)
        {
            // WIP
        }

        public List<DataOutputModel> GetTransformedDataTimeFrame(TimeFrame)
        {
            // WIP
        }

        public List<DataOutputModel> GetTransformedDataCar(CarId)
        {
            // WIP
        }
    }