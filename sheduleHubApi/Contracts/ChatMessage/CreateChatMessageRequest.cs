namespace SheduleHubAPI.Contracts.ChatMessage
{
    public class CreateChatMessageRequest
    {
        public int IdSender { get; set; }
        public string TextMessage { get; set; } = null!;
        public int IdStatus { get; set; }
        public DateTime DateMessage { get; set; }
        public int IdChat { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
