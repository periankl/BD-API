using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public StudentGroupController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<StudentGroup> studentGroups = Context.StudentGroups.ToList();
            return Ok(studentGroups);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int groupID)
        {
            StudentGroup? group = Context.StudentGroups.Where(x => x.IdGroup == groupID).FirstOrDefault();
            if (group == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(group);
        }

        [HttpPost]

        public IActionResult Add(StudentGroup group)
        {
            Context.StudentGroups.Add(group);
            Context.SaveChanges();
            return Ok(group);
        }

        [HttpPut]

        public IActionResult Update(StudentGroup group)
        {
            Context.StudentGroups.Update(group);
            Context.SaveChanges();
            return Ok(group);
        }

        [HttpDelete]

        public IActionResult Delete(int groupID)
        {
            StudentGroup? group = Context.StudentGroups.Where(x => x.IdGroup == groupID).FirstOrDefault();
            if (group == null)
            {
                return BadRequest("Not Found");
            }
            Context.StudentGroups.Remove(group);
            Context.SaveChanges();
            return Ok();
        }
    }
}
