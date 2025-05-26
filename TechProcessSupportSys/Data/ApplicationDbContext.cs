using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechProcessSupportSys.Models;

namespace TechProcessSupportSys.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions options)
        : base(options)
        {
            
        }

        public DbSet<Blank> Blanks { get; set; }
        public DbSet<TechProcess> Processes { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<TechProcess>().Property(p => p.Status).HasConversion<string>();

            var hasher = new PasswordHasher<User>();
            User admin = new User()
            {
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                EmailConfirmed = false,
                Name = "Admin",
                CreatedOn = DateTime.Now,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null!, "Admin1234!")
            };
            builder.Entity<User>().HasData(admin);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = admin.Id,
                    RoleId = roles.FirstOrDefault(r => r.Name == "Admin").Id
                });
        }
    }
}