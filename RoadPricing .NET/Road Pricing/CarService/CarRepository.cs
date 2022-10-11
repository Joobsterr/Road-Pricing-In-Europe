using CarService.Interfaces;
using CarService.Models;

namespace CarService
{
    public class CarRepository : ICarRepository
    {
        public Car getAllCars()
        {
            return new Car();
        }
    }
}
