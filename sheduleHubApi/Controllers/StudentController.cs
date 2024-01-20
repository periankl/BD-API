using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public StudentController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Student> students = Context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Student? student = Context.Students.Where(x => x.IdStudent == id).FirstOrDefault();
            if (student == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(student);
        }

        [HttpPost]

        public IActionResult Add(Student student)
        {
            Context.Students.Add(student);
            Context.SaveChanges();
            return Ok(student);
        }

        [HttpPut]

        public IActionResult Update(Student student)
        {
            Context.Students.Update(student);
            Context.SaveChanges();
            return Ok(student);
        }

        [HttpDelete]

        public IActionResult Delete(int id)
        {
            Student? student = Context.Students.Where(x => x.IdStudent == id).FirstOrDefault();
            if (student == null)
            {
                return BadRequest("Not Found");
            }
            Context.Students.Remove(student);
            Context.SaveChanges();
            return Ok();
        }
    }
}
