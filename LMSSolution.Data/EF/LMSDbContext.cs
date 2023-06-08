using LMSSolution.Data.Configurations;
using LMSSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.EF
{
    public class LMSDbContext : DbContext
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
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectMajorConfiguration());
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CreditClass> CreditClasses { get; set;}
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<ExamineMethod> ExamineMethods { get; set;}
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectMajor> SubjectsMajor { get; set; }
    }
}
