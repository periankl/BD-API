namespace SheduleHubAPI.Contracts.Speciality
{
    public class GetSpecialityResponse
    {
        public int IdSpeciality { get; set; }
        public string NameSpeciality { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
