namespace BillingService.Models.DTO
{
    public class Trip
    {
        public int Id { get; set; }
        public List<DataModel> Coordinates { get; set; }    
        public double TotalDistance { get; set; }
        public DateOnly TimeDriven { get; set; }
        public double TotalPrice { get; set; }

        public Trip(int id, List<DataModel> coordinates, double totalDistance, DateOnly timeDriven, double totalPrice)
        {
            Id = id;
            Coordinates = coordinates;
            TotalDistance = totalDistance;
            TimeDriven = timeDriven;
            TotalPrice = totalPrice;
        }

        public Trip(List<DataModel> coordinates, double totalDistance, DateOnly timeDriven, double totalPrice)
        {
            Coordinates = coordinates;
            TotalDistance = totalDistance;
            TimeDriven = timeDriven;
            TotalPrice = totalPrice;
        }
    }
}
