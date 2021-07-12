using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ_Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RabbitMQ_Provider.Normal
{
    class Send
    {

        public static void SendMessage()
        {
            string queueName = "normal";
            using(var connection = RabbitMQHelper.GetConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    while (true)
                    {
                        string message = "hellow rabbitmq";
                        var body = Encoding.UTF8.GetBytes(message);
                        channel.BasicPublish("", queueName, false, null, body);
                        Thread.Sleep(1000);
                        Console.WriteLine("send message end");
                    }
                }
            }
        }

        public static void ReveiveMessage()
        {
            string queueName = "normal";
            using (var connection = RabbitMQHelper.GetConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);
                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Console.WriteLine($"get message{message}");
                    };
                    channel.BasicConsume(queueName, true, consumer);
                }
            }
        }
    }
}
