﻿using BillingService.Models;
using BillingService.Models.DTO;
using BillingService.Models.EnglishGroupModels;

namespace BillingService.Services
{
    public interface IBillService
    {
        bool AddTripToBill(int userId, List<DataModel> datapoints);
        Task<priceLinkDTO> GeneratePriceForTrip(List<DataModel> datapoints);
        List<Bill> GetUserBills(int userId);
        Bill GetUserSpecificBill(int userId, int month, int year);
        Task<string> GetPaymentLink(int userId, int billId);
        Task<ResponseEn> TransformDatapointsToEnglish(List<DataModel> datapoints);
    }
}