using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Student;
using SheduleHubAPI.Contracts.StudentGroup;

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

        /// <summary>
        /// Получение всех групп
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<StudentGroup> studentGroups = Context.StudentGroups.ToList();
            return Ok(studentGroups);
        }

        /// <summary>
        /// Поиск группы по id
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Добавление группы
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///         POST /Todo
        ///         {
        ///           "nameGroup": "string",
        ///           "idSpeciality": 0,
        ///           "courseNum": 0,
        ///           "createdBy": 0,
        ///           "createdAt": "2024-01-19T08:58:43.790Z"
        ///         }
        ///   
        /// </remarks>
        /// <param name="group"></param>
        /// <returns></returns>

        // Post api/<StudentGroupController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateStudentGroupRequest request)
        {
            var userDto = request.Adapt<StudentGroup>();
            Context.StudentGroups.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение группы
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateStudentGroupRequest request)
        {
            var userDto = request.Adapt<StudentGroup>();
            Context.StudentGroups.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление группы
        /// </summary>
        /// <param name="groupID"></param>
        /// <returns></returns>
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
