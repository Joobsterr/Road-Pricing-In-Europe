using CarService.Context;
using CarService.Interfaces;
using CarService.Models;
using CarService.Workers;
using Microsoft.EntityFrameworkCore;

namespace CarService
{
    public class CarRepository : ICarRepository
    {
        private readonly DatabaseContext _dbContext;
        public RDWWorker _rdwWorker = new RDWWorker();

        public CarRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Car>> getAllCars()
        {
            List<Car> cars = await _dbContext.Cars.ToListAsync();
            return cars;
        }
        public async Task<Car> addNewCar(string Licenseplate, int userID)
        {
            Car car = await _rdwWorker.getCarAsync(Licenseplate, userID);
            try
            {
                await _dbContext.Cars.AddAsync(car);
                await _dbContext.SaveChangesAsync();
                return car;
            }
            catch { return default(Car); }

        }

    }
}
