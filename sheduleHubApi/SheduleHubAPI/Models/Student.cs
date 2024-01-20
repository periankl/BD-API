using System;
using System.Collections.Generic;

namespace SheduleHubAPI.Models
{
    public partial class Student
    {
        public Student()
        {
            ChatCreatedByNavigations = new HashSet<Chat>();
            ChatDeletedByNavigations = new HashSet<Chat>();
            ChatMessageCreatedByNavigations = new HashSet<ChatMessage>();
            ChatMessageDeletedByNavigations = new HashSet<ChatMessage>();
            ChatUsers = new HashSet<ChatUser>();
            DisciplineCreatedByNavigations = new HashSet<Discipline>();
            DisciplineDeletedByNavigations = new HashSet<Discipline>();
            HomeworkCreatedByNavigations = new HashSet<Homework>();
            HomeworkDeletedByNavigations = new HashSet<Homework>();
            MessageStatusCreatedByNavigations = new HashSet<MessageStatus>();
            MessageStatusDeletedByNavigations = new HashSet<MessageStatus>();
            SheduleCreatedByNavigations = new HashSet<Shedule>();
            SheduleDeletedByNavigations = new HashSet<Shedule>();
            SpecialityCreatedByNavigations = new HashSet<Speciality>();
            SpecialityDeletedByNavigations = new HashSet<Speciality>();
            StudentGroupCreatedByNavigations = new HashSet<StudentGroup>();
            StudentGroupDeletedByNavigations = new HashSet<StudentGroup>();
            StudentRoleCreatedByNavigations = new HashSet<StudentRole>();
            StudentRoleDeletedByNavigations = new HashSet<StudentRole>();
        }

        public int IdStudent { get; set; }
        public string Email { get; set; } = null!;
        public string Pssword { get; set; } = null!;
        public string NameFirst { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int? IdGroup { get; set; }
        public int? IdRole { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual StudentGroup? IdGroupNavigation { get; set; }
        public virtual StudentRole? IdRoleNavigation { get; set; }
        public virtual ICollection<Chat> ChatCreatedByNavigations { get; set; }
        public virtual ICollection<Chat> ChatDeletedByNavigations { get; set; }
        public virtual ICollection<ChatMessage> ChatMessageCreatedByNavigations { get; set; }
        public virtual ICollection<ChatMessage> ChatMessageDeletedByNavigations { get; set; }
        public virtual ICollection<ChatUser> ChatUsers { get; set; }
        public virtual ICollection<Discipline> DisciplineCreatedByNavigations { get; set; }
        public virtual ICollection<Discipline> DisciplineDeletedByNavigations { get; set; }
        public virtual ICollection<Homework> HomeworkCreatedByNavigations { get; set; }
        public virtual ICollection<Homework> HomeworkDeletedByNavigations { get; set; }
        public virtual ICollection<MessageStatus> MessageStatusCreatedByNavigations { get; set; }
        public virtual ICollection<MessageStatus> MessageStatusDeletedByNavigations { get; set; }
        public virtual ICollection<Shedule> SheduleCreatedByNavigations { get; set; }
        public virtual ICollection<Shedule> SheduleDeletedByNavigations { get; set; }
        public virtual ICollection<Speciality> SpecialityCreatedByNavigations { get; set; }
        public virtual ICollection<Speciality> SpecialityDeletedByNavigations { get; set; }
        public virtual ICollection<StudentGroup> StudentGroupCreatedByNavigations { get; set; }
        public virtual ICollection<StudentGroup> StudentGroupDeletedByNavigations { get; set; }
        public virtual ICollection<StudentRole> StudentRoleCreatedByNavigations { get; set; }
        public virtual ICollection<StudentRole> StudentRoleDeletedByNavigations { get; set; }
    }
}
