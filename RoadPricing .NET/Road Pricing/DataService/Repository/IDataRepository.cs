using DataService.DTO;

namespace DataService
{
    public interface IDataRepository
    {
        void enterDataPoint(List<DataModel> dataModels);
        List<DataModel> getAllDataPoints();
        List<DataModel> getDataPointsPerCar(int carId);
        List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate);
    }
}