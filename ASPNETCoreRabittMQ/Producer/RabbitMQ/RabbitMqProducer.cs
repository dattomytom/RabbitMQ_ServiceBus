﻿using Producer.RabbitMQ.Connection;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Producer.RabbitMQ
{
    public class RabbitMqProducer : IMessageProducer
    {
        private readonly IRabbitMqConnection _connection;

        public RabbitMqProducer(IRabbitMqConnection connection)
        {
            _connection = connection;
        }

        public void SendMessage<T>(T message)
        {
            using var channel = _connection.Connection.CreateModel();
            channel.QueueDeclare("order", exclusive: false);
            var json = JsonSerializer.Serialize(message);

            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange:"", routingKey: "order", body: body);
        }
    }
}
