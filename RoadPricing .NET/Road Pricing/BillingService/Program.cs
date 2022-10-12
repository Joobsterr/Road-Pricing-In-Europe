using BillingService.RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Onderstaande code werkt, maar is niet zo netjes...
Console.WriteLine("Adding new listener...");
var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "topic_logs", type: "topic");
// declare a server-named queue
var queueName = channel.QueueDeclare(queue: "billingService").QueueName;

// Add binding keys below here:
List<string> bindingKeys = new List<string>();
bindingKeys.Add("testingBus");

foreach (var bindingKey in bindingKeys)
{
    channel.QueueBind(queue: queueName, exchange: "topic_logs", routingKey: bindingKey);
}

// Add listener so you get the messages
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = ea.RoutingKey;
    Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
};
channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer); 
// t/m hier



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

