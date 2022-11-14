using CarService.Models;

namespace CarService.Interfaces
{
    public interface ICarRepository
    {
        Task<Car> addNewCar(string Licenseplate, int userID);
        Task<List<Car>> getAllCars();
        Task<List<Car>> getCarsAsync(int userID);
    }
}