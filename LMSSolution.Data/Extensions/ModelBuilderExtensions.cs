using LMSSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMSSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("C17D487E-646A-47E2-9EE4-B319155E326E"),
                Name = "admin",
                NormalizedName = "admin"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("E029D545-0A04-4088-B156-0F1AFA8EF68B"),
                Name = "officer",
                NormalizedName = "officer"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("3C51F349-A63E-43B1-B31F-6A7A0ADDF485"),
                Name = "teacher",
                NormalizedName = "teacher"
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = new Guid("811BC9CA-0E15-48C3-BC44-851D5A386C78"),
                Name = "student",
                NormalizedName = "student"
            });

            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = new Guid("D7D6AE65-8029-46C5-A006-F89D6D04FA8C"),
                UserName = "hou_admin",
                NormalizedUserName = "hou_admin",
                Email = "lms@hou.edu.vn",
                NormalizedEmail = "lms@hou.edu.vn",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "lxduc11@111"),
                SecurityStamp = string.Empty,
                FirstName = "Đại học",
                LastName = "Mở Hà Nội",
                Gender = Enum.GenderEnum.Male,
                Dob = new DateTime(1993, 11, 03),
                PhoneNumber = "024 3868 2321",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = new Guid("C17D487E-646A-47E2-9EE4-B319155E326E"),
                UserId = new Guid("D7D6AE65-8029-46C5-A006-F89D6D04FA8C")
            });
        }
    }
}
