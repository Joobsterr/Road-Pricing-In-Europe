using BillingService.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BillingService.Models.EnglishGroupModels;
using System.Text;
using Newtonsoft.Json;

namespace BillingService.Workers;

public class TransformDataWorker
{
    private static readonly HttpClient client = new HttpClient();



    public async Task<TripEn> ConvertData(List<DataModel> datapoints)
    {
        if (datapoints.Count == 0)
        {
            return null;
        }

        List<CoordinateEn> coordinateEn = new List<CoordinateEn>();
        foreach (DataModel datapoint in datapoints)
        {
            coordinateEn.Add(new CoordinateEn(datapoint.dateTimeStamp, datapoint.lat_long.Item2, datapoint.lat_long.Item1, GetRoadTypeEn(datapoint.laneMaxSpeedMs)));
        }

        return new TripEn(datapoints[0].carId, new RouteEn(coordinateEn, GetVehicleTypeRandom()));
    }

    public async Task<ResponseEn> SendData(TripEn tripEn)
    {
        try
        {
            string url = "http://213.125.163.178:8085/billing/externalBilling";
            string inputJsonString = JsonConvert.SerializeObject(tripEn);
            var httpContent = new StringContent(inputJsonString, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var response = await client.PostAsync(url, httpContent);

            var responseJsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ResponseEn>(responseJsonString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return new ResponseEn(1, 1, 1, "1", "https://google.nl");
    }

    public string GetRoadTypeEn(double maxSpeedLane)
    {
        switch (maxSpeedLane)
        {
            case < 14: //30mph
                return "Built-up area";

            case < 28:  //60mph
                return "Single carriageway";

            default:   //70mph and above
                return "Dual carriageway / Motorway";
        }
    }

    public string GetVehicleTypeRandom()
    {
        CarType vehicleType = (CarType)(new Random()).Next(0, 4);
        switch (vehicleType)
        {
            case CarType.PETROL:
                return "PETROL";
            case CarType.GASOLINE:
                return "GASOLINE";
            case CarType.DIESEL:
                return "DIESEL";
            case CarType.ELECTRIC:
                return "ELECTRIC";
            default:
                return "PETROL";
        }
    }

    public enum CarType
    {
        PETROL,
        GASOLINE,
        DIESEL,
        ELECTRIC
    }
}
