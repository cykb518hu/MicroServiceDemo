using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpGet]
        public async Task<string> Get()
        {
            int port = HttpContext.Connection.LocalPort;
            return "send email get and port is:" + port.ToString();
        }

        [HttpGet]
        [Route("get1")]
        public async Task<string> Get1()
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

        [Authorize]
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
