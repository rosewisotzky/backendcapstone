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
           .WithOne(o => o.ViewLocation)

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
                      UserId = user.Id
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
                    Description = "The four Piliwale sisters were always starving. Their skin was always stretched tight over their bones, their hands more like the claws of bats. They had no one to care for them, and roamed from island to island, finding any place where food was plentiful. The sisters would eat all that was available and complain should their food arrive late. They ate all night and slept all day, for they were of the people who turn to stone upon sunlight. Wherever they went, the people of that land would become alarmed as their food supply grew thin. Only then did the sisters depart." +
                    "  The sisters often argued who was the hungriest, and one day realized that they had been arguing so long that there was no food left for them. Two of the sisters traveled to Kauai. They landed on Ke'e beach in Ha'ena, where the chief Lohiau greeted them. " +
                    "   'Is there any food that will sate your hunger?' Asked Lohiau." +
                    "   'The fiddlehead of the ho'i'o,' responded one of the sisters, 'with shrimp from the cold mountain stream'." +
                    "   'I am told that the fern grows in Kalalau, perhaps if you went there you could eat all you desire.'" +
                    "The two sisters thanked Lohiau and made their journey to Kalalau. Lohiau sighed with relief. He felt sorry for the families who were about to encounter the sisters, but was grateful for the time to plan for their return." +
                    "When the sisters returned to the beach of Ke'e at Ha'ena, Lohiau had prepared a magnificent feast for them. The sister of Lohiau, Kahua-nui led them to a pond in the slopes of the mountain below Pohaku-O-Kane. There they bathed, and were clothed and  adorned with leis of mokihana and maile. Kahua-nui led brought them up the valley, very close to Pohaku-O-Kane. A platform had been built with a roof and three walls to shelther the guests from the elements. The sisters enjoyed the view of the grassy fields and the beach below, gleaming in the moonlight. A bowl of 'awa was given to each sister and was refilled throughout the entertainment." +
                    "   Students from the hula school performed the story of Ka-ne-loa and his search for Anuenue along the river. A spread of food was placed in front of the sisters before they could even express their hunger. The sisters ravenously ate throughout the night, with their bowls of 'awa kept full and another story being chanted and danced. The night carried on, and as the sisters were preparing to leave, Lohiau encouraged them to enjoy one last meal before they went to sleep." +
                    "   The two sisters were so focused on stuffing their mouths, that they did not notice Kahua-nui close the mats across the open wall, hiding them from the view ahead. 'The morning air is so crisp, let us enjoy it!' Kahua- nui said, as she pulled the mats open." +
                    "  The sisters jumped up with a start. 'Hurry! The sun! We must make it back to the cave! They ran towards the cave, but their heads and bodies were full and slow from the decadent evening. As they ran down the mountain, the sun fell on their bodies and their were turned to stone. A warning, should the other two Piliwale sisters ever try to come to Ha'ena."

                    ,
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id
                },
                new Legend()
                {
                    LegendId = 2,
                    Title = "Pohaku-o-Kane",
                    Description = "In the beginning, three siblings in the form of living rocks were traveling the ocean floor in search of a new home. They traveled from island to island, but found no place that suited them. In time they approached Kauai. As they approached the island, the siblings stopped where a stream of fresh water joined the sea.The fresh water rinsed them of the salt and they traveled up towards the reef." +
                    "   The bright sunshine dazzled their eyes as they broke out of the water and onto the reef. The youngest sibling gazed at the foamy waves surging over it. A green heron waded through the pools full of bright fish, eels and lobsters. 'The reef,' she whispered, 'this is where I will make my home'. Her two brothers urged her to move on with them, out where no sea weeds would cover her, but she had already fallen asleep. This was how O'o-a'a came to Ha'ena. " +
                    "   The two remaining siblings traveled on. They came to a small grove of hala trees, providing a cool shadow from the hot sun. The second sibling paused, enjoying the breeze from the water. 'I am very tired,' he said. 'The solid earth and the rustling of the leaves please me. This is where I will make my home.' His brother responded, 'But the thorny hala leaves will fall on you and lizards will crawl all over you. Come with me to the mountain top.' " +
                    "   'No, I will get dizzy and fall. I prefer to be lulled asleep by the breeze and the rustling leaves.' The second brother settled into the ground and quickly fell asleep. This was how Pohaku-loa came to Ha'ena." +
                    "   The third brother traveled on. Soon, the ground beneath him became steeper and steeper. Using all of his strength, he struggled to reach the top of the mountain. Despite his efforts, he began to slip. For days, he continued to attempt to scale the mountain. But with each attempt, he rolled back to the bottom to rest and try once again." +
                    "   One day, Kane, the greatest of gods, saw the rock in his attempts. Kane knew that the rock would never reach the top of the mountain by himself. He admired his perserverance and determination and was curious to know why he desperately desired to reach the top. 'You've tried to climb this mountain more than enough times.'" +
                    "  'And I will continue to, until I reach the top,' responded the rock." +
                    "  'Why?' Asked Kane. 'You could have rested with your siblings below'." +
                    "  'From that peak, I will be able to watch the plants grow and the birds fly. I will be able to see the waves crash and feel the rain and the wind. I will be able to see the turtles and the fish swim by.'" +
                    "  'How will you see all of this if you fall asleep like your siblings?' Responded Kane." +
                    "  As the rock gathered strength to scale the cliff one more time, he turned to Kane. 'I will watch, not sleep.'" +
                    "The god took the rock in his hand and lifted him to the peak of the mountain. 'When I return, you must tell me all that you have seen. And when it is time for you to leave and find a new home, the waters will rise and submerge the island.'" +
                    "The god vanished as a mist blew by and the rock felt the sun beat down on him as he surveyed the island below. He saw Pohaku-loa underneath the hala trees and O'o-a'a slumbering in the reef. There was much to see and much to remember and the rock stored many things to tell Kane when he returned. In this way, Pohaku-o-Kane came to Ha'ena.",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id

                },
                new Legend()
                {
                    LegendId = 3,
                    Title = "Kanaka-Nunui-Moe",
                    Description = "A very long time ago, there was a very friendly giant who lived in Kawaihau, in the hills behind Kapa'a town. When he was sitting still, he was easily mistaken as one of the hills. To those who didn't live there, he could be very frightening, but those who knew him knew his kind and giving ways." +
                    "   He was always very careful where he stepped, never injuring anyone or destroying a home or taro field. When he got tired, he would find a spot on the mountain to rest. The villagers were grateful for this, as he flattened the land he sat on, giving them more land to farm. Wherever he stepped, he left large, deep footprints. The villagers threw their vegetable scraps, taro peelings and leaves into these footprints to form a compost. Then they would plant banana sprouts, so the giant always was able to eat his favorite fruit. " +
                    "   The giant found it difficult to stay awake for more than a hundred years at a time. Whenever he felt his drowsiness overcome him, he used a small hill for a pillow and for this was called Kanaka-nunui-moe, the sleeping giant." +
                    "  One time, while Nunui was awake, the high chief wanted to build a heiau to honor him. The high chief wanted no ordinary heiau, but one built with the finest materials. He ordered the villagers to gather all of the supplies and build the heiau within one moon. The villagers left unhappy and silent. Nunui saw the long faces in the village and stopped to ask what was wrong." +
                    "The villagers told him of the enormous task in front of them. They wondered how they would tend to their crops and gather the materials for the heiau." +
                    " 'Don't worry,' said Nunui. 'Take care of your fields. I have nothing to do and this work is no feat for me.' " +
                    "Within a week, the heiau was built. To celebrate, the chief called for a feast. 'Eat,' he told the giant. 'After all you have done, you must be very hungry.'" +
                    "Nunui ate his fill and grew tired. He found a small hill just a distance away from town, stretched one last time, and lay down. As the years passed, the winds blew the dirt over him and the birds brought seeds and the gentle rains watered the plants that covered his body. " +
                    "Now, Kanaka-nunui-moe sleeps and sleeps and sleeps and has come to resemble a llong hill with a lump at one end where his nose is and a lump at the other end where his feet are. He no longer looks like a living being, but one day, perhaps soon, his eyes will open, he'll yawn and stretch his arms, and sit up.  ",
                    Source = "Kauai Tales by Frederick Bruce Wichman",
                    UserId = user.Id
                },
                new Legend()
                {
                    LegendId = 4,
                    Title = "Nou O Makana",
                    Description = "When the Menehune still lived on Kauai, a high chief of Hale-le'a and his followers came to visit Ha'ena. He came to catch a firebrand from the fireworks cliff of Makana to prove his affection for a woman who did not believe he loved her. If he could catch a firebrand before it fell into the sea, his love would be unquestioned. And if he could catch that one brand that flew the farthest out he would prove his feelings beyond all doubt. " +
                    "So Kahua-nui, high chiefess of Ha'ena, ordered the firethrowers to wrap dry branches of hau in twine made from the silver gray hinahina. These they would carry up the Limahuli valley and climb the slopes to Makana. There, standing at the edge of the thousand-foot cliff, they would set the brands on fire and throw them over the edge." +
                    " Nou had always wanted to go to the top of the cliff with the firethrowers. 'Let me go with you,' he begged the firethrowers." +
                    "'You are still too young', the leader said.",
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
    

