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
    public class TeacherClassConfiguration : IEntityTypeConfiguration<TeacherClass>
    {
        public void Configure(EntityTypeBuilder<TeacherClass> builder)
        {
            builder.ToTable("TeacherClasses");

            builder.HasKey(x => new { x.TeacherId, x.ClassId });

            builder.Property(x => x.Description).HasMaxLength(200);

            builder.HasOne(tc => tc.Class).WithMany(c => c.TeacherClasses).HasForeignKey(x => x.ClassId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(tc => tc.Teacher).WithMany(u => u.TeacherClasses).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
