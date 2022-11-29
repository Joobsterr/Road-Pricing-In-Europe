using BillingService.Models;

namespace BillingService.Repository
{
    public interface IBillRepository
    {
        bool AddTripToBill(int userId, int month, int year, Trip trip);
        List<Bill> GetUserBills(int userId);
        Bill GetUserSpecificBills(int userId, int month, int year);
    }
}