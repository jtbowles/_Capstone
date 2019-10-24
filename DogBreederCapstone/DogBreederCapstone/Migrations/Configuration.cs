namespace DogBreederCapstone.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DogBreederCapstone.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DogBreederCapstone.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Coats.AddOrUpdate(
            //    new Models.Coat { Name = "Caramel", Colors = "a rich Gold/Apricot" },
            //    new Models.Coat { Name = "Red", Colors = "an even rich Red" },
            //    new Models.Coat { Name = "Blue", Colors = "a dark to medium smoky Blue" },
            //    new Models.Coat { Name = "Silver", Colors = "a beuatiful smoky Grey/Silver" },
            //    new Models.Coat { Name = "Chocolate", Colors = "a dark and rich chocolate Brown" },
            //    new Models.Coat { Name = "Cafe", Colors = "a milk chocolate with varying shades/highlights" },
            //    new Models.Coat { Name = "Lavender", Colors = "an even smoky lavender chocolate, pink/lilac appearance" },
            //    new Models.Coat { Name = "Parchment", Colors = "milk chocolate that will pale to a smoky creamy beige" }
            //    );

            //context.Sizes.AddOrUpdate(
            //    new Models.Size { Name = "Micro", Weight = 12, Height = 12 },
            //    new Models.Size { Name = "Small", Weight = 20, Height = 16 },
            //    new Models.Size { Name = "Medium", Weight = 35, Height = 19 },
            //    new Models.Size { Name = "Standard", Weight = 60, Height = 22 }
            //    );
        }
    }
}
