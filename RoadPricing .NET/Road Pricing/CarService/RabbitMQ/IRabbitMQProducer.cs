namespace CarService.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        void sendRabbitMessage(string routingKey, string message, string inputExchange, string inputType);
    }
}