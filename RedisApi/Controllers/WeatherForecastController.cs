using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SqlSugar;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private SqlSugarClient db;

        private readonly IDatabase _redis;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, RedisHelper client)
        {
            _logger = logger;
            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = "Server=49.234.95.20;port=3306;database=test;user=root;password=123456",//连接符字串
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            });

            _redis = client.GetDatabase();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]

        [Route("dotask")]
        public string DoTask()
        {

            //var sql = "select stock from test.Xiaowu where id=1";
            //int count = await db.Ado.GetIntAsync(sql);
            //if (count > 0)
            //{
            //    await db.Ado.ExecuteCommandAsync("update test.Xiaowu set Stock =Stock-1 where id=1");
            //    return "success";
            //}
            //else
            //{
            //    return "fail";
            //}
            // var count = "0";

            var num = _redis.StringDecrement("stock");
            if (num < 0)
            {
                return "fail";
            }
            else
            {
                return "success";
            }
        }


        [HttpGet]

        [Route("hashtask")]
        public string Hashtask()
        {

            string hashId = "xiaowu";
            //_redis.HashSet(hashId, "age", 32);
           // _redis.HashSet(hashId, "name", "xiaowu");

            var user = new Student { Id = 1, Name = "xiaowu" };


            _redis.ListRightPush("list", 1);
            //var result = _redis.HashGet(hashId, "age") + _redis.HashGet(hashId, "name");

            var result = "";
            return result;
        }

    }

    public class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
    }
    public class RedisCahce
    {
        public readonly IDatabase Conn;
        public RedisCahce()
        {
            //var muxer = ConnectionMultiplexer.Connect("49.234.95.20:6379");
            var muxer = ConnectionMultiplexer.Connect("127.0.0.1:6379,password=klbr123456");
            Conn = muxer.GetDatabase();
        }
    }
}
