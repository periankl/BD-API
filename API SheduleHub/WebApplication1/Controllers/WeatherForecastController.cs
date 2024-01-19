using Microsoft.AspNetCore.Mvc;
using WebApplication1;

using System.Linq;

namespace BackendApi.Controllers
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        public static List<Discipline> disciplines = new()
        {
            new Discipline() {IdDiscipline = 1, NameDiscipline = "Программирование",NumCourse = 2, IdSpeciality=1},
            new Discipline() {IdDiscipline = 2, NameDiscipline = "Проектрирование Баз Данных", NumCourse = 3, IdSpeciality=1},
            new Discipline() {IdDiscipline = 7, NameDiscipline = "Учебная практика", NumCourse = 2 , IdSpeciality = 2},
            new Discipline() {IdDiscipline = 15, NameDiscipline = "Разработка мобильных приложений", NumCourse = 1 , IdSpeciality = 2},
            new Discipline() {IdDiscipline = 23, NameDiscipline = "Архитекутра апаратных средств", NumCourse = 1 , IdSpeciality = 2},
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<Discipline> Get()
        {
            return disciplines;
        }

        [HttpPost]

        public IActionResult Add(Discipline data)
        {
            if (data.IdDiscipline < 0)
            {
                return BadRequest("Ошибка: значение поля Id меньше 0.");
            }

            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].IdDiscipline == data.IdDiscipline)
                {
                    return BadRequest("Запись с таким Id уже существует");
                }
            }

            disciplines.Add(data);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Discipline data)
        {
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].IdDiscipline == data.IdDiscipline)
                {
                    disciplines[i] = data;
                    return Ok();
                }
            }

            return BadRequest("Такая запись не существует");
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest("Ошибка: значение поля Id меньше 0.");
            }
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].IdDiscipline == id)
                {
                    disciplines.RemoveAt(i);
                    return Ok();
                }
            }

            return BadRequest("Такая запись не существует");
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            for (int i = 0; i < disciplines.Count; i++)
            {
                if (disciplines[i].IdDiscipline == id)
                {
                    return Ok(disciplines[i]);
                }
            }

            return BadRequest("Такая запись не обнаружена");
        }

        [HttpGet("find-by-name")]

        public IActionResult GetByName(string name)
        {
            foreach (var i in disciplines)
            {
                if (name == i.NameDiscipline)
                {
                    return Ok("Запись с указанной дисциплиной имеется в нашем списке");
                }
            }

            return BadRequest("Запись с указанной дисциплиной не обнаружено");
        }

        [HttpGet("Get-All")]
        public IActionResult GetAll(int? sortStrategy)
        {
            if (sortStrategy == null)
            {
                return Ok();
            }
            else if (sortStrategy == 1)
            {
                disciplines.Sort((d1, d2) => d1.NameDiscipline.CompareTo(d2.NameDiscipline));
                return Ok();
            }
            else if (sortStrategy == -1)
            {
                disciplines.Sort((d1, d2) => d2.NameDiscipline.CompareTo(d1.NameDiscipline));
                return Ok();
            }
            return BadRequest("Некорректное значение параметра sortStrategy");
        }
    }
}