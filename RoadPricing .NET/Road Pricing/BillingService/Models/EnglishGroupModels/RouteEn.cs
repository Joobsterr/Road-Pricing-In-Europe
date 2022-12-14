namespace BillingService.Models.EnglishGroupModels
{
    public class RouteEn
    {
        public List<CoordinateEn> coordinates { get; set; }
        public string carType { get; set; }

        public RouteEn(List<CoordinateEn> coordinates, string carType)
        {
            this.coordinates = coordinates;
            this.carType = carType;
        }
    }
}
