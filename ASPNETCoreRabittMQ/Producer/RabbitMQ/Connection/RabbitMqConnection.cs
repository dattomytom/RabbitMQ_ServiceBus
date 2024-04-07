﻿using RabbitMQ.Client;

namespace Producer.RabbitMQ.Connection
{
    public class RabbitMqConnection : IRabbitMqConnection, IDisposable
    {
        private IConnection? _connection;
        public IConnection Connection => _connection!;

        public RabbitMqConnection()
        {
            InitializeConnnection();
        }

        private void InitializeConnnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
            };
            _connection = factory.CreateConnection();
        }

        public void Dispose()
        {
            _connection?.Dispose();
        }
    }
}
