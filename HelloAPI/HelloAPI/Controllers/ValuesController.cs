using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HelloAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly UISetting _uISetting;
        private readonly ILogger<ValuesController> _logger;
        public ValuesController(IOptions<UISetting> options, ILogger<ValuesController> logger)
        {
            _uISetting = options.Value;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            Console.WriteLine(_uISetting.FontFamily);
            _logger.LogInformation("这是一条测试日志");
           return $"请求时id的值为:{id}";
        }
    }
}
