using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.ChatUser;
using SheduleHubAPI.Contracts.Student;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatUserController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public ChatUserController(SheduleHubContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Получение всех пользователей чатов
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<ChatUser> specialities = Context.ChatUsers.ToList();
            return Ok(specialities);
        }

        /// <summary>
        /// Получение пользователя из чата (chatID, userID)
        /// </summary>
        /// <remarks>
        /// Пример заполнения: 
        /// 1,1
        /// </remarks>
        /// <param name="chatID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult Get(int chatID, int userID)
        {
            ChatUser? chat = Context.ChatUsers.Where(x => (x.IdChat == chatID) && (x.IdStudent == userID)).FirstOrDefault();
            if (chat == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(chat);
        }

        /// <summary>
        /// Добавление пользователя в чат
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///     Post /Todo
        ///     { 
        ///           "idStudent": 0,
        ///           "idChat": 0,
        ///           "joinAt": "2024-01-19T08:35:25.251Z"
        ///     }
        ///     
        /// </remarks>
        /// <param name="chatUser"></param>
        /// <returns></returns>

        // Post api/<ChatUserController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateChatUserRequest request)
        {
            var userDto = request.Adapt<ChatUser>();
            Context.ChatUsers.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Обновление пользователей чата
        /// </summary>
        /// <param name="chatUser"></param>
        /// <returns></returns>
        [HttpPut]


        public async Task<IActionResult> Update(CreateChatUserRequest request)
        {
            var userDto = request.Adapt<ChatUser>();
            Context.ChatUsers.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление пользователя из чата
        /// </summary>
        /// <param name="chatID"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(int chatID, int userID)
        {
            ChatUser? chat = Context.ChatUsers.Where(x => (x.IdChat == chatID) && (x.IdStudent == userID)).FirstOrDefault();
            if (chat == null)
            {
                return BadRequest("Not Found");
            }
            Context.ChatUsers.Remove(chat);
            Context.SaveChanges();
            return Ok();
        }
    }
}
