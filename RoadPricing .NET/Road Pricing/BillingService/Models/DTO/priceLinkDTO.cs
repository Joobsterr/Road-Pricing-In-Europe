﻿namespace BillingService.Models.DTO
{
    public class priceLinkDTO
    {
        public string paymentLink { get; set; }
        public double price { get; set; }
        public string description { get; set; }

        public priceLinkDTO(string paymentLink, double price, string calculation)
        {
            this.paymentLink = paymentLink;
            this.price = price;
            this.description = calculation;
        }
    }
}