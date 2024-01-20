using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Speciality;
using SheduleHubAPI.Contracts.Student;

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

        /// <summary>
        /// Получение всех специальностей
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Speciality> specialities = Context.Specialities.ToList();
            return Ok(specialities);
        }

        /// <summary>
        /// Поиск специальности по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление специальности
        /// </summary>
        /// <remarks>
        /// План заполнение: 
        /// 
        ///         Post /Todo
        ///         {
        ///            "nameSpeciality": "string",
        ///            "createdBy": 0,
        ///            "createdAt": "2024-01-19T08:56:19.871Z"
        ///         }
        /// </remarks>
        /// <param name="speciality"></param>
        /// <returns></returns>
        // Post api/<SpecialityController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateSpecialityRequest request)
        {
            var userDto = request.Adapt<Speciality>();
            Context.Specialities.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение специальности
        /// </summary>
        /// <param name="speciality"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateSpecialityRequest request)
        {
            var userDto = request.Adapt<Speciality>();
            Context.Specialities.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление 
        /// </summary>
        /// <param name="specialityID"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(int specialityID)
        {
            Speciality? speciality = Context.Specialities.Where(x => x.IdSpeciality == specialityID).FirstOrDefault();
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
