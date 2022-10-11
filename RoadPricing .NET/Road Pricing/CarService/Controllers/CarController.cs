using Microsoft.AspNetCore.Mvc;
using CarService.Models;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        public Car GetSpecificCar(string Licenseplate)
        {
            return new Car();
        }
        public List<Car> GetAllOwnerCars(int OwnerId)
        {
            return new List<Car>();
        }
        public bool AddNewCar(int OwnerId, Car nCar)
        {
            return true;
        }
        public bool DeleteCar(int OwnerId, int CarId)
        {
            return true;
        }
    }
}