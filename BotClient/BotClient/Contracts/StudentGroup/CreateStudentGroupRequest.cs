using System;

namespace SheduleHubAPI.Contracts.StudentGroup
{
    public class CreateStudentGroupRequest
    {
        public string NameGroup { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int CourseNum { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? IdChat { get; set; }
    }
}
