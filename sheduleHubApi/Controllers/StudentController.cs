using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Student;

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
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<Student> students = Context.Students.ToList();
            return Ok(students);
        }
        /// <summary>
        /// Поиск пользователя по id
        /// </summary>
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



        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        /// 
        ///     Post /Todo
        ///     { 
        ///        "email": "string",
        ///        "pssword": "string",
        ///        "nameFirst": "string",
        ///        "surname": "string",
        ///        "patronymic": "string",
        ///        "birthDate": "2024-01-19T08:04:39.556Z",
        ///        "idGroup": 0,
        ///        "idRole": 0,
        ///        "createdBy": 0,
        ///        "createdAt": "2024-01-19T08:04:39.556Z"
        ///      }
        ///     
        /// </remarks>
        /// <param name="Пользователь"></param>
        /// <returns></returns>

        // Post api/<StudentController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateStudentRequest request)
        {
            var userDto = request.Adapt<Student>();
            Context.Students.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение пользователя
        /// </summary>
        [HttpPut]

        public async Task<IActionResult> Update(CreateStudentRequest request)
        {
            var userDto = request.Adapt<Student>();
            Context.Students.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
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
