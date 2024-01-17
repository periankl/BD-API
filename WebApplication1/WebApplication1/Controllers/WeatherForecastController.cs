using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
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
                return BadRequest("Индекс неверный!!!");
            }
            Summaries.RemoveAt(index);
            return Ok();
        }
        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if(index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Индекс неверный!!!");
            }

            Summaries[index] = name;
            return Ok();
        }
        [HttpGet("{index}")]
        public  string Get(int index)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return "Индекс неверный!";
            }
            return Summaries[index];
        }

        [HttpGet("find-by-name")]
        public int FindByName(string name)
        {
            int count = 0;
            for(int i = 0; i < Summaries.Count; i++)
            {
                if (Summaries[i] == name)
                {
                    count++;
                }
            }
            return count;
        }
        [HttpGet("Sort")]
        public IActionResult Getall(int? sortStrategy)
        {
            if(!sortStrategy.HasValue)
            {
                return Ok();

            }
            else if (sortStrategy == 1)
            {
                Summaries.Sort();
                return Ok();
            }
            else if(sortStrategy == -1)
            {
                Summaries.Sort();
                Summaries.Reverse();
                return Ok();
            }
            else
            {
                return BadRequest("Индекс неверный!");
            }

        }

    }
}