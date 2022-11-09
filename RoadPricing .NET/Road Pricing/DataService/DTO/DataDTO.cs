namespace DataService.DTO
{
    public class DataDTO
    {
        public int carId { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string timeStamp { get; set; }
        public int routeId { get; set; }
        public double laneMaxSpeedMs { get; set; }

        public DataDTO(int carId, double latitude, double longitude, string timeStamp, int routeId, double laneMaxSpeedMs)
        {
            this.carId = carId;
            this.latitude = latitude;
            this.longitude = longitude;
            this.timeStamp = timeStamp;
            this.routeId = routeId;
            this.laneMaxSpeedMs = laneMaxSpeedMs;
        }
    }
}
