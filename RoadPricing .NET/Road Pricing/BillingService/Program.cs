using BillingService.Repository;
using BillingService.Services;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddDbContext<BillDbContext>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IBillService, BillService>();
var app = builder.Build();


//// RabbitMQ listener
//// Onderstaande code werkt, maar is niet zo netjes...
//var exchangeKey = "testingExchange"; // You connect the listener to this exchange
//var bindingKey = "testingBus"; // The routing key, specifies the service you're talking tos
//var inputType = "topic"; // Leave this one the same

//var factory = new ConnectionFactory() { HostName = "localhost" };

//using var connection = factory.CreateConnection();
//using var channel = connection.CreateModel();

//channel.ExchangeDeclare(exchange: exchangeKey, type: inputType);
//// declare a server-named queue (queue = name of the connection)
//var queueName = channel.QueueDeclare(queue: "billingService").QueueName;

//channel.QueueBind(queue: queueName, exchange: exchangeKey, routingKey: bindingKey);

//// Add listener so you get the messages
//var consumer = new EventingBasicConsumer(channel);
//consumer.Received += (model, ea) =>
//{
//    var body = ea.Body.ToArray();
//    var message = Encoding.UTF8.GetString(body);
//    var routingKey = ea.RoutingKey;
//    // Do some extra stuff here on message received, like send to specific classes etc
//    Console.WriteLine($" [x] Received '{routingKey}':'{message}'");
//};
//channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer); 
//// t/m hier



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("corsapp");

app.UseAuthorization();

app.MapControllers();

app.Run();

