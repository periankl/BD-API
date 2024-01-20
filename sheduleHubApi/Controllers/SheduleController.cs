using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Shedule;
using SheduleHubAPI.Contracts.Student;

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

        /// <summary>
        /// Получение всех расписания
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Shedule> shedule = Context.Shedules.ToList();
            return Ok(shedule);
        }

        /// <summary>
        /// Поиск расписания
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lesson_number"></param>
        /// <param name="disciplineID"></param>
        /// <returns></returns>
        [HttpGet("{date, lesson_number, disciplineID}")]

        public IActionResult Get(DateTime date, int lesson_number, int disciplineID)
        {
            Shedule? shedule = Context.Shedules.Where(x => (x.DateShedule == date) && (x.IdDiscipline == disciplineID) && (x.LessNum == lesson_number)).FirstOrDefault();
            if (shedule == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(shedule);
        }


        /// <summary>
        /// Создание нового расписания
        /// </summary>
        /// <remarks>
        ///     Пример заполнеия:
        ///     
        ///             Post /Todo
        ///             {
        ///                   "dateShedule": "2024-01-19T08:50:44.877Z",
        ///                   "lessNum": 3,
        ///                   "idDiscipline": 1,
        ///                   "idGroup": 1,
        ///                   "idHomework": 319,
        ///                   "cabinet": "28Б",
        ///                   "createdBy": 1,
        ///                   "createdAt": "2024-01-19T08:50:44.877Z",
        ///             }
        ///             
        /// </remarks>
        /// <param name="shedule"></param>
        /// <returns></returns>

        // Post api/<SheduleController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateSheduleRequest request)
        {
            var userDto = request.Adapt<Shedule>();
            Context.Shedules.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение расписания
        /// </summary>
        /// <param name="shedule"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateSheduleRequest request)
        {
            var userDto = request.Adapt<Shedule>();
            Context.Shedules.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление расписания
        /// </summary>
        /// <param name="date"></param>
        /// <param name="lesson_number"></param>
        /// <param name="disciplineID"></param>
        /// <returns></returns>
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
