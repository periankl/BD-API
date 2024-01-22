namespace SheduleHubAPI.Contracts.Homework
{
    public class CreateHomeworkRequest
    {
        public string Task { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
