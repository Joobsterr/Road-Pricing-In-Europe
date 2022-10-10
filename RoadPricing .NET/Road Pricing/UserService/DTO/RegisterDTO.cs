namespace UserService.DTO
{
    public class RegisterDTO
    {
        public int BSN { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }

        public RegisterDTO(int bSN, string userName, string passWord)
        {
            BSN = bSN;
            this.userName = userName;
            this.passWord = passWord;
        }
    }
}
