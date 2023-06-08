using LMSSolution.Data.Entities;
using LMSSolution.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSSolution.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Shiff).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(LessonStatus.Study);

            builder.HasOne(l => l.CreditClass).WithMany(c => c.Lessons).HasForeignKey(c => c.CreditClassId);
        }
    }
}
