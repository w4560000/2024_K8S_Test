using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Net;

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
                Version = _config.GetValue<string>("Env")
            };
        }

        [HttpGet(nameof(GetPwd))]
        public string GetPwd()
        {
            return Environment.GetEnvironmentVariable("Pwd") ?? "not found";
        }

        [HttpGet(nameof(GetSetting))]
        public string GetSetting()
        {
            try
            {
                FileStream fileStream = new FileStream("/app/setting.json", FileMode.Open);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    return reader.ReadLine();
                }
            }
            catch(Exception ex)
            {
                return $"not found, error: {ex}";
            }
        }
    }
}
