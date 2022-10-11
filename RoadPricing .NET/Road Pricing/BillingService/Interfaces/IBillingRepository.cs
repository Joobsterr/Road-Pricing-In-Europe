using BillingService.Models;

namespace BillingService.Interfaces
{
    public interface IBillingRepository
    {
        List<Bill> FilterBills(string Month, string Year);
    }
}