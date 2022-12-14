namespace BillingService.Models.EnglishGroupModels
{
    public class ResponseEn
    {
        public int carId { get; set; }
        public double totalPrice { get; set; }
        public double totalDistance { get; set; }
        public string calculation { get; set; }
        public string paymentUrl { get; set; }

        public ResponseEn(int carId, double totalPrice, double totalDistance, string calculation, string paymentUrl)
        {
            this.carId = carId;
            this.totalPrice = totalPrice;
            this.totalDistance = totalDistance;
            this.calculation = calculation;
            this.paymentUrl = paymentUrl;
        }
    }
}
