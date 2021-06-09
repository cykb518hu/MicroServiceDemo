using Consul;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_SendEmailService
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri(configuration.GetValue<string>("ConsolHost"));
                c.Datacenter = "dcl";
            });

            string ip = configuration.GetValue<string>("LocalIp");
            int port = configuration.GetValue<int>("LocalPort");
            var http = $"http://{ip}:{port}/SendEmail";
            Console.WriteLine(http);


            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "SendEmailService" + Guid.NewGuid(),
                Name = "SendEmailService",
                Address = ip,
                Port = port,
                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(12),
                    HTTP = http,
                    Timeout = TimeSpan.FromSeconds(5),
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10)
                }
            });
        }
    }
}
