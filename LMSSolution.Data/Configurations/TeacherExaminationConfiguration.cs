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
    public class TeacherExaminationConfiguration : IEntityTypeConfiguration<TeacherExamination>
    {
        public void Configure(EntityTypeBuilder<TeacherExamination> builder)
        {
            builder.ToTable("TeacherExaminations");

            builder.HasKey(x => new { x.TeacherId, x.ExaminationId });

            builder.HasOne(te => te.Teacher).WithMany(u => u.TeacherExaminations).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(te => te.Examination).WithMany(e => e.TeacherExaminations).HasForeignKey(x => x.ExaminationId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
