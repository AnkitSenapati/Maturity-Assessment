using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MaturityDAL.Models
{
    public partial class MaturityAssessmentContext : DbContext
    {
        public MaturityAssessmentContext()
        {
        }

        public MaturityAssessmentContext(DbContextOptions<MaturityAssessmentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectMember> ProjectMembers { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Survey> Surveys { get; set; }
        public virtual DbSet<UserSurvey> UserSurveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=ROHANJHA;Database=MaturityAssessment;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.AnswerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_qstn_id");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.FunctionName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.ProjectDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("project_desc");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("projectName");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_proj_fn_id");
            });

            modelBuilder.Entity<ProjectMember>(entity =>
            {
                entity.ToTable("project_members");

                entity.Property(e => e.ProjectMemberId).HasColumnName("project_member_id");

                entity.Property(e => e.ProjectId).HasColumnName("project_id");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.ProjectId)
                    .HasConstraintName("FK_pro_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ProjectMembers)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("FK_usr_id");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.FunctionId).HasColumnName("Function_id");

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.FunctionId)
                    .HasConstraintName("FK_fctn_id");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.Userid)
                    .HasName("PK__Register__CBA1B25750CCE729");

                entity.ToTable("Register");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("confirmPassword");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firstname");

                entity.Property(e => e.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lastname");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Registers)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Survey>(entity =>
            {
                entity.ToTable("Survey");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("end_date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("start_date");

                entity.Property(e => e.SurveyName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("surveyName");
            });

            modelBuilder.Entity<UserSurvey>(entity =>
            {
                entity.ToTable("User_Survey");

                entity.Property(e => e.UserSurveyId).HasColumnName("User_Survey_id");

                entity.Property(e => e.AnswerId).HasColumnName("Answer_id");

                entity.Property(e => e.ProjectMemberId).HasColumnName("project_member_id");

                entity.Property(e => e.QuestionId).HasColumnName("Question_id");

                entity.Property(e => e.SurveyId).HasColumnName("survey_id");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserSurveys)
                    .HasForeignKey(d => d.AnswerId)
                    .HasConstraintName("FK_ans_id");

                entity.HasOne(d => d.ProjectMember)
                    .WithMany(p => p.UserSurveys)
                    .HasForeignKey(d => d.ProjectMemberId)
                    .HasConstraintName("FK_pr_mem_id");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.UserSurveys)
                    .HasForeignKey(d => d.QuestionId)
                    .HasConstraintName("FK_Q_id");

                entity.HasOne(d => d.Survey)
                    .WithMany(p => p.UserSurveys)
                    .HasForeignKey(d => d.SurveyId)
                    .HasConstraintName("FK_srv_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
