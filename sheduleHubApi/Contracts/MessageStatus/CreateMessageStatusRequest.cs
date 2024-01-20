namespace SheduleHubAPI.Contracts.MessageStatus
{
    public class CreateMessageStatusRequest
    {
        public string NameStatus { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
