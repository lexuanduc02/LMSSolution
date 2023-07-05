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
    public class StudyShiffConfiguration : IEntityTypeConfiguration<StudyShiff>
    {
        public void Configure(EntityTypeBuilder<StudyShiff> builder)
        {
            builder.ToTable("StudyShiffs");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).IsRequired(false);

            builder.Property(x => x.StartAt).IsRequired();
            builder.Property(x => x.EndAt).IsRequired();
        }
    }
}
