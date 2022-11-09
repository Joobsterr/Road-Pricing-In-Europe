using BillingService.Models.DTO;

namespace BillingService.Repository
{
    public interface IBillRepository
    {
        bool AddTripToBill(Trip trip, int userBsn);
    }
}