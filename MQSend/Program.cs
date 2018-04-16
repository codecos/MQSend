using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MQSend
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                HostName = MQConfig.HostName,
                UserName = MQConfig.UserName,
                Password = MQConfig.Password,
            };

            var task = new Task(() =>
            {
                Send.Queue(factory);
            });

            task.Start();
            Task.WaitAll(task);
            Console.WriteLine("Press [enter] to exit");
            Console.ReadLine();
        }
    }
}
