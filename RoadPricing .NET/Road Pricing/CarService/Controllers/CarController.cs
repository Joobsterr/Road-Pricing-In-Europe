using Microsoft.AspNetCore.Mvc;
using CarService.Models;
using CarService.Interfaces;
using System.Collections.Generic;
using CarService.DTO;

namespace CarService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CarController : ControllerBase
    {
        public readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        [HttpGet("getAllCars")]
        public async Task<List<Car>> getAllCars()
        {
            List<Car> cars = await _carRepository.getAllCars();
            return cars;
        }
        [HttpPost("addNewCar")]
        public async Task<IActionResult> addNewCar(LicenseDTO licenseDTO)
        {
            Car c = await _carRepository.addNewCar(licenseDTO.Licenseplate, licenseDTO.userID);
            if(c == default)
            {
                return Ok(new ApiResponse<string>(false, "This car cannot be added"));
            }
            else { return Ok(new ApiResponse<Car>(true, c)); }
        }
        [HttpGet("getCarsByUser/{userID}")]
        public async Task<List<Car>> getCarsAsync(int userID)
        {
            List<Car> cars = await _carRepository.getCarsAsync(userID);
            return cars;
        }
    }
}