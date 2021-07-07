using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            Show();

            Console.ReadLine();
        }

        static void Show()
        {
            RedisCahce redisCahce = new RedisCahce();

            
            Console.WriteLine("==========start==============");

            //redisCahce.Conn.StringSet("achilles", "111", TimeSpan.FromSeconds(1));
            //Console.WriteLine(redisCahce.Conn.StringGet("achilles"));
            //Task.Delay(1 * 1000).Wait();


            //Console.WriteLine(redisCahce.Conn.StringGet("achilles"));


            Console.WriteLine(redisCahce.Conn.StringIncrement("achilles"));
            Console.WriteLine(redisCahce.Conn.StringIncrement("achilles"));
            Console.WriteLine(redisCahce.Conn.StringIncrement("achilles"));

            Console.WriteLine(redisCahce.Conn.StringIncrement("achilles",5));

            Console.WriteLine(redisCahce.Conn.StringDecrement("achilles"));
            Console.WriteLine(redisCahce.Conn.StringDecrement("achilles",2));
            Console.WriteLine(redisCahce.Conn.StringGet("achilles"));

            

            Console.WriteLine("==========end==============");
        }
    }

    public class RedisCahce 
    {
        public readonly IDatabase Conn;
        public RedisCahce()
        {
            var muxer = ConnectionMultiplexer.Connect("49.234.95.20:6379");
            Conn = muxer.GetDatabase();
        }

        //public T Get<T>(string key)
        //{

        //    T result = default(T);
        //    var str = _conn.StringGet(key);
        //    if (string.IsNullOrWhiteSpace(str))
        //    {

        //    }
        //    else
        //    {
        //        result = JsonConvert.DeserializeObject<T>(str);
        //    }
        //    return result;
        //}

        //public void Set<T>(string key, T data)
        //{
        //    TimeSpan ts = new TimeSpan(0, 10, 0);
        //    if (data != null)
        //    {
        //        _conn.
        //        _conn.StringSet(key, str, ts);
        //    }

        //}
    }
}
