namespace UserService.DTO
{
    public class UserDTO
    {
        public string userName { get; set; }   
        public string passWord { get; set; }

        public UserDTO(string username, string password)
        {
            userName = username;
            passWord = password;
        }
    }
}
