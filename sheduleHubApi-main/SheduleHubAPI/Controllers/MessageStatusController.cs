using DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]

        public IActionResult GetAll()
        {
            List<MessageStatus> messageStatus = Context.MessageStatuses.ToList();
            return Ok(messageStatus);
        }

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

        [HttpPost]

        public IActionResult Add(MessageStatus messageStatus)
        {
            Context.MessageStatuses.Add(messageStatus);
            Context.SaveChanges();
            return Ok(messageStatus);
        }

        [HttpPut]

        public IActionResult Update(MessageStatus messageStatus)
        {
            Context.MessageStatuses.Update(messageStatus);
            Context.SaveChanges();
            return Ok(messageStatus);
        }

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
