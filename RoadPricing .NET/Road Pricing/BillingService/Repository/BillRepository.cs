using BillingService.Models;
using BillingService.Models.DTO;

namespace BillingService.Repository
{
    public class BillRepository : IBillRepository
    {
        // Connect to DB here as well


        public bool AddTripToBill(int userId, Trip trip)
        {
            // Add object to database in refference to the correct bill
            return true;
        }

        public List<Bill> GetUserBills(int userId)
        {
            // Get the bills for the given user
            return new List<Bill>();
        }
    }
}
