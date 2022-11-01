using DataService.DTO;
using System.Text.Json;

namespace DataService
{
    public class DataProcessingService : IDataProcessingService
    {
        private readonly IDataRepository _repository;

        public DataProcessingService(IDataRepository repository)
        {
            _repository = repository;
        }

        public void newDataInput(string dataInputString)
        {
            // Doing this so that the date is valid, otherwise the date would be 1-1-0001 00:00:00
            DataDTO? dataInputDto = JsonSerializer.Deserialize<DataDTO>(dataInputString);

            Tuple<double, double> lat_long = new Tuple<double, double>(dataInputDto.latitude, dataInputDto.longitude);

            DataModel dataInputModel = new DataModel(dataInputDto.carId, lat_long, DateTime.Parse(dataInputDto.timeStamp));
            _repository.enterDataPoint(dataInputModel);
        }

        public List<DataModel> getAllDataPoints()
        {
            return _repository.getAllDataPoints();
        }

        public List<DataModel> getDataPointsPerCar(int carId)
        {
            return _repository.getDataPointsPerCar(carId);
        }

        public List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate)
        {
            return _repository.getDataPointsPerCarWithTimeframe(carId, startDate, endDate);
        }
    }
}
