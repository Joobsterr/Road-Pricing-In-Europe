using DataService.DTO;

namespace DataService
{
    public interface IDataProcessingService
    {
        void newDataInput(string dataInputString);
        List<DataModel> getAllDataPoints();
        List<DataModel> getDataPointsPerCar(int carId);
        List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate);
    }
}