namespace SheduleHubAPI.Contracts.Shedule
{
    public class GetSheduleResponse
    {
        public DateTime DateShedule { get; set; }
        public int LessNum { get; set; }
        public int IdDiscipline { get; set; }
        public int IdGroup { get; set; }
        public int? IdHomework { get; set; }
        public string Cabinet { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
