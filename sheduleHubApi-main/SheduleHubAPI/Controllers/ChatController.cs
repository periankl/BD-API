using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]

        public IActionResult GetAll()
        {
            List<Chat> chat = Context.Chats.ToList();
            return Ok(chat);
        }

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

        [HttpPost]

        public IActionResult Add(Chat chat)
        {
            Context.Chats.Add(chat);
            Context.SaveChanges();
            return Ok(chat);
        }

        [HttpPut]

        public IActionResult Update(Chat chat)
        {
            Context.Chats.Update(chat);
            Context.SaveChanges();
            return Ok(chat);
        }

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
