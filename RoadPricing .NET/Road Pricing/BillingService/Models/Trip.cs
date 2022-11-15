using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int routeId { get; set; }
        [Required]
        public int carId { get; set; }
        [Required]
        public DateTime routeStartTime { get; set; }
        [Required]
        public double timeDrivenInMinutes { get; set; }
        [Required]
        public double totalPrice { get; set; }
        public int billId { get; set; }

        public Trip(int routeId, int carId, DateTime routeStartTime, double timeDrivenInMinutes, double totalPrice)
        {
            this.routeId = routeId;
            this.carId = carId;
            this.routeStartTime = routeStartTime;
            this.timeDrivenInMinutes = timeDrivenInMinutes;
            this.totalPrice = totalPrice;
        }
    }
}
