using BillingService.Models.DTO;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;

namespace BillingService.Workers
{
    public class MollieWorker
    {
        public async Task<string> generatePaymentLink(double price, int month, int year)
        {
            Chilkat.Rest rest = new Chilkat.Rest();
            bool success;

            // URL: https://api.mollie.com/v2/payment-links
            bool bTls = true;
            int port = 443;
            bool bAutoReconnect = true;
            success = rest.Connect("api.mollie.com", port, bTls, bAutoReconnect);
            if (success != true)
            {
                Debug.WriteLine("ConnectFailReason: " + Convert.ToString(rest.ConnectFailReason));
                Debug.WriteLine(rest.LastErrorText);
                return rest.LastErrorText;
            }

            // Note: The above code does not need to be repeatedly called for each REST request.
            // The rest object can be setup once, and then many requests can be sent.  Chilkat will automatically
            // reconnect within a FullRequest* method as needed.  It is only the very first connection that is explicitly
            // made via the Connect method.

            string number = price.ToString("0.00");
            number = number.Replace(",", ".");

            rest.ClearAllQueryParams();
            rest.AddQueryParam("amount[currency]", "EUR");
            rest.AddQueryParam("amount[value]", number);
            rest.AddQueryParam("description", "Bill from " + month + "/" + year);
            rest.AddQueryParam("expiresAt", "2023-06-06T11:00:00+00:00");
            rest.AddQueryParam("redirectUrl", "https://www.google.com");
            rest.AddQueryParam("webhookUrl", "https://webhook.site/1fc54b0b-f027-4e27-9a34-3d25d432bb11");

            rest.AddHeader("Authorization", "Bearer test_dKmHzeW2yFas9SGcgSzx7aqANzDgFp");

            string strResponseBody = rest.FullRequestFormUrlEncoded("POST", "/v2/payment-links");
            if (rest.LastMethodSuccess != true)
            {
                Debug.WriteLine(rest.LastErrorText);
                return rest.LastErrorText;
            }

            int respStatusCode = rest.ResponseStatusCode;
            Debug.WriteLine("response status code = " + Convert.ToString(respStatusCode));
            if (respStatusCode >= 400)
            {
                Debug.WriteLine("Response Status Code = " + Convert.ToString(respStatusCode));
                Debug.WriteLine("Response Header:");
                Debug.WriteLine(rest.ResponseHeader);
                Debug.WriteLine("Response Body:");
                Debug.WriteLine(strResponseBody);
                return strResponseBody;
            }
            Console.Write(strResponseBody);
            MollieDTO mDTO = JsonConvert.DeserializeObject<MollieDTO>(strResponseBody);
            mDTO.id = mDTO.id.Remove(0, 3);
            return "https://paymentlink.mollie.com/payment/" + mDTO.id;
        }
    }
}
