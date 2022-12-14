namespace BillingService.Models.EnglishGroupModels
{
    public class TripEn
    {
        public int carId { get; set; }
        public List<CoordinateEn> route { get; set; }
        public string carType { get; set; }

        public TripEn(int carId, List<CoordinateEn> route, string carType)
        {
            this.carId = carId;
            this.route = route;
            this.carType = carType;
        }
    }
}
