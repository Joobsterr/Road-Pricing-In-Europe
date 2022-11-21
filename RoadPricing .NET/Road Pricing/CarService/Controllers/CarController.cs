using Microsoft.AspNetCore.Mvc;
using CarService.Models;
<<<<<<< HEAD
using CarService.Interfaces;
using System.Collections.Generic;
using CarService.DTO;
=======
using CarService.RabbitMQ;
>>>>>>> nardobranch

namespace CarService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CarController : ControllerBase
    {
<<<<<<< HEAD
        public readonly ICarRepository _carRepository;

        public CarController(ICarRepository carRepository)
=======
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public CarController(IRabbitMQProducer rabbitMQProducer)
        {
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet("getCar")]
        public Car GetSpecificCar(string Licenseplate)
>>>>>>> nardobranch
        {
            _carRepository = carRepository;
        }
<<<<<<< HEAD
        [HttpGet("getAllCars")]
        public async Task<List<Car>> getAllCars()
=======

        [HttpGet("getCarByOwnerId")]
        public List<Car> GetAllOwnerCars(int OwnerId) 
>>>>>>> nardobranch
        {
            List<Car> cars = await _carRepository.getAllCars();
            return cars;
        }
<<<<<<< HEAD
        [HttpPost("addNewCar")]
        public async Task<IActionResult> addNewCar(LicenseDTO licenseDTO)
=======

        [HttpPost("addCar")]
        public bool AddNewCar(int OwnerId, Car nCar)
>>>>>>> nardobranch
        {
            Car c = await _carRepository.addNewCar(licenseDTO.Licenseplate, licenseDTO.userID);
            if(c == default)
            {
                return Ok(new ApiResponse<string>(false, "This car cannot be added"));
            }
            else { return Ok(new ApiResponse<Car>(true, c)); }
        }
<<<<<<< HEAD
        [HttpGet("getCarsByUser/{userID}")]
        public async Task<List<Car>> getCarsAsync(int userID)
=======

        [HttpDelete("deleteCar")]
        public bool DeleteCar(int OwnerId, int CarId)
>>>>>>> nardobranch
        {
            List<Car> cars = await _carRepository.getCarsAsync(userID);
            return cars;
        }

        /*
         * input data for example:
         * routingKey = testingBus (naar welke services moet het doorgestuurd worden?)
         * message = testMessage, is this going through???
         * exchange = topic_logs (dit kun je zien als het topic waar je over praat, bijvoorbeeld een gebruiker)
         * type = topic (meerdere soorten beschikbaar, hier op dit moment topic gebruikt)
         */
        [HttpPost("sendRabbitMessage")]
        public async Task<IActionResult> SendRabbitMessage(string routingKey, string message, string exchangeName, string type)
        {
            _rabbitMQProducer.sendRabbitMessage(routingKey, message, exchangeName, type);
            return Ok("Following message sent: " + exchangeName + " : " + type + " : " + routingKey + " : " + message);
        }
    }
}