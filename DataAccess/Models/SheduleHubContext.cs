using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class SheduleHubContext : DbContext
    {
        public SheduleHubContext()
        {
        }

        public SheduleHubContext(DbContextOptions<SheduleHubContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chats { get; set; } = null!;
        public virtual DbSet<ChatMessage> ChatMessages { get; set; } = null!;
        public virtual DbSet<ChatUser> ChatUsers { get; set; } = null!;
        public virtual DbSet<Discipline> Disciplines { get; set; } = null!;
        public virtual DbSet<Homework> Homeworks { get; set; } = null!;
        public virtual DbSet<MessageStatus> MessageStatuses { get; set; } = null!;
        public virtual DbSet<Shedule> Shedules { get; set; } = null!;
        public virtual DbSet<Speciality> Specialities { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<StudentGroup> StudentGroups { get; set; } = null!;
        public virtual DbSet<StudentRole> StudentRoles { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.IdChat)
                    .HasName("PK__Chat__68D484D14A922EE8");

                entity.ToTable("Chat");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.Icon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("icon");

                entity.Property(e => e.NameChat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_chat");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat__deleted_at__59FA5E80");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ChatDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Chat__deleted_by__5AEE82B9");
            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Chat_Mes__460F3CF454BF9ED1");

                entity.ToTable("Chat_Message");

                entity.Property(e => e.IdMessage).HasColumnName("id_message");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DateMessage)
                    .HasColumnType("date")
                    .HasColumnName("date_message");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.IdSender).HasColumnName("id_sender");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.TextMessage)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("text_message");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ChatMessageCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat_Mess__creat__5FB337D6");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.ChatMessageDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Chat_Mess__delet__60A75C0F");

                entity.HasOne(d => d.IdChatNavigation)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.IdChat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat_Mess__id_ch__5EBF139D");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.ChatMessages)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat_Mess__delet__5DCAEF64");
            });

            modelBuilder.Entity<ChatUser>(entity =>
            {
                entity.HasKey(e => new { e.IdStudent, e.IdChat })
                    .HasName("PK__Chat_Use__2D6FA3FB1FD96D08");

                entity.ToTable("Chat_User");

                entity.Property(e => e.IdStudent).HasColumnName("id_student");

                entity.Property(e => e.IdChat).HasColumnName("id_chat");

                entity.Property(e => e.JoinAt)
                    .HasColumnType("date")
                    .HasColumnName("join_at");

                entity.Property(e => e.RemoveAt)
                    .HasColumnType("date")
                    .HasColumnName("remove_at");

                entity.HasOne(d => d.IdChatNavigation)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.IdChat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat_User__id_ch__6477ECF3");

                entity.HasOne(d => d.IdStudentNavigation)
                    .WithMany(p => p.ChatUsers)
                    .HasForeignKey(d => d.IdStudent)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Chat_User__remov__6383C8BA");
            });

            modelBuilder.Entity<Discipline>(entity =>
            {
                entity.HasKey(e => e.IdDiscipline)
                    .HasName("PK__Discipli__3E5AFB67E894B605");

                entity.ToTable("Discipline");

                entity.Property(e => e.IdDiscipline).HasColumnName("id_discipline");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdSpeciality).HasColumnName("id_speciality");

                entity.Property(e => e.NameDiscipline)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_discipline");

                entity.Property(e => e.NumCourse).HasColumnName("num_course");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.DisciplineCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Disciplin__delet__4BAC3F29");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.DisciplineDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Disciplin__delet__4CA06362");
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(e => e.IdHomework)
                    .HasName("PK__Homework__A489584AA682F93B");

                entity.ToTable("Homework");

                entity.Property(e => e.IdHomework).HasColumnName("id_homework");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.Task)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("task");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.HomeworkCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Homework__delete__47DBAE45");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.HomeworkDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Homework__delete__48CFD27E");
            });

            modelBuilder.Entity<MessageStatus>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__Message___5D2DC6E846D48210");

                entity.ToTable("Message_Status");

                entity.Property(e => e.IdStatus).HasColumnName("id_status");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.NameStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_status");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.MessageStatusCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message_S__delet__5629CD9C");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.MessageStatusDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Message_S__delet__571DF1D5");
            });

            modelBuilder.Entity<Shedule>(entity =>
            {
                entity.HasKey(e => new { e.DateShedule, e.LessNum, e.IdDiscipline, e.IdGroup })
                    .HasName("PK__Shedule__0CD1F4FE4FE2BACA");

                entity.ToTable("Shedule");

                entity.Property(e => e.DateShedule)
                    .HasColumnType("date")
                    .HasColumnName("date_shedule");

                entity.Property(e => e.LessNum).HasColumnName("less_num");

                entity.Property(e => e.IdDiscipline).HasColumnName("id_discipline");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.Cabinet)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cabinet");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdHomework).HasColumnName("id_homework");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SheduleCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shedule__created__52593CB8");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.SheduleDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK__Shedule__deleted__534D60F1");

                entity.HasOne(d => d.IdDisciplineNavigation)
                    .WithMany(p => p.Shedules)
                    .HasForeignKey(d => d.IdDiscipline)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shedule__deleted__4F7CD00D");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Shedules)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Shedule__id_grou__5165187F");

                entity.HasOne(d => d.IdHomeworkNavigation)
                    .WithMany(p => p.Shedules)
                    .HasForeignKey(d => d.IdHomework)
                    .HasConstraintName("FK__Shedule__id_home__5070F446");
            });

            modelBuilder.Entity<Speciality>(entity =>
            {
                entity.HasKey(e => e.IdSpeciality)
                    .HasName("PK__Speciali__CF97EB98FDE15F7A");

                entity.ToTable("Speciality");

                entity.Property(e => e.IdSpeciality).HasColumnName("id_speciality");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.NameSpeciality)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_speciality");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.SpecialityCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Speciality_CreatedBy");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.SpecialityDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Speciality_DeletedBy");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PK__Student__2BE2EBB6D0E7DC05");

                entity.ToTable("Student");

                entity.Property(e => e.IdStudent).HasColumnName("id_student");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("date")
                    .HasColumnName("birth_date");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.NameFirst)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_first");

                entity.Property(e => e.Patronymic)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("patronymic");

                entity.Property(e => e.Pssword)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pssword");

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surname");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdGroup)
                    .HasConstraintName("FK__Student__id_grou__3E52440B");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK__Student__id_role__3F466844");
            });

            modelBuilder.Entity<StudentGroup>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PK__Student___8BE8BA1B05D8CF0A");

                entity.ToTable("Student_Group");

                entity.Property(e => e.IdGroup).HasColumnName("id_group");

                entity.Property(e => e.CourseNum).HasColumnName("course_num");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.IdChat)
                      .HasColumnName("id_chat");

                entity.HasOne(d => d.Chat)
                      .WithMany(p => p.StudentGroup)
                      .HasForeignKey(d => d.IdChat)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK_Student_Group_Student_Chat");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.IdSpeciality).HasColumnName("id_speciality");

                entity.Property(e => e.NameGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_group");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StudentGroupCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Group_CreatedBy");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StudentGroupDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Student_Group_DeletedBy");

                entity.HasOne(d => d.IdSpecialityNavigation)
                    .WithMany(p => p.StudentGroups)
                    .HasForeignKey(d => d.IdSpeciality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Student_G__delet__3B75D760");
            });

            modelBuilder.Entity<StudentRole>(entity =>
            {
                entity.HasKey(e => e.IdRole)
                    .HasName("PK__Student___3D48441DB7CE570A");

                entity.ToTable("Student_Role");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.DeletedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("deleted_at");

                entity.Property(e => e.DeletedBy).HasColumnName("deleted_by");

                entity.Property(e => e.NameRole)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_role");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.StudentRoleCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_Role_CreatedBy");

                entity.HasOne(d => d.DeletedByNavigation)
                    .WithMany(p => p.StudentRoleDeletedByNavigations)
                    .HasForeignKey(d => d.DeletedBy)
                    .HasConstraintName("FK_Student_Role_DeletedBy");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
