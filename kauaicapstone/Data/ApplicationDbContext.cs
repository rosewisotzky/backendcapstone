using System;
using System.Collections.Generic;
using System.Text;
using kauaicapstone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace kauaicapstone.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        DbSet<ApplicationUser> ApplicationUser { get; set; }
        DbSet<Comment> Comment { get; set; }
        DbSet<Legend> Legend { get; set; }
        DbSet<ViewLocation> ViewLocation { get; set; }
        DbSet<LegendViewLocation> LegendViewLocation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: DON'T FORGET THIS LINE
            base.OnModelCreating(modelBuilder);

            // Create a new user for Identity Framework
            ApplicationUser admin = new ApplicationUser
            {
                FirstName = "admin",
                LastName = "admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794577",
                Id = "00000000-ffff-ffff-ffff-ffffffffffff"
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
        }
        ApplicationUser user = new ApplicationUser
        {
            FirstName = "Rose",
            LastName = "Wisotzky",
            UserName = "rose@rose.com",
            NormalizedUserName = "ROSE@ROSE.COM",
            Email = "rose@rose.com",
            NormalizedEmail = "ROSE@ROSE.COM",
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = "7f434309-a4d9-48e9-9ebb-8803db794578",
            Id = "00000001-ffff-ffff-ffff-ffffffffffff"
        };
        var passWordHash1 = new PasswordHasher<ApplicationUser>();
        
        

    }
    }
    

