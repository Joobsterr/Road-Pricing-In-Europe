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
            List<DataDTO> dataInputDto = JsonSerializer.Deserialize<List<DataDTO>>(dataInputString);
            List<DataModel> dataModels = new List<DataModel>();

            foreach (DataDTO dataDTO in dataInputDto)
            {
                dataModels.Add(new DataModel(dataDTO.carId, new Tuple<double, double>(dataDTO.latitude, dataDTO.longitude), DateTime.Parse(dataDTO.timeStamp), dataDTO.routeId, dataDTO.laneMaxSpeedMs, dataDTO.vehicleTypeName, "Petrol", 1));
            }

            _repository.enterDataPoint(dataModels);
        }

        public List<DataModel> getAllDataPoints()
        {
            return _repository.getAllDataPoints();
        }

        public List<DataModel> getDataPointsPerCarPerRoute(int carId, int routeId)
        {
            return _repository.getDataPointsPerCarPerRoute(carId, routeId);
        }

        public List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate)
        {
            return _repository.getDataPointsPerCarWithTimeframe(carId, startDate, endDate);
        }

        public List<DataModel> getDataPointsForUser(int userId)
        {
            return _repository.getDataPointsForUser(userId);
        }
    }
}
