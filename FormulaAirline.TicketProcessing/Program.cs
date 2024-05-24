// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

Console.WriteLine("Hi, Welcome to ticketing service!");


var factory = new ConnectionFactory()
{
    HostName = "localhost",
    UserName = "zeeshan",
    Password = "123456",
    VirtualHost = "/",
};

var conn = factory.CreateConnection();

using var channel = conn.CreateModel();

channel.QueueDeclare("bookings", true, false);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, eventArgs) =>
{
    var body = eventArgs.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine($"A message has been received. Now processing message:\n\n{message}");
};

channel.BasicConsume("bookings", true, consumer);

Console.ReadKey();