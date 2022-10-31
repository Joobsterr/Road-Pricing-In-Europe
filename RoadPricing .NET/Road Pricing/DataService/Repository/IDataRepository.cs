using DataService.DTO;

namespace DataService
{
    public interface IDataRepository
    {
        void enterDataPoint(DataModel jsonMessage);
        List<DataModel> getAllDataPoints();
        List<DataModel> getDataPointsPerCar(int carId);
    }
}