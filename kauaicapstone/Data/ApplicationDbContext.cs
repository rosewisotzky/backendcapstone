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
       public DbSet<ApplicationUser> ApplicationUser { get; set; }
       public DbSet<Comment> Comment { get; set; }
       public DbSet<Legend> Legend { get; set; }
       public DbSet<ViewLocation> ViewLocation { get; set; }
       public DbSet<LegendViewLocation> LegendViewLocation { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // NOTE: DON'T FORGET THIS LINE
            base.OnModelCreating(modelBuilder);
            //Restricts the delete on LegendViewLocations
            modelBuilder.Entity<Legend>()
                .HasMany(l => l.LegendViewLocations)
                .WithOne(o => o.Legend)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                
               .Property(b => b.DatePosted)
               .HasDefaultValueSql("GETDATE()");



            modelBuilder.Entity<ViewLocation>()
               .HasMany(l => l.LegendViewLocations)
               .WithOne(o => o.ViewLocation)
              
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ViewLocation>()
           .HasMany(l => l.Comments)
           .WithOne(o => o.viewLocation)

           .OnDelete(DeleteBehavior.Restrict);




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
                Id = "00000000-ffff-ffff-ffff-ffffffffffff",
                IsAdmin = true
            };
            var passwordHash = new PasswordHasher<ApplicationUser>();
            admin.PasswordHash = passwordHash.HashPassword(admin, "Admin8*");
            modelBuilder.Entity<ApplicationUser>().HasData(admin);

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
                Id = "00000001-ffff-ffff-ffff-ffffffffffff",
                IsAdmin = false
            };
            var passWordHash1 = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passWordHash1.HashPassword(user, "Rose8*");
            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<ViewLocation>().HasData(
                  new ViewLocation()
                  {
                      ViewLocationId = 1,
                      Name = "Makua Beach",
                      ViewPointAddress = "HI-560, Kapaʻa, HI 96746",
                      UserId = user.Id
                  },
                  new ViewLocation()
                  {
                      ViewLocationId = 2,
                      Name = "Limahuli Garden & Preserve",
                      ViewPointAddress = "5-8291 Kuhio Hwy, Hanalei, HI 96714",
                      UserId = user.Id,
                      IsFavorite = true
                  },
                  new ViewLocation()
                  {
                      ViewLocationId = 3,
                      Name = "Kalalau Valley",
                      ViewPointAddress = "5-8291 Kuhio Hwy, Hanalei, HI 96714",
                      UserId = user.Id
                  },
                  new ViewLocation()
                  {
                      ViewLocationId = 4,
                      Name = "Sleeping Giant Trail",
                      ViewPointAddress = "Sleeping Giant, Wailua, HI 96746",
                      UserId = user.Id
                  }
            );
            modelBuilder.Entity<Legend>().HasData(
                new Legend()
                {
                    LegendId = 1,
                    Title = "Na-Piliwale",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id
                },
                new Legend()
                {
                    LegendId = 2,
                    Title = "Pohaku-o-Kane",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id

                },
                new Legend()
                {
                    LegendId = 3,
                    Title = "Kanaka-Nunui-Moa",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id
                },
                new Legend()
                {
                    LegendId = 4,
                    Title = "Nou O Makana",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Eget duis at tellus at urna condimentum mattis pellentesque id. Arcu non odio euismod lacinia at. Faucibus pulvinar elementum integer enim neque volutpat ac tincidunt vitae. Donec adipiscing tristique risus nec feugiat. Congue quisque egestas diam in arcu cursus euismod. Diam vel quam elementum pulvinar etiam non quam.",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id
                }
              );

            modelBuilder.Entity<Comment>().HasData(
                new Comment()
                {
                    CommentId = 1,
                    UserId = user.Id,
                    Message = "You can also visit the dry caves from Makua Beach, the bridge will be closed if there is heavy rain",
                    ViewLocationId = 2,
                    DatePosted = new DateTime(2019, 7, 29)
                },
                  new Comment()
                  {
                      CommentId = 2,
                      UserId = user.Id,
                      Message = "Beautiful swimming spot, great parking",
                      ViewLocationId = 1,
                      DatePosted = new DateTime(2019, 7, 29)
                  }
                );
            modelBuilder.Entity<LegendViewLocation>().HasData(
                new LegendViewLocation()
                {
                    LegendViewLocationId = 1,
                    ViewLocationId = 1,
                    LegendId= 2
            },
                new LegendViewLocation()
                {
                    LegendViewLocationId = 2,
                    ViewLocationId = 1,
                    LegendId = 1
                },
                new LegendViewLocation()
                {
                    LegendViewLocationId = 3,
                    ViewLocationId = 4,
                    LegendId = 3
                },
                new LegendViewLocation()
                {
                    LegendViewLocationId = 4,
                    ViewLocationId = 2,
                    LegendId = 4
                }
          );



        }
         
    }
    }
    

