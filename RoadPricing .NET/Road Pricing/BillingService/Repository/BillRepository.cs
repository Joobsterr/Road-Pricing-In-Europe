using BillingService.Models;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Repository
{
    public class BillRepository : IBillRepository
    {
        // Docker command:
        // docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password1!" --name billmssql -p 1633:1433 -d mcr.microsoft.com/mssql/server:2022-latest

        // Connect to DB here as well
        private readonly BillDbContext _billDbContext;
        public BillRepository(BillDbContext billDbContext)
        {
            _billDbContext = billDbContext;
        }

        public bool AddTripToBill(int userId, int month, int year, Trip trip)
        {
            Bill bill = new Bill();
            bill = _billDbContext.Bills.Where(bill => bill.userId == userId && bill.month == month && bill.year == year).FirstOrDefault();

            if (bill == null)
            {
                _billDbContext.Bills.Add(new Bill(userId, month, year));
                _billDbContext.SaveChanges();
                bill = _billDbContext.Bills.Where(bill => bill.userId == userId && bill.month == month && bill.year == year).FirstOrDefault();
            }

            trip.billId = bill.id;
            _billDbContext.Trips.Add(trip);

            _billDbContext.SaveChanges();
            // Add object to database in refference to the correct bill
            return true;
        }

        public List<Bill> GetUserBills(int userId)
        {
            List<Bill> bills = _billDbContext.Bills.Where(bill => bill.userId == userId).ToList();
            foreach (Bill bill in bills)
            {
                bill.trips = _billDbContext.Trips.Where(trip => trip.billId == bill.id).ToList();
            }
            return bills;
        }
    }
}
