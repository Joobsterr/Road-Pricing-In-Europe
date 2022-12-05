using BillingService.Models;

namespace BillingService.Services
{
    public interface IBillService
    {
        bool AddTripToBill(int userId, List<DataModel> datapoints);
        double GeneratePriceForTrip(List<DataModel> datapoints);
        List<Bill> GetUserBills(int userId);
        Bill GetUserSpecificBill(int userId, int month, int year);
        Task<string> getPaymentLink(int userId, int billId);
    }
}