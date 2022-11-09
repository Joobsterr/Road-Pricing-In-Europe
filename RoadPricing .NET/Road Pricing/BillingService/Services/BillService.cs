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

        public bool AddTripToBill(List<DataModel> datapoints, int userBsn)
        {
            //Calculate routeprice total etc...
            double tripPrice = CalculateRoutePrice(datapoints);

            return _billRepository.AddTripToBill(new Trip(datapoints, 100.00, DateOnly.FromDateTime(DateTime.Now), 100.00), userBsn);
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

            return price;
        }
    }
}
