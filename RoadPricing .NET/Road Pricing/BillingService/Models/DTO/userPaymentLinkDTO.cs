namespace BillingService.Models.DTO
{
    public class userPaymentLinkDTO
    {
        public string paymentLink { get; set; }
        public double price { get; set; }

        public userPaymentLinkDTO(string paymentLink, double price)
        {
            this.paymentLink = paymentLink;
            this.price = price;
        }
    }
}
