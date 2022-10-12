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