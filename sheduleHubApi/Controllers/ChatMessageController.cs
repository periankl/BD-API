using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.ChatMessage;
using SheduleHubAPI.Contracts.Student;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatMessageController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public ChatMessageController(SheduleHubContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение всех сообщений
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<ChatMessage> chatMessage = Context.ChatMessages.ToList();
            return Ok(chatMessage);
        }

        /// <summary>
        /// Получение чата по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            ChatMessage? chatMessage = Context.ChatMessages.Where(x => x.IdChat == id).FirstOrDefault();
            if (chatMessage == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(chatMessage);
        }


        /// <summary>
        /// Создание новго сообщения
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///     Post /Todo
        ///     {
        ///         "idSender": 1,
        ///         "textMessage": "C открытием SheduleHub",
        ///         "idStatus": 3,
        ///         "dateMessage": "2024-01-18T00:00:00",
        ///         "idChat": 1,
        ///         "createdBy": 1,
        ///         "createdAt": "2024-01-18T12:15:34.217"
        ///     }
        /// 
        /// </remarks>
        /// <param name="chatMessage"></param>
        /// <returns></returns>

        // Post api/<ChatMessageController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateChatMessageRequest request)
        {
            var userDto = request.Adapt<ChatMessage>();
            Context.ChatMessages.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение существующего сообщения
        /// </summary>
        /// <param name="chatMessage"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(CreateChatMessageRequest request)
        {
            var userDto = request.Adapt<ChatMessage>();
            Context.ChatMessages.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаление сообщения
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(int messageId)
        {
            ChatMessage? chatMessage = Context.ChatMessages.Where(x => x.IdMessage == messageId).FirstOrDefault();
            if (chatMessage == null)
            {
                return BadRequest("Not Found");
            }
            Context.ChatMessages.Remove(chatMessage);
            Context.SaveChanges();
            return Ok();
        }
    }
}
