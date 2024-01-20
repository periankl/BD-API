namespace SheduleHubAPI.Contracts.Homework
{
    public class GetHomeworkResponse
    {
        public int IdHomework { get; set; }
        public string Task { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
