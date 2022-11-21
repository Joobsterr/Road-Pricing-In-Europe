using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Car
    {
        [Required, Key]
        public string Licenseplate { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public string CarBrand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }

        public Car(string licenseplate, int ownerId, string carType, string carBrand, string color, DateTime purchaseDate)
        {
            Licenseplate = licenseplate;
            OwnerId = ownerId;
            CarType = carType;
            CarBrand = carBrand;
            Color = color;
            PurchaseDate = purchaseDate;
        }

        public Car()
        {
        }
    }
}
