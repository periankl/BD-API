using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]

        public IActionResult GetAll()
        {
            List<ChatMessage> chatMessage = Context.ChatMessages.ToList();
            return Ok(chatMessage);
        }

        [HttpGet("{id}")]

        public IActionResult Get(int id)
        {
            ChatMessage? chatMessage = Context.ChatMessages.Where(x => x.IdChat == id).FirstOrDefault();
            if (chatMessage== null)
            {
                return BadRequest("Not Found");
            }
            return Ok(chatMessage);
        }

        [HttpPost]

        public IActionResult Add(ChatMessage chatMessage)
        {
            Context.ChatMessages.Add(chatMessage);
            Context.SaveChanges();
            return Ok(chatMessage);
        }

        [HttpPut]

        public IActionResult Update(ChatMessage chatMessage)
        {
            Context.ChatMessages.Update(chatMessage);
            Context.SaveChanges();
            return Ok(chatMessage);
        }

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
