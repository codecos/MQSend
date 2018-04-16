using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQSend
{
    public class Send
    {
        public static void Queue(ConnectionFactory factory)
        {
            using (IConnection connection = factory.CreateConnection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.ContinuationTimeout = TimeSpan.FromDays(1.0);
                    channel.QueueDeclare("hello", false, false, false, null);

                    string message = "Hello World!";
                    byte[] body = Encoding.UTF8.GetBytes(message);
                    channel.BasicPublish("", "hello", null, body);
                    Console.WriteLine("Sent{0}", message);

                }
            }
        }
    }
}
