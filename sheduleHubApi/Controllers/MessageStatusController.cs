using DataAccess.Models;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SheduleHubAPI.Contracts.MessageStatus;
using SheduleHubAPI.Contracts.Student;

namespace SheduleHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageStatusController : ControllerBase
    {
        public SheduleHubContext Context { get; }

        public MessageStatusController(SheduleHubContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Получение статусов сообщений
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public IActionResult GetAll()
        {
            List<MessageStatus> messageStatus = Context.MessageStatuses.ToList();
            return Ok(messageStatus);
        }

        /// <summary>
        /// Получение статуса сообщения по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            MessageStatus? messageStatus = Context.MessageStatuses.Where(x => x.IdStatus == id).FirstOrDefault();
            if (messageStatus == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(messageStatus);
        }

        /// <summary>
        /// Добавление нового статуса сообщения
        /// </summary>
        /// <remarks>
        /// Пример заполнения:
        /// 
        ///         Post /Todo
        ///         {
        ///            "nameStatus": "string",
        ///            "createdBy": 0,
        ///            "createdAt": "2024-01-19T08:43:51.471Z"
        ///          }
        /// </remarks>
        /// <param name="Статус сообщения"></param>
        /// <returns></returns>

        // Post api/<MessageStatusController>
        [HttpPost]

        public async Task<IActionResult> Add(CreateMessageStatusRequest request)
        {
            var userDto = request.Adapt<MessageStatus>();
            Context.MessageStatuses.Add(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Изменение сообщения
        /// </summary>
        /// <param name="messageStatus"></param>
        /// <returns></returns>
        [HttpPut]

        public async Task<IActionResult> Update(CreateMessageStatusRequest request)
        {
            var userDto = request.Adapt<MessageStatus>();
            Context.MessageStatuses.Update(userDto);
            Context.SaveChanges();
            return Ok();
        }

        /// <summary>
        /// Удаления сообщения
        /// </summary>
        /// <param name="messageStatusId"></param>
        /// <returns></returns>
        [HttpDelete]

        public IActionResult Delete(int messageStatusId)
        {
            MessageStatus? messageStatus = Context.MessageStatuses.Where(x => x.IdStatus == messageStatusId).FirstOrDefault();
            if (messageStatus == null)
            {
                return BadRequest("Not Found");
            }
            Context.MessageStatuses.Remove(messageStatus);
            Context.SaveChanges();
            return Ok();
        }
    }
}
