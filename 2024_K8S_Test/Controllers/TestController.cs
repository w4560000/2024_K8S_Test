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
    }
}
