using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Services
{
    public interface IBillService
    {
        bool AddTripToBill(int userId, List<DataModel> datapoints);
        double GeneratePriceForTrip(List<DataModel> datapoints);
        List<Bill> GetUserBills(int userId);
    }
}