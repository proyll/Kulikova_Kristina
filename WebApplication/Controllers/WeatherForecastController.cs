using Microsoft.AspNetCore.Mvc;

namespace WebApiTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("sortStrategy")]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy.HasValue)
            {
                return Ok(Summaries);
            }

            else if (sortStrategy.Value == 1)
            {
                Summaries.Sort();
                return Ok(Summaries);
            }

            else if (sortStrategy.Value == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok(Summaries);
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summaries;
        }
        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!!");
            }
            Summaries[index] = name;
            return Ok();
        }
        [HttpGet("{index}")]
        public IActionResult Name(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Такой индекс неверный!!!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpGet("name")]
        public IActionResult GetByName(string name)
        {
            string[] res = new string[Summaries.Count];
            for (int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i].ToLower().Contains(name.ToLower()))
                {
                    res[i] = Summaries[i];
                }
            }
            res = res.Where(x => x != null).ToArray();
            return Ok(res);
        }
    }
}