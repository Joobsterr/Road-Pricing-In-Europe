using BillingService.Models;
using System.Text.Json;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using BillingService.Models.EnglishGroupModels;
using System.Text;

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

        return new TripEn(datapoints[0].carId, coordinateEn, GetVehicleTypeRandom());
    }

    public async Task<string> SendData(TripEn tripEn)
    {
        string url = "http://213.125.163.178:8085/billing/externalBilling";
        string jsonString = JsonSerializer.Serialize(tripEn);
        var data = new StringContent(jsonString, Encoding.UTF8, "application/json");
        return jsonString;

        using var client = new HttpClient();
        
        var response = await client.PostAsync(url, data);

        var result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);

        return result.ToString();
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
