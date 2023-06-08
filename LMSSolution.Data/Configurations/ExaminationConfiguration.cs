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
    public class ExaminationConfiguration : IEntityTypeConfiguration<Examination>
    {
        public void Configure(EntityTypeBuilder<Examination> builder)
        {
            builder.ToTable("Examinations");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.Shiff).IsRequired();

            builder.HasOne(e => e.Subject).WithMany(s => s.Examinations).HasForeignKey(s => s.SubjectId);
            builder.HasOne(e => e.ExamineMethod).WithMany(em => em.Examinations).HasForeignKey(s => s.ExamineMethodId);
        }
    }
}
