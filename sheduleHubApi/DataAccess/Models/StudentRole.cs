using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StudentRole
    {
        public StudentRole()
        {
            Students = new HashSet<Student>();
        }

        public int IdRole { get; set; }
        public string NameRole { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Student? CreatedByNavigation { get; set; } = null!;
        public virtual Student? DeletedByNavigation { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}
