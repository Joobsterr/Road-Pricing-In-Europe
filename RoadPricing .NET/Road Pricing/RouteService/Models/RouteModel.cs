namespace RouteService.Models
{
    public class RouteModel
    {
        public int Id { get; set; }
        public List<Tuple<string, string>> Coordinates { get; set; }
        public Double TotalDistance { get; set; }
        public DateOnly TimeDriven { get; set; }

        public RouteModel(int id, List<Tuple<string, string>> coordinates, double totalDistance, DateOnly timeDriven)
        {
            Id = id;
            Coordinates = coordinates;
            TotalDistance = totalDistance;
            TimeDriven = timeDriven;
        }

        public RouteModel()
        {
        }
    }
}
