using BillingService.Models.DTO;

namespace BillingService.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public List<DTO.Route> Routes { get; set; }
        public Double TotalPrice { get; set; }
        public DateOnly MonthYear { get; set; }

        public Bill(int id, List<DTO.Route> routes, double totalPrice, DateOnly monthYear)
        {
            Id = id;
            Routes = routes;
            TotalPrice = totalPrice;
            MonthYear = monthYear;
        }

        public Bill()
        {
        }
    }
}
