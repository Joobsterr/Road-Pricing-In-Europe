namespace UserService.DTO
{
    public class RegisterDTO
    {
        public int BSN { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public RegisterDTO(int bSN, string userName, string passWord, string email, string address, string city)
        {
            BSN = bSN;
            this.userName = userName;
            this.passWord = passWord;
            Email = email;
            Address = address;
            City = city;
        }
    }
}
