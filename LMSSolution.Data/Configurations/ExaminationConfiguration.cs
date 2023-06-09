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

            builder.HasOne(e => e.Subject).WithMany(s => s.Examinations).HasForeignKey(e => e.SubjectId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(e => e.ExamineMethod).WithMany(em => em.Examinations).HasForeignKey(e => e.ExamineMethodId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(e => e.StudyShiff).WithMany(ss => ss.Examinations).HasForeignKey(e => e.StudyShiffId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
