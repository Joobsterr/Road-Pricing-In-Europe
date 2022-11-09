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
        public async Task<IActionResult> addNewCar(string Licenseplate, int userID)
        {
            Car c = await _carRepository.addNewCar(Licenseplate, userID);
            if(c == default)
            {
                return Ok(new ApiResponse<string>(false, "Deze auto kan niet worden toegevoegd"));
            }
            else { return Ok(new ApiResponse<Car>(true, c)); }
        }
    }
}