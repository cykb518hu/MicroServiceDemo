using StackExchange.Redis;
using System;
using System.Collections.Concurrent;

namespace RedisApi
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
    }

    public class RedisHelper : IDisposable
    {
        private string _connectionString; //�����ַ���
        private string _instanceName; //ʵ������
        private int _defaultDB; //Ĭ�����ݿ�
        private ConcurrentDictionary<string, ConnectionMultiplexer> _connections;
        public RedisHelper(string connectionString, string instanceName, int defaultDB = 0)
        {
            _connectionString = connectionString;
            _instanceName = instanceName;
            _defaultDB = defaultDB;
            _connections = new ConcurrentDictionary<string, ConnectionMultiplexer>();
        }

        /// <summary>
        /// ��ȡConnectionMultiplexer
        /// </summary>
        /// <returns></returns>
        private ConnectionMultiplexer GetConnect()
        {
            return _connections.GetOrAdd(_instanceName, p => ConnectionMultiplexer.Connect(_connectionString));
        }

        /// <summary>
        /// ��ȡ���ݿ�
        /// </summary>
        /// <param name="configName"></param>
        /// <param name="db">Ĭ��Ϊ0�����ȴ����db���ã����config�е�����</param>
        /// <returns></returns>
        public IDatabase GetDatabase()
        {
            return GetConnect().GetDatabase(_defaultDB);
        }

        public IServer GetServer(string configName = null, int endPointsIndex = 0)
        {
            var confOption = ConfigurationOptions.Parse(_connectionString);
            return GetConnect().GetServer(confOption.EndPoints[endPointsIndex]);
        }

        public ISubscriber GetSubscriber(string configName = null)
        {
            return GetConnect().GetSubscriber();
        }

        public void Dispose()
        {
            if (_connections != null && _connections.Count > 0)
            {
                foreach (var item in _connections.Values)
                {
                    item.Close();
                }
            }
        }
    }
}
