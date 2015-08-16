namespace ForumSys.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    
    using ForumSys.Data.Models;
    
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    internal sealed class Configuration : DbMigrationsConfiguration<ForumSys.Data.ApplicationDbContext>
    {
        private static Random random = new Random();

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(ApplicationDbContext context)
        {
            this.SeedUsers(context);
            this.SeedTags(context);
            this.SeedPosts(context);
        }
        
        private void SeedUsers(ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            var user = new ApplicationUser()
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com"
            };

            userManager.Create(user, "123456");
        }

        private void SeedPosts(ApplicationDbContext context)
        {
            if (context.Posts.Any())
            {
                return;
            }

            var author = context.Users.First();
            for (int i = 0; i < 10; i++)
            {
                var currentPost = new Post()
                {
                    Author = author,
                    AuthorId = author.Id,
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    IsDeleted = false,
                    PreserveCreatedOn = true,
                    Title = "A sample question " + (i + 1).ToString()
                };
                var allTags = context.Tags.ToList();
                var currentNumberOfTags = random.Next(4, allTags.Count);
                for (int j = 0; j < currentNumberOfTags; j++)
                {
                    currentPost.Tags.Add(allTags[random.Next(allTags.Count)]);
                }

                context.Posts.Add(currentPost);
            }

            context.SaveChanges();
        }

        private void SeedTags(ApplicationDbContext context)
        {
            if (context.Tags.Any())
            {
                return;
            }

            context.Tags.AddOrUpdate(
                t => t.Id,
                new Tag()
                {
                    Name = "MVC",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = "ASP",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = ".NET",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = "JavaScript",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = "Other",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = "Mozilla",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                },
                new Tag()
                {
                    Name = "Web",
                    PreserveCreatedOn = true,
                    IsDeleted = false,
                });

            context.SaveChanges();
        }
    }
}