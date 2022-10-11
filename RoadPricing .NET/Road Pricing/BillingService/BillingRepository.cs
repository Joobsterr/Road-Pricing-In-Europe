using BillingService.Interfaces;
using BillingService.Models;

namespace BillingService
{
    public class BillingRepository : IBillingRepository
    {
        public List<Bill> FilterBills(string Month, string Year)
        {
            return new List<Bill>();
        }
    }
}
