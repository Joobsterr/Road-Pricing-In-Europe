using BillingService.Models.DTO;

namespace BillingService.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Trip> Trips { get; set; }
        public double TotalPrice { get; set; }
        public DateOnly MonthYear { get; set; }

        public Bill(int id, int userId, List<Trip> trips, double totalPrice, DateOnly monthYear)
        {
            Id = id;
            UserId = userId;
            Trips = trips;
            TotalPrice = totalPrice;
            MonthYear = monthYear;
        }
    }
}
