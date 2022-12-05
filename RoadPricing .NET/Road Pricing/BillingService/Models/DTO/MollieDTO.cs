namespace BillingService.Models.DTO
{
    public class MollieDTO
    {
        public string resource { get; set; }
        public string id { get; set; }
        public string mode { get; set; }
        public DateTime createdAt { get; set; }
        public Amount amount { get; set; }
        public string description { get; set; }
        public object method { get; set; }
        public object metadata { get; set; }
        public string status { get; set; }
        public bool isCancelable { get; set; }
        public DateTime expiresAt { get; set; }
        public object details { get; set; }
        public string profileId { get; set; }
        public string sequenceType { get; set; }
        public string redirectUrl { get; set; }
        public Links _links
        {
            get; set;
        }
        public class Amount
        {
            public string value { get; set; }
            public string currency { get; set; }
        }

        public class Checkout
        {
            public string href { get; set; }
        }

        public class Links
        {
            public Self self { get; set; }
            public Checkout checkout { get; set; }
        }
        public class Self
        {
            public string href { get; set; }
        }
    }
}
