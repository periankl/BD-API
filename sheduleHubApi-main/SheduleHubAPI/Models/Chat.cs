using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class Chat
    {
        public Chat()
        {
            ChatMessages = new HashSet<ChatMessage>();
            ChatUsers = new HashSet<ChatUser>();
            StudentGroups = new HashSet<StudentGroup>();
        }

        public int IdChat { get; set; }
        public string NameChat { get; set; } = null!;
        public string Icon { get; set; } = null!;
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Student CreatedByNavigation { get; set; } = null!;
        public virtual Student? DeletedByNavigation { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
