using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class Shedule
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

        public virtual Student CreatedByNavigation { get; set; } = null!;
        public virtual Student? DeletedByNavigation { get; set; }
        public virtual Discipline IdDisciplineNavigation { get; set; } = null!;
        public virtual StudentGroup IdGroupNavigation { get; set; } = null!;
        public virtual Homework? IdHomeworkNavigation { get; set; }
    }
}
