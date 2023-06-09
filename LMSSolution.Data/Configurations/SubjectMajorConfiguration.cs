using LMSSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMSSolution.Data.Configurations
{
    public class SubjectMajorConfiguration : IEntityTypeConfiguration<SubjectMajor>
    {
        public void Configure(EntityTypeBuilder<SubjectMajor> builder)
        {
            builder.ToTable("SubjectMajors");

            builder.HasKey(x => new { x.SubjectId, x.MajorId });

            builder.HasOne(sm => sm.Subject).WithMany(s => s.SubjectMajors).HasForeignKey(sm => sm.SubjectId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(sm => sm.Major).WithMany(m => m.SubjectMajors).HasForeignKey(sm => sm.MajorId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
