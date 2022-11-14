namespace BillingService.Models.DTO
{
    public class DataModel
    {
        public int carId { get; set; }
        public string carType { get; set; }
        public string fuelType { get; set; }
        public Tuple<double, double> lat_long { get; set; }
        public DateTime dateTimeStamp { get; set; }
        public double maxLaneSpeed { get; set; }
        public int routeId { get; set; }

        public DataModel(int carId, Tuple<double, double> lat_long, DateTime dateTimeStamp, int routeId)
        {
            this.carId = carId;
            this.lat_long = lat_long;
            this.dateTimeStamp = dateTimeStamp;
            this.routeId = routeId;
        }
    }
}
