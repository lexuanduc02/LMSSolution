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
    public class StudentAttendanceConfiguration : IEntityTypeConfiguration<StudentAttendance>
    {
        public void Configure(EntityTypeBuilder<StudentAttendance> builder)
        {
            builder.ToTable("StudentAttendances");

            builder.HasKey(x => new {x.StudentId, x.AttendaceId});
            builder.Property(x => x.Status).IsRequired();
             
            builder.HasOne(sa => sa.Student).WithMany(u => u.StudentAttendances).HasForeignKey(x => x.StudentId).OnDelete(DeleteBehavior.ClientNoAction);
            builder.HasOne(sa => sa.Attendance).WithMany(a => a.StudentAttendances).HasForeignKey(x => x.AttendaceId).OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
