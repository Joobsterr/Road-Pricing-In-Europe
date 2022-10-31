namespace DataService.DTO
{
    public class DataModel
    {
        public Guid id { get; set; }
        public int carId { get; set; }
        public Tuple<double, double> lat_long { get; set; }
        public DateTime dateTimeStamp { get; set; }

        public DataModel(int carId, Tuple<double, double> lat_long, DateTime dateTimeStamp)
        {
            this.carId = carId;
            this.lat_long = lat_long;
            this.dateTimeStamp = dateTimeStamp;
        }

        public DataModel(Guid id, int carId, Tuple<double, double> lat_long, DateTime dateTimeStamp)
        {
            this.id = id;
            this.carId = carId;
            this.lat_long = lat_long;
            this.dateTimeStamp = dateTimeStamp;
        }
    }
}
