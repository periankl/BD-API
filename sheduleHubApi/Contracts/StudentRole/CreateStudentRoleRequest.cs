namespace SheduleHubAPI.Contracts.StudentRole
{
    public class CreateStudentRoleRequest
    {
        public string NameRole { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
