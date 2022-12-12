using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.Repository;
using BillingService.Workers;
using System.Globalization;

namespace BillingService.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly MollieWorker _mollieWorker;
        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
            _mollieWorker = new MollieWorker();
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

        public async Task<priceLinkDTO> GeneratePriceForTrip(List<DataModel> datapoints)
        {
            double price = CalculateRoutePrice(datapoints);
            string paymentLink = await _mollieWorker.generateExternalPaymentLink(price);
            return new priceLinkDTO(paymentLink, price);
        }

        private double CalculateRoutePrice(List<DataModel> datapoints)
        {
            double price = 0;
            foreach (DataModel datapoint in datapoints)
            {
                price += GetCarTypePrice(datapoint.vehicleTypeName);
                price += GetRoadTypePrice(datapoint.laneMaxSpeedMs);
                price += GetFuelTypePrice(datapoint.emissionType);
                price += GetTimeFramePrice(datapoint.dateTimeStamp.Hour);
            }

            return price;
        }
        public async Task<string> GetPaymentLink(int userId, int billId)
        {
            Bill userBill = _billRepository.GetPaymentBillById(userId, billId);
            double price = 0;
            foreach(Trip trip in userBill.trips)
            {
                price += trip.totalPrice;
            }
            string paymentLink = await _mollieWorker.generatePaymentLink(price, userBill.month, userBill.year);
            return paymentLink;
        }


        //Mock price methods
        private double GetCarTypePrice(string carType)
        {
            switch (carType)
            {
                case "DEFAULT_VEHTYPE":
                    return 0.05;
                default:
                    return 0.01;
            }
        }

        private double GetRoadTypePrice(double maxSpeedLane)
        {
            switch (maxSpeedLane)
            {
                case < 7:  //20kmh
                    return 0.10;

                case < 9:  //30kmh
                    return 0.15;

                case < 15: //50kmh
                    return 0.25;

                case < 18: //60kmh
                    return 0.30;

                case < 20: //70kmh
                    return 0.35;

                case < 23: //80kmh
                    return 0.40;

                case < 29: //100kmh
                    return 0.50;

                case < 34: //120kmh
                    return 0.60;

                case < 37: //130kmh
                    return 0.65;

                case > 36:
                    return 1.00;

                default:
                    return 0.01;
            }
        }

        private double GetFuelTypePrice(string fuelType)
        {
            switch (fuelType)
            {
                case "petrol":
                    return 0.05;
                case "electric":
                    return 0.02;
                default:
                    return 0.01;
            }
        }

        private double GetTimeFramePrice(int hourMark)
        {
            switch (hourMark)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return 0.10;
                case 6:
                case 7:
                case 8:
                case 9:
                    return 0.50;
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                    return 0.20;
                case 16:
                case 17:
                case 18:
                case 19:
                    return 0.40;
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                    return 0.30;
                default:
                    return 0.01;
            }
        }
    }
}
