using RabbitMQ.Client;
using System;

namespace RabbitMQ_Common
{
    public class RabbitMQHelper
    {
        public static IConnection GetConnection()
        {
            var factory = new ConnectionFactory
            {
                HostName = "49.234.95.20",
                Port = 5672,
                UserName = "xiaowu",
                Password = "123456",
                VirtualHost = "/"
            };
            return factory.CreateConnection();
        }
             
    }
}
