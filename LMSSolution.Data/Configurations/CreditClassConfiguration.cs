using LMSSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMSSolution.Data.Configurations
{
    public class CreditClassConfiguration : IEntityTypeConfiguration<CreditClass>
    {
        public void Configure(EntityTypeBuilder<CreditClass> builder)
        {
            builder.ToTable("CreditClasses");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

            builder.HasOne(s => s.Subject).WithMany(c => c.CreditClasses).HasForeignKey(c => c.SubjectId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
