namespace CarService.Models
{
    public class Car
    {
        public string Licenseplate { get; set; }
        public int OwnerId { get; set; }
        public string CarType { get; set; }
        public string CarBrand { get; set; }
        public string Color { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public Double TotalKm { get; set; }

        public Car(string licenseplate, int ownerId, string carType, string carBrand, string color, DateOnly purchaseDate, double totalKm)
        {
            Licenseplate = licenseplate;
            OwnerId = ownerId;
            CarType = carType;
            CarBrand = carBrand;
            Color = color;
            PurchaseDate = purchaseDate;
            TotalKm = totalKm;
        }

        public Car()
        {
        }
    }
}
