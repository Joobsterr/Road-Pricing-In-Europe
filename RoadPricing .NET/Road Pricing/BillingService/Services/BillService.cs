using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.Models.EnglishGroupModels;
using BillingService.Repository;
using BillingService.Workers;
using System.Globalization;

namespace BillingService.Services
{
    public class BillService : IBillService
    {
        private readonly IBillRepository _billRepository;
        private readonly MollieWorker _mollieWorker;
        private readonly AdministrationPricesWorker _administrationPricesWorker;
        private readonly TransformDataWorker _transformDataWorker;

        public BillService(IBillRepository billRepository)
        {
            _billRepository = billRepository;
            _mollieWorker = new MollieWorker();
            _administrationPricesWorker = new AdministrationPricesWorker();
            _transformDataWorker = new TransformDataWorker();
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
            string description = datapoints.Count + " datapoints for a total price of €" + price
                + ". The trip was started on " + datapoints[0].dateTimeStamp.ToString("dd/MM/yyyy HH:mm")
                + " and ended on " + datapoints[datapoints.Count - 1].dateTimeStamp.ToString("dd/MM/yyyy HH:mm")
                + ". This resulted in an average rate of €" + getAverageRatePerDatapoint(price, datapoints) + " per minute for this trip";
            string paymentLink = await _mollieWorker.generateExternalPaymentLink(price);
            return new priceLinkDTO(paymentLink, price, description);
        }

        private double getAverageRatePerDatapoint(double price, List<DataModel> datapoints)
        {
            TimeSpan totalDrivenMinutes = datapoints[datapoints.Count - 1].dateTimeStamp - datapoints[0].dateTimeStamp;
            double averageRate = price / totalDrivenMinutes.TotalMinutes;
            averageRate = Math.Round(averageRate, 2);
            return averageRate;
        }

        private double CalculateRoutePrice(List<DataModel> datapoints)
        {
            double price = 0;
            foreach (DataModel datapoint in datapoints)
            {
                price += _administrationPricesWorker.GetCarTypePrice(datapoint.vehicleTypeName);
                price += _administrationPricesWorker.GetRoadTypePrice(datapoint.laneMaxSpeedMs);
                price += _administrationPricesWorker.GetFuelTypePrice(datapoint.emissionType);
                price += _administrationPricesWorker.GetTimeFramePrice(datapoint.dateTimeStamp.Hour);
            }
            price = Math.Round(price, 2);

            return price;
        }
        public async Task<string> GetPaymentLink(int userId, int billId)
        {
            Bill userBill = _billRepository.GetPaymentBillById(userId, billId);
            double price = 0;
            foreach (Trip trip in userBill.trips)
            {
                price += trip.totalPrice;
            }
            string paymentLink = await _mollieWorker.generatePaymentLink(price, userBill.month, userBill.year);
            return paymentLink;
        }

        public async Task<TripEn> TransformDatapointsToEnglish(List<DataModel> datapoints)
        {
            TripEn tripEn = await _transformDataWorker.ConvertData(datapoints);
            //ResponseEn responseEn = await _transformDataWorker.SendData(tripEn);
            string responseEn = await _transformDataWorker.SendData(tripEn);

            return tripEn;
        }
    } 
}

