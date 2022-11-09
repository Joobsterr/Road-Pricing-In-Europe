using BillingService.Models.DTO;

namespace BillingService.Repository
{
    public class BillRepository : IBillRepository
    {
        // Connect to DB here as well

        public bool AddTripToBill(Trip trip, int userBsn)
        {
            // Add object to database in refference to the correct bill
            return true;
        }
    }
}
