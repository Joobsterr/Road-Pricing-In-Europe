using Microsoft.AspNetCore.Mvc;
using CarService.Models;
using CarService.RabbitMQ;

namespace CarService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly IRabbitMQProducer _rabbitMQProducer;

        public CarController(IRabbitMQProducer rabbitMQProducer)
        {
            _rabbitMQProducer = rabbitMQProducer;
        }

        [HttpGet("getCar")]
        public Car GetSpecificCar(string Licenseplate)
        {
            return new Car();
        }

        [HttpGet("getCarByOwnerId")]
        public List<Car> GetAllOwnerCars(int OwnerId) 
        {
            return new List<Car>();
        }

        [HttpPost("addCar")]
        public bool AddNewCar(int OwnerId, Car nCar)
        {
            return true;
        }

        [HttpDelete("deleteCar")]
        public bool DeleteCar(int OwnerId, int CarId)
        {
            return true;
        }

        [HttpPost("sendRabbitMessage")]
        public async Task<IActionResult> SendRabbitMessage(string routingKey, string message)
        {
            _rabbitMQProducer.sendRabbitMessage(routingKey, message);
            return Ok("Following message sent: " + routingKey + " : " + message);
        }
    }
}