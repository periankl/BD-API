using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplinesController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public DisciplinesController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Discipline> disciplines = Context.Disciplines.ToList();
            return Ok(disciplines);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Discipline? discipline = Context.Disciplines.Where(x => x.IdDiscipline == id).FirstOrDefault();
            if (discipline == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(discipline);
        }

        [HttpPost]

        public IActionResult Add(Discipline discipline)
        {
            Context.Disciplines.Add(discipline);
            Context.SaveChanges();
            return Ok(discipline);
        }

        [HttpPut]

        public IActionResult Update(Discipline discipline)
        {
            Context.Disciplines.Update(discipline);
            Context.SaveChanges();
            return Ok(discipline);
        }

        [HttpDelete]

        public IActionResult Delete(int disciplineID)
        {
            Discipline? discipline = Context.Disciplines.Where(x => x.IdDiscipline == disciplineID).FirstOrDefault();
            if (discipline == null)
            {
                return BadRequest("Not Found");
            }
            Context.Disciplines.Remove(discipline);
            Context.SaveChanges();
            return Ok();
        }
    }
}
