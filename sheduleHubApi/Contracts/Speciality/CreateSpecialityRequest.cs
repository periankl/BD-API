namespace SheduleHubAPI.Contracts.Speciality
{
    public class CreateSpecialityRequest
    {
        public string NameSpeciality { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
