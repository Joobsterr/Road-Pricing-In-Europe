using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BillingService.Models
{
    public class Bill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public List<Trip> trips { get; set; }
        [Required]
        public int month { get; set; }
        [Required]
        public int year { get; set; }

        public Bill()
        {
        }

        public Bill(int id, int userId, int month, int year)
        {
            this.id = id;
            this.userId = userId;
            this.month = month;
            this.year = year;
        }

        public Bill(int userId, int month, int year)
        {
            this.userId = userId;
            this.month = month;
            this.year = year;
        }
    }
}
