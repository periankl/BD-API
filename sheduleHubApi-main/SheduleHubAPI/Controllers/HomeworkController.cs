using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public HomeworkController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Homework> homework = Context.Homeworks.ToList();
            return Ok(homework);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Homework? homework = Context.Homeworks.Where(x => x.IdHomework == id).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(homework);
        }

        [HttpPost]

        public IActionResult Add(Homework homework)
        {
            Context.Homeworks.Add(homework);
            Context.SaveChanges();
            return Ok(homework);
        }

        [HttpPut]

        public IActionResult Update(Homework homework)
        {
            Context.Homeworks.Update(homework);
            Context.SaveChanges();
            return Ok(homework);
        }

        [HttpDelete]

        public IActionResult Delete(int homeworkId)
        {
            Homework? homework = Context.Homeworks.Where(x => x.IdHomework == homeworkId).FirstOrDefault();
            if (homework == null)
            {
                return BadRequest("Not Found");
            }
            Context.Homeworks.Remove(homework);
            Context.SaveChanges();
            return Ok();
        }
    }
}
