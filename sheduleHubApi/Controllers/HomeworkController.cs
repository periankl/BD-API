using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Homework;
using SheduleHubAPI.Contracts.Student;

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

        /// <summary>
        /// Получение всех домашних работ
        /// </summary>
        /// <returns></returns>

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Homework> homework = Context.Homeworks.ToList();
            return Ok(homework);
        }

        /// <summary>
        /// Получение домашней работы по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление нового домашнего задания
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///     Post /Todo
        ///     {
        ///          "task": "string",
        ///          "createdBy": 0,
        ///          "createdAt": "2024-01-19T08:41:15.690Z"
        ///      }
        ///      
        /// </remarks>
        /// <param name="homework"></param>
        /// <returns></returns>
        // Post api/<HomeworkController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateHomeworkRequest request)
        {
            var userDto = request.Adapt<Homework>();
            Context.Homeworks.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение домашней работы
        /// </summary>
        /// <param name="homework"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateHomeworkRequest request)
        {
            var userDto = request.Adapt<Homework>();
            Context.Homeworks.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление домашней работы
        /// </summary>
        /// <param name="homeworkId"></param>
        /// <returns></returns>
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
