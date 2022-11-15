using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int BSN { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }

        public User(int bSN, string username, string password, string email, string address, string city)
        {
            BSN = bSN;
            Username = username;
            Password = password;
            Email = email;
            Address = address;
            City = city;
        }

        public User()
        {
        }
    }
}
