using Microsoft.AspNetCore.Mvc;

namespace WebApiTesst.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summeries = new()
        {
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<string> Get()
        {
            return Summeries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summeries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summeries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }

            Summeries[index] = name;
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int index)
        {
            if (index < 0 || index >= Summeries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }

            Summeries.RemoveAt(index);
            return Ok();
        }

        [HttpGet("{index}")]
        public IActionResult GetAtIndex(int index)
        {
            if (index < 0 || index >= Summeries.Count)
            {
                return BadRequest("Такой индекс неверный!");
            }

            string name = Summeries[index];
            return Ok(name);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            string[] res = new string[Summeries.Count];
            for (int i = 0; i < Summeries.Count; i++)
            {
                if (Summeries[i].ToLower().Contains(name.ToLower()))
                {
                    res[i] = Summeries[i];
                }
            }
            res = res.Where(x => x != null).ToArray();
            return Ok(res);
        }

        [HttpGet("SortStrategy")]
        public IActionResult GetAll(int? SortStrategy)
        {
            if (!SortStrategy.HasValue)
            {
                return Ok(Summeries);
            }
            else if (SortStrategy.Value == 1)
            {
                Summeries.Sort();
                return Ok(Summeries);
            }
            else if (SortStrategy.Value == -1)
            {
                Summeries.Sort();
                Summeries.Reverse();
                return Ok(Summeries);
            }
            else
            {
                return BadRequest("Некорректное значение параметра sortStrategy");
            }
        }
    }
}