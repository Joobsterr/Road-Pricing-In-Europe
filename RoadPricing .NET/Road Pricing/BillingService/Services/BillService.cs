using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.Repository;

namespace BillingService.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        public List<Bill> GetUserBills(int userId)
        {
            return _billRepository.GetUserBills(userId);
        }

        public bool AddTripToBill(int userId, List<DataModel> datapoints)
        {
            //Calculate routeprice total etc...
            double tripPrice = CalculateRoutePrice(datapoints);

            return _billRepository.AddTripToBill(userId, new Trip(datapoints, 100.00, DateOnly.FromDateTime(DateTime.Now), 100.00));
        }

        public double GeneratePriceForTrip(List<DataModel> datapoints)
        {
            // Calculate routeprice total
            var tripPrice = CalculateRoutePrice(datapoints);

            return tripPrice;
        }

        private double CalculateRoutePrice(List<DataModel> datapoints)
        {
            double price = 0;
            foreach (DataModel datapoint in datapoints)
            {
                price += getCarTypePrice(datapoint.carType);
                price += getRoadTypePrice(datapoint.maxLaneSpeed);
                price += getFuelTypePrice(datapoint.fuelType);
                price += getTimeFramePrice(datapoint.dateTimeStamp.Hour);
            }

            return price;
        }


        //Mock price methods
        private double getCarTypePrice(string carType)
        {
            switch (carType)
            {
                case "personenauto":
                    return 10;
                case "vrachtwagen":
                    return 10;
                default:
                    return 0;
            }
        }

        private double getRoadTypePrice(double maxSpeedLane)
        {
            switch (maxSpeedLane)
            {
                case 30:
                    return 10;
                case 50:
                    return 15;
                default:
                    return 0;
            }
        }

        private double getFuelTypePrice(string fuelType)
        {
            switch (fuelType)
            {
                case "petrol":
                    return 15;
                case "electric":
                    return 10;
                default:
                    return 0;
            }
        }

        private double getTimeFramePrice(int hourMark)
        {
            switch (hourMark)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return 5;
                case 6:
                case 7:
                case 8:
                case 9:
                    return 20;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return 10;
                case 16:
                case 17:
                case 18:
                case 19:
                    return 15;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    return 10;
                default:
                    return 0;
            }
        }
    }
}
