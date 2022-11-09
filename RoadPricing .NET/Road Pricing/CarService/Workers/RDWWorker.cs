using CarService.DTO;
using CarService.Models;
using System.Globalization;
using System.Text.Json;

namespace CarService.Workers
{
    public class RDWWorker
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Car> getCarAsync(string LicensePlate, int userID)
        {
            var response = await client.GetAsync("https://opendata.rdw.nl/resource/m9d7-ebf2.json?kenteken=" + LicensePlate);

            var responseString = await response.Content.ReadAsStringAsync();

            CultureInfo provider = CultureInfo.InvariantCulture;
            string format = "yyyyMMdd";

            if (responseString != null)
            {
                List<RDWCar> rdwCar = JsonSerializer.Deserialize<List<RDWCar>>(responseString);
                Car c = new Car(LicensePlate, userID, rdwCar.First().voertuigsoort, rdwCar.First().merk, rdwCar.First().eerste_kleur, DateTime.ParseExact(rdwCar.First().datum_tenaamstelling, format, provider));
                return c;
            }
            else { return new Car(); }
        }
    }
}
