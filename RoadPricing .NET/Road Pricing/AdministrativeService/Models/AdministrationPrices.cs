namespace AdministrativeService.Models
{
    public class AdministrationPrices
    {
        public int Id { get; set; }
        public string FuelType { get; set; }
        public string CarType { get; set; }
        public string RoadType { get; set; }
        public DateOnly Timeframe { get; set; }
        public Double Price { get; set; }
        public AdministrationPrices(string fuelType, string carType, string roadType, DateOnly timeframe, double price)
        {
            FuelType = fuelType;
            CarType = carType;
            RoadType = roadType;
            Timeframe = timeframe;
            Price = price;
        }

        public AdministrationPrices()
        {
        }
    }
}
