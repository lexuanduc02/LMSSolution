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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.Property(x => x.Email).IsRequired().IsUnicode(false);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.LastName).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired(false);
            builder.Property(x => x.Dob).IsRequired();
            builder.Property(x => x.Gender).HasDefaultValue(GenderEnum.Male);

            builder.HasOne(u => u.Class).WithMany(c => c.Students).HasForeignKey(x => x.ClassId).IsRequired(false).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(u => u.Major).WithMany(m => m.Students).HasForeignKey(x => x.MajorId).IsRequired(false).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
