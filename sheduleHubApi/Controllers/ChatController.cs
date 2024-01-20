using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.Chat;
using SheduleHubAPI.Contracts.Student;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public ChatController(SheduleHubContext context)
        {
            Context = context;
        }


        /// <summary>
        /// Получение всех чатов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Chat> chat = Context.Chats.ToList();
            return Ok(chat);
        }


        /// <summary>
        /// Поиск чата по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            Chat? chat = Context.Chats.Where(x => x.IdChat == id).FirstOrDefault();
            if (chat == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(chat);
        }


        /// <summary>
        /// Добавление чата
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///     Post /Todo
        ///     {    
        ///         "idChat": 1,
        ///         "nameChat": "string",
        ///         "icon": "string",
        ///         "createdBy": 2,
        ///         "createdAt": "2024-01-18T11:44:24.647",
        ///         "studentGroup": null
        ///      }
        ///
        /// </remarks>
        /// <param name="Чат"></param>
        /// <returns></returns>

        // Post api/<ChatController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateChatRequest request)
        {
            var userDto = request.Adapt<Chat>();
            Context.Chats.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение существующего чата
        /// </summary>
        /// <param name="chat"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateChatRequest request)
        {
            var userDto = request.Adapt<Chat>();
            Context.Chats.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }


        /// <summary>
        /// Удаление чата
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(int id)
        {
            Chat? chat = Context.Chats.Where(x => x.IdChat == id).FirstOrDefault();
            if (chat == null)
            {
                return BadRequest("Not Found");
            }
            Context.Chats.Remove(chat);
            Context.SaveChanges();
            return Ok();
        }
    }
}
