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
    public class ClassConfiguration : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Classes");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired(false);

            builder.HasOne(c => c.Course).WithMany(c => c.Classes).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(m => m.Major).WithMany(c => c.Classes).HasForeignKey(x => x.MajorId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(m => m.Teacher).WithMany(c => c.Classes).HasForeignKey(x => x.TeacherId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
