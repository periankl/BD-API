using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public RoleController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<StudentRole> role = Context.StudentRoles.ToList();
            return Ok(role);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            StudentRole? role = Context.StudentRoles.Where(x => x.IdRole == id).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(role);
        }

        [HttpPost]

        public IActionResult Add(StudentRole role)
        {
            Context.StudentRoles.Add(role);
            Context.SaveChanges();
            return Ok(role);
        }

        [HttpPut]

        public IActionResult Update(StudentRole role)
        {
            Context.StudentRoles.Update(role);
            Context.SaveChanges();
            return Ok(role);
        }

        [HttpDelete]

        public IActionResult Delete(int roleID)
        {
            StudentRole? role = Context.StudentRoles.Where(x => x.IdRole == roleID).FirstOrDefault();
            if (role == null)
            {
                return BadRequest("Not Found");
            }
            Context.StudentRoles.Remove(role);
            Context.SaveChanges();
            return Ok();
        }
    }
}
