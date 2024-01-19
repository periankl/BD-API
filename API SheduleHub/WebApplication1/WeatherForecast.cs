namespace WebApplication1
{
    public class Discipline
    {
        public int IdDiscipline { get; set; }
        public string NameDiscipline { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int NumCourse { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}