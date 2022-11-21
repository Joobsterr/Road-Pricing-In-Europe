<<<<<<< HEAD
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
=======
using AdministrativeService;
using AdministrativeService.DataBase;
using AdministrativeService.Repository;
using AdministrativeService.Service;
using Microsoft.EntityFrameworkCore;
>>>>>>> ginobranch

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IAdministrationService, AdministrationService>();
builder.Services.AddScoped<IAdministrationRepository, AdministrationRepository>();
builder.Services.AddCors();

var app = builder.Build();


// RabbitMQ listener
// Onderstaande code werkt, maar is niet zo netjes...
var exchangeKey = "testingExchange"; // You connect the listener to this exchange
var bindingKey = "testingBus"; // The routing key, specifies the service you're talking tos
var inputType = "topic"; // Leave this one the same

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: exchangeKey, type: inputType);
// declare a server-named queue (queue = name of the connection)
var queueName = channel.QueueDeclare(queue: "administrationService").QueueName;

channel.QueueBind(queue: queueName, exchange: exchangeKey, routingKey: bindingKey);

// Add listener so you get the messages
var consumer = new EventingBasicConsumer(channel);
consumer.Received += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    var routingKey = ea.RoutingKey;
    // Do some extra stuff here on message received, like send to specific classes etc
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
app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.UseAuthorization();

app.MapControllers();
PrepDB.PrepPopulation(app);
app.Run();
