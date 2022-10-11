using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BillingService.RabbitMQ
{
    public static class RabbitMQListener
    {
        public static void activateListeners()
        {
            Console.WriteLine("Adding new listener...");
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
            // declare a server-named queue
            var queueName = channel.QueueDeclare(queue: "").QueueName;

            // Add binding keys below here:
            List<string> bindingKeys = new List<string>();
            bindingKeys.Add("secundaryTestingBus");

            foreach (var bindingKey in bindingKeys)
            {
                channel.QueueBind(queue: queueName, exchange: "topic_logs", routingKey: bindingKey);
            }

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var routingKey = ea.RoutingKey;
                Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
            };
            channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
        }
    }
}
