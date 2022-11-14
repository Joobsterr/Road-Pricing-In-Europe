namespace CarService.DTO
{
    public class LicenseDTO
    {
        public string Licenseplate { get; set; }
        public int userID { get; set; }

        public LicenseDTO(string licenseplate, int userID)
        {
            Licenseplate = licenseplate;
            this.userID = userID;
        }
    }
}
