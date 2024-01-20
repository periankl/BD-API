using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Student;
using SheduleHubAPI.Contracts.StudentRole;

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


        /// <summary>
        /// Получение всех ролей пользовталей
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<StudentRole> role = Context.StudentRoles.ToList();
            return Ok(role);
        }

        /// <summary>
        /// Получение роли по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса: 
        /// 
        ///     Post /Todo
        ///     { 
        ///           "nameRole": "string",
        ///           "createdBy": 0,
        ///           "createdAt": "2024-01-19T09:08:17.851Z"
        ///      }
        ///     
        /// </remarks>
        /// <param name="Роль"></param>
        /// <returns></returns>

        // Post api/<RoleController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateStudentRoleRequest request)
        {
            var userDto = request.Adapt<StudentRole>();
            Context.StudentRoles.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Изменение роли
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateStudentRoleRequest request)
        {
            var userDto = request.Adapt<StudentRole>();
            Context.StudentRoles.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="roleID"></param>
        /// <returns></returns>
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
