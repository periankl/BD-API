namespace SheduleHubAPI.Contracts.Discipline
{
    public class CreateDisciplineRequest
    {
        public string NameDiscipline { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int NumCourse { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
