using DataService.DTO;

namespace DataService
{
    public interface IDataRepository
    {
        void enterDataPoint(List<DataModel> dataModels);
        List<DataModel> getAllDataPoints();
        List<DataModel> getDataPointsForUser(int userId);
        List<DataModel> getDataPointsPerCarPerRoute(int carId, int routeId);
        List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate);
    }
}