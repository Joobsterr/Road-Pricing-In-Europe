using BillingService.Models;
using BillingService.Repository;
using System.Globalization;

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
            List<Bill> bills = _billRepository.GetUserBills(userId);

            return bills.OrderByDescending(x => x.month).ToList();
        }

        public bool AddTripToBill(int userId, List<DataModel> datapoints)
        {
            double tripPrice = CalculateRoutePrice(datapoints);
            DataModel firstDataModelInList = datapoints[0];
            TimeSpan timespan = datapoints.Last().dateTimeStamp - firstDataModelInList.dateTimeStamp;

            return _billRepository.AddTripToBill(userId, firstDataModelInList.dateTimeStamp.Month, firstDataModelInList.dateTimeStamp.Year, new Trip(firstDataModelInList.routeId, firstDataModelInList.carId, firstDataModelInList.dateTimeStamp, timespan.TotalMinutes, tripPrice));
        }
        public Bill GetUserSpecificBill(int userId, int month, int year)
        {
            Bill specificBill = _billRepository.GetUserSpecificBills(userId, month, year);
            return specificBill;
        }

        public double GeneratePriceForTrip(List<DataModel> datapoints)
        {
            return CalculateRoutePrice(datapoints);
        }

        private double CalculateRoutePrice(List<DataModel> datapoints)
        {
            double price = 0;
            foreach (DataModel datapoint in datapoints)
            {
                price += getCarTypePrice(datapoint.vehicleTypeName);
                price += getRoadTypePrice(datapoint.laneMaxSpeedMs);
                price += getFuelTypePrice(datapoint.emissionType);
                price += getTimeFramePrice(datapoint.dateTimeStamp.Hour);
            }

            return price;
        }


        //Mock price methods
        private double getCarTypePrice(string carType)
        {
            switch (carType)
            {
                case "DEFAULT_VEHTYPE":
                    return 0.50;
                default:
                    return 0;
            }
        }

        private double getRoadTypePrice(double maxSpeedLane)
        {
            switch (maxSpeedLane)
            {
                case < 7:  //20kmh
                    return 1.00;

                case < 9:  //30kmh
                    return 1.25;

                case < 15: //50kmh
                    return 1.75;

                case < 18: //60kmh
                    return 2.00;

                case < 20: //70kmh
                    return 2.25;

                case < 23: //80kmh
                    return 2.50;

                case < 29: //100kmh
                    return 3.00;

                case < 34: //120kmh
                    return 4.00;

                case < 37: //130kmh
                    return 5.00;

                case > 36:
                    return 5.00;

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
                    return 0.50;
                case 6:
                case 7:
                case 8:
                case 9:
                    return 2.00;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return 1.00;
                case 16:
                case 17:
                case 18:
                case 19:
                    return 1.50;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    return 1.00;
                default:
                    return 0;
            }
        }
    }
}
