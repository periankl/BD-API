namespace SheduleHubAPI.Contracts.Chat
{
    public class CreateChatRequest
    {
        public string NameChat { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
