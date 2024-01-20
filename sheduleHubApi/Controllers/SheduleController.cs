using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SheduleController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public SheduleController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Shedule> shedule = Context.Shedules.ToList();
            return Ok(shedule);
        }

        [HttpGet("{id}")]

        public IActionResult Get(DateTime date, int lesson_number, int disciplineID)
        {
            Shedule? shedule = Context.Shedules.Where(x => (x.DateShedule == date) && (x.IdDiscipline == disciplineID) && (x.LessNum == lesson_number)).FirstOrDefault();
            if (shedule == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(shedule);
        }

        [HttpPost]

        public IActionResult Add(Shedule shedule)
        {
            Context.Shedules.Add(shedule);
            Context.SaveChanges();
            return Ok(shedule);
        }

        [HttpPut]

        public IActionResult Update(Shedule shedule)
        {
            Context.Shedules.Update(shedule);
            Context.SaveChanges();
            return Ok(shedule);
        }

        [HttpDelete]

        public IActionResult Delete(DateTime date, int lesson_number, int disciplineID)
        {
            Shedule? shedule = Context.Shedules.Where(x => (x.DateShedule == date) && (x.IdDiscipline == disciplineID) && (x.LessNum == lesson_number)).FirstOrDefault();
            if (shedule == null)
            {
                return BadRequest("Not Found");
            }
            Context.Shedules.Remove(shedule);
            Context.SaveChanges();
            return Ok();
        }
    }
}
