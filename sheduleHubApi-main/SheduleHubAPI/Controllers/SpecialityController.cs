using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public SpecialityController(SheduleHubContext context)
        {
            Context = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Speciality> specialities = Context.Specialities.ToList();
            return Ok(specialities);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Speciality? speciality = Context.Specialities.Where(x => x.IdSpeciality == id).FirstOrDefault();
            if (speciality == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(speciality);
        }

        [HttpPost]

        public IActionResult Add(Speciality speciality)
        {
            Context.Specialities.Add(speciality);
            Context.SaveChanges();
            return Ok(speciality);
        }

        [HttpPut]

        public IActionResult Update(Speciality speciality)
        {
            Context.Specialities.Update(speciality);
            Context.SaveChanges();
            return Ok(speciality);
        }

        [HttpDelete]

        public IActionResult Delete(int roleID)
        {
            Speciality? speciality = Context.Specialities.Where(x => x.IdSpeciality == roleID).FirstOrDefault();
            if (speciality == null)
            {
                return BadRequest("Not Found");
            }
            Context.Specialities.Remove(speciality);
            Context.SaveChanges();
            return Ok();
        }
    }
}
