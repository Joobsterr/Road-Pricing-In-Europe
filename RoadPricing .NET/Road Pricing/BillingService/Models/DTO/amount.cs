namespace BillingService.Models.DTO
{
    public class amount
    {
        public string value { get; set; }
        public string currency { get; set; }

        public amount(string value, string currency)
        {
            this.value = value;
            this.currency = currency;
        }
    }
}
