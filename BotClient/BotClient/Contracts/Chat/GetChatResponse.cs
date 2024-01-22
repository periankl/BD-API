namespace SheduleHubAPI.Contracts.Chat
{
    public class GetChatResponse
    {
        public int IdChat { get; set; }
        public string NameChat { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
