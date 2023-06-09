using LMSSolution.Data.Configurations;
using LMSSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMSSolution.Data.EF
{
    public class LMSDbContext : IdentityDbContext<User, Role, Guid>
    {
        public LMSDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new ClassConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new CreditClassConfiguration());
            modelBuilder.ApplyConfiguration(new ExaminationConfiguration());
            modelBuilder.ApplyConfiguration(new ExamineMethodConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
            modelBuilder.ApplyConfiguration(new MajorConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectMajorConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new StudentAttendanceConfiguration());
            modelBuilder.ApplyConfiguration(new StudentExaminationConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherClassConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherSubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherExaminationConfiguration());
            modelBuilder.ApplyConfiguration(new StudyShiffConfiguration());

            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(x => new {x.RoleId, x.UserId});
            });
            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
                entity.HasKey(x => x.UserId);
            });
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
                entity.HasKey(x => x.UserId);
            });
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CreditClass> CreditClasses { get; set;}
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExamineMethod> ExamineMethods { get; set;}
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectMajor> SubjectsMajor { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentAttendance> StudentAttendances { get; set; }
        public DbSet<StudentExamination> StudentExaminations { get; set; }
        public DbSet<TeacherClass> TeacherClasses { get; set; }
        public DbSet<TeacherExamination> TeacherExaminations { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public DbSet<StudyShiff> StudyShiffs { get; set; }

    }
}
