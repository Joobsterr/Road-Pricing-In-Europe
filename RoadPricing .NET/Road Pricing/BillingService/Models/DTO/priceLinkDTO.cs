namespace BillingService.Models.DTO
{
    public class priceLinkDTO
    {
        public string paymentLink { get; set; }
        public double price { get; set; }

        public priceLinkDTO(string paymentLink, double price)
        {
            this.paymentLink = paymentLink;
            this.price = price;
        }
    }
}
