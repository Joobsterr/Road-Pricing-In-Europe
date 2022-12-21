using DataService.DTO;

namespace DataService
{
    public interface IDataProcessingService
    {
        void newDataInput(string dataInputString);
        List<DataModel> getAllDataPoints();
        List<DataModel> getDataPointsPerCarPerRoute(int carId, int routeId);
        List<DataModel> getDataPointsPerCarWithTimeframe(int carId, DateTime startDate, DateTime endDate);
        List<DataModel> getDataPointsForUser(int userId);
    }
}