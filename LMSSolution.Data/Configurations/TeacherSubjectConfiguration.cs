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
    public class TeacherSubjectConfiguration : IEntityTypeConfiguration<TeacherSubject>
    {
        public void Configure(EntityTypeBuilder<TeacherSubject> builder)
        {
            builder.ToTable("TeacherSubjects");

            builder.HasKey(x => new { x.SubjectId, x.TeacherId });

            builder.HasOne(ts => ts.Teacher).WithMany(u => u.TeacherSubjects).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(ts => ts.Subject).WithMany(s => s.TeacherSubjects).HasForeignKey(x => x.SubjectId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
