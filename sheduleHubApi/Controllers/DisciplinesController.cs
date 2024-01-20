using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Discipline;
using SheduleHubAPI.Contracts.Student;

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


        /// <summary>
        /// Получение всех дисциплин
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Discipline> disciplines = Context.Disciplines.ToList();
            return Ok(disciplines);
        }


        /// <summary>
        /// Получение дисциплины по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление дисциплины
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///         Post /Todo
        ///         {  
        ///             "nameDiscipline": "string",
        ///             "idSpeciality": 0,
        ///             "numCourse": 0,
        ///             "createdBy": 0,
        ///             "createdAt": "2024-01-19T08:36:34.725Z"
        ///          }
        ///   
        /// </remarks>
        /// <param name="discipline"></param>
        /// <returns></returns>
        // Post api/<DisciplinesController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateDisciplineRequest request)
        {
            var userDto = request.Adapt<Discipline>();
            Context.Disciplines.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение дисциплины
        /// </summary>
        /// <param name="discipline"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateDisciplineRequest request)
        {
            var userDto = request.Adapt<Discipline>();
            Context.Disciplines.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление дициплины
        /// </summary>
        /// <param name="disciplineID"></param>
        /// <returns></returns>
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
