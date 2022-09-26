namespace UserService.Models
{
    public class User
    {
        public int BSN { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int bSN, string username, string password)
        {
            BSN = bSN;
            Username = username;
            Password = password;
        }
    }
}
