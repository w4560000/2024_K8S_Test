using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net;
using System;

namespace _2024_K8S_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IConfiguration _config;

        public TestController(
            ILogger<TestController> logger,
            IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpGet]
        public object Get()
        {
            return new
            {
                HostName = Dns.GetHostName(),
                HostIP = Dns.GetHostAddresses(Dns.GetHostName()).FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString(),
                Version = _config.GetValue<string>("Env"),
                Test = "demo1"
            };
        }

        [HttpGet(nameof(GetConfigmap))]
        public object GetConfigmap()
        {
            return new
            {
                configmapEnv = Environment.GetEnvironmentVariable("configmap-env"),
                configmapVolume = System.IO.File.ReadAllText("/app/config/setting.json")
            };
        }

        [HttpGet(nameof(GetSecret))]
        public object GetSecret()
        {
            return new
            {
                secretEnv = Environment.GetEnvironmentVariable("secret-env"),
                secretVolume = System.IO.File.ReadAllText("/app/config/config.yaml"),
            };
        }

        [HttpGet(nameof(TestCPU))]
        public string TestCPU()
        {
            void Test()
            {
                while (true)
                {
                }
            }

            List<Task> tasks = new List<Task>();

            for(int i = 0; i < 10; i++)
                tasks.Add(Task.Run(() => Test()));

            return Dns.GetHostName();
        }
    }
}
