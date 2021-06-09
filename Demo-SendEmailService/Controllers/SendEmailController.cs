using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_SendEmailService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SendEmailController : ControllerBase
    {


        [HttpGet]
        public async Task<string> Get()
        {
            int port = HttpContext.Connection.LocalPort;
            return "send email get and port is:" + port.ToString();
        }

        [HttpPost]
        [Route("DoSthAsync")]
        public async Task<string> DoSthAsync()
        {
            //await Task.Run(() => { Thread.Sleep(1000); });
            return "SendEmail DoSthAsync sleep 1000 ms";
        }
        [HttpPost]
        [Route("DoSth")]
        public  string DoSth()
        {
            //Thread.Sleep(1000);
            return "SendEmail DoSth sleep 1000 ms";
        }
    }

    public class Email
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
