using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Subsciber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            var connection = factory.CreateConnection();
            using var chanel = connection.CreateModel();
            chanel.QueueDeclare("Orders", exclusive: false);
            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Message : "+message);
            };
            //chanel.BasicConsume(queue:"order", autoAck:true,consumer:consumer);
            chanel.BasicConsume("order",true,consumer);
            Console.ReadKey();
        }
    }
}
