namespace RouteService.Models
{
    public class Route
    {
        public int Id { get; set; }
        public List<Tuple<string, string>> Coordinates { get; set; }
        public Double TotalDistance { get; set; }
        public DateOnly TimeDriven { get; set; }

        public Route(int id, List<Tuple<string, string>> coordinates, double totalDistance, DateOnly timeDriven)
        {
            Id = id;
            Coordinates = coordinates;
            TotalDistance = totalDistance;
            TimeDriven = timeDriven;
        }

        public Route()
        {
        }
    }
}
