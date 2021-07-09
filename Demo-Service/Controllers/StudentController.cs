using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Demo_Service.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IConfiguration _configuration;

        public StudentController(ILogger<StudentController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        [Authorize]
        [Route("list")]
        public async Task<IList<Student>> GetStudents()
        {
            int port = HttpContext.Connection.LocalPort;
            IList<Student> list = new List<Student>();
            list.Add(new Student { Age = port, Name = "Achilles" });
            list.Add(new Student { Age = port, Name = "Xiaowu" });
            list.Add(new Student { Age = port, Name = "Hu" });
            return list;
        }
        [HttpGet]
        public async Task<Student> Get()
        {
            int port = HttpContext.Connection.LocalPort;
            return new Student { Age = port, Name = "Achilles" };
        }

        //[Route("name")]
        //public string Name()
        //{
        //    var port=_configuration.GetValue<string>("LocalPort");
        //    Thread.Sleep(900);
        //    return $" name method {Guid.NewGuid()}, current port is:{ port}";
        //}

        //[HttpGet]
        //public string Get()
        //{

        //    return $"my name is {Guid.NewGuid()}, current port is:{ Request.Host.Port}";
        //}
    }
    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
