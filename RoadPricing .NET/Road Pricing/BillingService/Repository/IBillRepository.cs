using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Repository
{
    public interface IBillRepository
    {
        bool AddTripToBill(int userId, Trip trip);
        List<Bill> GetUserBills(int userId);
    }
}