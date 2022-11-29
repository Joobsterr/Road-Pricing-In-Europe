namespace BillingService.Models.DTO
{
    public class PaymentBillDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public List<Trip> trips { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public string paymentLink { get; set; }

        public PaymentBillDTO(int id, int userId, List<Trip> trips, int month, int year, string paymentLink)
        {
            this.id = id;
            this.userId = userId;
            this.trips = trips;
            this.month = month;
            this.year = year;
            this.paymentLink = paymentLink;
        }
    }
    }
}
