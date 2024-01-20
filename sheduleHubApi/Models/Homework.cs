using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class Homework
    {
        public Homework()
        {
            Shedules = new HashSet<Shedule>();
        }

        public int IdHomework { get; set; }
        public string Task { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Student CreatedByNavigation { get; set; } = null!;
        public virtual Student? DeletedByNavigation { get; set; }
        public virtual ICollection<Shedule> Shedules { get; set; }
    }
}
