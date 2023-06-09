﻿// <auto-generated />
using System;
using LMSSolution.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMSSolution.Data.Migrations
{
    [DbContext(typeof(LMSDbContext))]
    partial class LMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LMSSolution.Data.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreditClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudyShiffId")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreditClassId");

                    b.HasIndex("StudyShiffId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Attendances", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("MajorId");

                    b.ToTable("Classes", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.CreditClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.ToTable("CreditClasses", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Examination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamineMethodId")
                        .HasColumnType("int");

                    b.Property<int>("StudyShiffId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExamineMethodId");

                    b.HasIndex("StudyShiffId");

                    b.HasIndex("SubjectId");

                    b.ToTable("Examinations", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.ExamineMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExamineMethods", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreditClassId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("StadyShiffId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CreditClassId");

                    b.HasIndex("StadyShiffId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lessons", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Major", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descrition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Majors", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudentAttendance", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AttendaceId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("StudentId", "AttendaceId");

                    b.HasIndex("AttendaceId");

                    b.ToTable("StudentAttendances", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudentExamination", b =>
                {
                    b.Property<Guid>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExaminationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId", "ExaminationId");

                    b.HasIndex("ExaminationId");

                    b.ToTable("StudentExamination", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudyShiff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EndAt")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartAt")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("StudyShiffs", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfLesson")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.SubjectMajor", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("MajorId")
                        .HasColumnType("int");

                    b.HasKey("SubjectId", "MajorId");

                    b.HasIndex("MajorId");

                    b.ToTable("SubjectMajors", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherClass", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TeacherId", "ClassId");

                    b.HasIndex("ClassId");

                    b.ToTable("TeacherClasses", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherExamination", b =>
                {
                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ExaminationId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeacherId", "ExaminationId");

                    b.HasIndex("ExaminationId");

                    b.ToTable("TeacherExaminations", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherSubject", b =>
                {
                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<Guid>("TeacherId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SubjectId", "TeacherId");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeacherSubjects", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MajorId")
                        .HasColumnType("int");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("MajorId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("UserTokens", (string)null);
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Attendance", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.CreditClass", "CreditClass")
                        .WithMany("Attendances")
                        .HasForeignKey("CreditClassId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.StudyShiff", "StudyShiff")
                        .WithMany("Attendances")
                        .HasForeignKey("StudyShiffId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Teacher")
                        .WithMany("Attendances")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("CreditClass");

                    b.Navigation("StudyShiff");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Class", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.Major", "Major")
                        .WithMany("Classes")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.CreditClass", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Subject", "Subject")
                        .WithMany("CreditClasses")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Examination", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.ExamineMethod", "ExamineMethod")
                        .WithMany("Examinations")
                        .HasForeignKey("ExamineMethodId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.StudyShiff", "StudyShiff")
                        .WithMany("Examinations")
                        .HasForeignKey("StudyShiffId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.Subject", "Subject")
                        .WithMany("Examinations")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("ExamineMethod");

                    b.Navigation("StudyShiff");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Lesson", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.CreditClass", "CreditClass")
                        .WithMany("Lessons")
                        .HasForeignKey("CreditClassId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.StudyShiff", "StudyShiff")
                        .WithMany("Lessons")
                        .HasForeignKey("StadyShiffId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Teacher")
                        .WithMany("Lessons")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("CreditClass");

                    b.Navigation("StudyShiff");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudentAttendance", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Attendance", "Attendance")
                        .WithMany("StudentAttendances")
                        .HasForeignKey("AttendaceId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Student")
                        .WithMany("StudentAttendances")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Attendance");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudentExamination", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Examination", "Examination")
                        .WithMany("StudentExaminations")
                        .HasForeignKey("ExaminationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Student")
                        .WithMany("StudentExaminations")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Examination");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.SubjectMajor", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Major", "Major")
                        .WithMany("SubjectMajors")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.Subject", "Subject")
                        .WithMany("SubjectMajors")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Major");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherClass", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Class", "Class")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Teacher")
                        .WithMany("TeacherClasses")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Class");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherExamination", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Examination", "Examination")
                        .WithMany("TeacherExaminations")
                        .HasForeignKey("ExaminationId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Teacher")
                        .WithMany("TeacherExaminations")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Examination");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.TeacherSubject", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Subject", "Subject")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("LMSSolution.Data.Entities.User", "Teacher")
                        .WithMany("TeacherSubjects")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.User", b =>
                {
                    b.HasOne("LMSSolution.Data.Entities.Class", "Class")
                        .WithMany("Students")
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.HasOne("LMSSolution.Data.Entities.Major", "Major")
                        .WithMany("Students")
                        .HasForeignKey("MajorId")
                        .OnDelete(DeleteBehavior.ClientNoAction);

                    b.Navigation("Class");

                    b.Navigation("Major");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Attendance", b =>
                {
                    b.Navigation("StudentAttendances");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Class", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("TeacherClasses");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Course", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.CreditClass", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Examination", b =>
                {
                    b.Navigation("StudentExaminations");

                    b.Navigation("TeacherExaminations");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.ExamineMethod", b =>
                {
                    b.Navigation("Examinations");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Major", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Students");

                    b.Navigation("SubjectMajors");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.StudyShiff", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Examinations");

                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.Subject", b =>
                {
                    b.Navigation("CreditClasses");

                    b.Navigation("Examinations");

                    b.Navigation("SubjectMajors");

                    b.Navigation("TeacherSubjects");
                });

            modelBuilder.Entity("LMSSolution.Data.Entities.User", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Lessons");

                    b.Navigation("StudentAttendances");

                    b.Navigation("StudentExaminations");

                    b.Navigation("TeacherClasses");

                    b.Navigation("TeacherExaminations");

                    b.Navigation("TeacherSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
