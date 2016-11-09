namespace MVCLager.Migrations
{
    using MVCLager.Entities;
    using MVCLager.DataAccessLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCLager.DataAccessLayer.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MVCLager.DataAccessLayer.StoreContext context)
        {
            context.Items.AddOrUpdate(
              i => i.Name,
              new StockItem { Name = "Gurka",   Description = "Grön lång sak", Price = 20.0m },
              new StockItem { Name = "Avocado", Description = "Oval klump ",   Price = 35.0m },
              new StockItem { Name = "Romansallad", Description = "Gröna blad",   Price = 40.0m },
              new StockItem { Name = "Påse ekologiska Bananer",   Description = "Gul böjd frukt ",   Price = 49.90m }
            );
        }
    }
}
