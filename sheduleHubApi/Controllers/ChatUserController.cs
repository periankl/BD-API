using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]

        public IActionResult GetAll()
        {
            List<ChatUser> specialities = Context.ChatUsers.ToList();
            return Ok(specialities);
        }

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

        [HttpPost]

        public IActionResult Add(ChatUser chatUser)
        {
            Context.ChatUsers.Add(chatUser);
            Context.SaveChanges();
            return Ok(chatUser);
        }

        [HttpPut]

        public IActionResult Update(ChatUser chatUser)
        {
            Context.ChatUsers.Update(chatUser);
            Context.SaveChanges();
            return Ok(chatUser);
        }

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
