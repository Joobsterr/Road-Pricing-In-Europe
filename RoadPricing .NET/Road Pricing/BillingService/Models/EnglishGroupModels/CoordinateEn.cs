namespace BillingService.Models
{
    public class CoordinateEn
    {
        public DateTime dateTimeStamp { get; set; }
        public double lng { get; set; }
        public double lat { get; set; }
        public string roadType { get; set; }

        public CoordinateEn(DateTime dateTimeStamp, double lng, double lat, string roadType)
        {
            this.dateTimeStamp = dateTimeStamp;
            this.lng = lng;
            this.lat = lat;
            this.roadType = roadType;
        }
    }
}
