namespace CarService.Models
{
    public class Car
    {
        public int LicenseplateId { get; set; }
        public int OwnerId { get; set; }
        public string Licenseplate { get; set; }
        public string CarType { get; set; }
        public string CarBrand { get; set; }
        public string Color { get; set; }
        public DateOnly PurchaseDate { get; set; }
        public Double TotalKm { get; set; }

        public Car(int licenseplateId, int ownerId, string licenseplate, string carType, string carBrand, string color, DateOnly purchaseDate, double totalKm)
        {
            LicenseplateId = licenseplateId;
            OwnerId = ownerId;
            Licenseplate = licenseplate;
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
