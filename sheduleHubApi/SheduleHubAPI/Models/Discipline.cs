using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class Discipline
    {
        public Discipline()
        {
            Shedules = new HashSet<Shedule>();
        }

        public int IdDiscipline { get; set; }
        public string NameDiscipline { get; set; } = null!;
        public int IdSpeciality { get; set; }
        public int NumCourse { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Student CreatedByNavigation { get; set; } = null!;
        public virtual Student? DeletedByNavigation { get; set; }
        public virtual ICollection<Shedule> Shedules { get; set; }
    }
}
