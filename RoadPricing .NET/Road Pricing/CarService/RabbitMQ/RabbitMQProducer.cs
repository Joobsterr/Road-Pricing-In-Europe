using RabbitMQ.Client;
using System.Text;

namespace CarService.RabbitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        /*
         * routingKey = specific Key that listeners listen to
         * exchange = queue that the message goes into
         * type = type of message, possibilities are: direct, topic, headers or fanout
         * message = the message you want to sent
         */

        public void sendRabbitMessage(string routingKey, string message, string inputExchange, string inputType)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            // Declare the Exchange, in dit geval: topic_logs is de naam van de exchange, en het type is een topic. Er zijn meerdere verschillende types mogelijk.
            channel.ExchangeDeclare(exchange: inputExchange, type: inputType);

            // Encoding the message
            var body = Encoding.UTF8.GetBytes(message);
            // Publisches the message on the specific topic
            channel.BasicPublish(exchange: "topic_logs", routingKey: routingKey, basicProperties: null, body: body);
            // Unnecessary, but handy to see what you're sending
            Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");
        }
    }
}
