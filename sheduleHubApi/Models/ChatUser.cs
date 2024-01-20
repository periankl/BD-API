using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class ChatUser
    {
        public int IdStudent { get; set; }
        public int IdChat { get; set; }
        public DateTime JoinAt { get; set; }
        public DateTime? RemoveAt { get; set; }

        public virtual Chat IdChatNavigation { get; set; } = null!;
        public virtual Student IdStudentNavigation { get; set; } = null!;
    }
}
