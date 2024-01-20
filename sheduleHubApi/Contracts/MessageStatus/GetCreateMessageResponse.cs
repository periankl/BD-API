namespace SheduleHubAPI.Contracts.MessageStatus
{
    public class GetCreateMessageResponse
    {
        public int IdStatus { get; set; }
        public string NameStatus { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
