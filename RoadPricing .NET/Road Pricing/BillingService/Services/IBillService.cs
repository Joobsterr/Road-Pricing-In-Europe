using BillingService.Models.DTO;

namespace BillingService.Services
{
    public interface IBillService
    {
        bool AddTripToBill(List<DataModel> datapoints, int userBsn);
    }
}