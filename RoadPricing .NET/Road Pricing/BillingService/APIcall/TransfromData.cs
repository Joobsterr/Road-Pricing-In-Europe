using BillingService.Models;
using System.Text.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingService.APIcall;

public class TransfromData
{
    private static readonly HttpClient client = new HttpClient();

    public async Task<bool> ConvertToJason(List<DataModel> data)
    {
       string jsonString = JsonSerializer.Serialize(data);
       return await SendData(jsonString); 
    }

    private async Task<bool> SendData(string jsonString)
    {
        //hardcore the url string.
        string sendingURL = "http://213.125.163.178:8085/billing/externalBilling";
        var returnValue=  await client.PostAsJsonAsync(sendingURL, jsonString);
        if (returnValue != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   

}
