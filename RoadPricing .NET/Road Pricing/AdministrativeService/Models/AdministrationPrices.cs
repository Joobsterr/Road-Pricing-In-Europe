using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdministrativeService.Models
{
    public class AdministrationPrices
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string FuelType { get; set; }
        [Required]
        public string CarType { get; set; }
        [Required]
        public string RoadType { get; set; }
        public DateTime Timeframe { get; set; }
        [Required]
        public Double Price { get; set; }
        public AdministrationPrices(string fuelType, string carType, string roadType, DateTime timeframe, double price)
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
