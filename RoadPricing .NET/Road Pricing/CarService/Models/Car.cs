using System.ComponentModel.DataAnnotations;

namespace CarService.Models
{
    public class Car
    {
<<<<<<< HEAD
        [Required, Key]
        public string Licenseplate { get; set; }
        [Required]
        public int OwnerId { get; set; }
        [Required]
=======
        public string Licenseplate { get; set; }
        public int OwnerId { get; set; }
>>>>>>> nardobranch
        public string CarType { get; set; }
        [Required]
        public string CarBrand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }

<<<<<<< HEAD
        public Car(string licenseplate, int ownerId, string carType, string carBrand, string color, DateTime purchaseDate)
=======
        public Car(string licenseplate, int ownerId, string carType, string carBrand, string color, DateOnly purchaseDate, double totalKm)
>>>>>>> nardobranch
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
