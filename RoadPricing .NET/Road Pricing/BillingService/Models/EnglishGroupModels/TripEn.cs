namespace BillingService.Models.EnglishGroupModels
{
    public class TripEn
    {
        public int carId { get; set; }
        public RouteEn route { get; set; }

        public TripEn(int carId, RouteEn route)
        {
            this.carId = carId;
            this.route = route;
        }
    }
}
