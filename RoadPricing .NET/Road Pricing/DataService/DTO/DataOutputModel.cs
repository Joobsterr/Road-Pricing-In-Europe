namespace DataService.DTO
{
    public class DataOutputModel
    {
        public string Coordinates { get; set; }

        public DataOutputModel(string coordinates)
        {
            Coordinates = coordinates;
        }
    }
}
