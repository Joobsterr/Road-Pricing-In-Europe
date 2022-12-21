namespace DataService.DTO
{
    public class DataModel
    { 
        public int carId { get; set; }
        public Tuple<double, double> lat_long { get; set; }
        public DateTime dateTimeStamp { get; set; }
        public int routeId { get; set; }
        public double laneMaxSpeedMs { get; set; }
        public string vehicleTypeName { get; set; }
        public string emissionType { get; set; }
        public int userId { get; set; }

        public DataModel(int carId, Tuple<double, double> lat_long, DateTime dateTimeStamp, int routeId, double laneMaxSpeedMs, string vehicleTypeName, string emissionType, int userId)
        {
            this.carId = carId;
            this.lat_long = lat_long;
            this.dateTimeStamp = dateTimeStamp;
            this.routeId = routeId;
            this.laneMaxSpeedMs = laneMaxSpeedMs;
            this.vehicleTypeName = vehicleTypeName;
            this.emissionType = emissionType;
            this.userId = userId;
        }
    }
}
