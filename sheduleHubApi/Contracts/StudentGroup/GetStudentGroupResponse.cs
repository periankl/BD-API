namespace SheduleHubAPI.Contracts.StudentGroup
{
    public class GetStudentGroupResponse
    {
        public int IdGroup { get; set; }
        public string NameGroup { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int CourseNum { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? IdChat { get; set; }
    }
}
