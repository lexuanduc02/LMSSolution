using LMSSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Configurations
{
    public class StudentExaminationConfiguration : IEntityTypeConfiguration<StudentExamination>
    {
        public void Configure(EntityTypeBuilder<StudentExamination> builder)
        {
            builder.ToTable("StudentExamination");

            builder.HasKey(x => new { x.StudentId, x.ExaminationId });
            builder.Property(x => x.Description).IsRequired(false);

            builder.HasOne(se => se.Student).WithMany(u => u.StudentExaminations).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(se => se.Examination).WithMany(e => e.StudentExaminations).HasForeignKey(x => x.ExaminationId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
