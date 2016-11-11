namespace MVCLager.Migrations
{
    using MVCLager.Entities;
    using MVCLager.DataAccessLayer;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations.Model;
    using System.Data.Entity.SqlServer;

    internal sealed class Configuration : DbMigrationsConfiguration<MVCLager.DataAccessLayer.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            protected override void Generate(AddColumnOperation addColumnOperation)
            {
                SetCreatedUtcColumn(addColumnOperation.Column);

                base.Generate(addColumnOperation);
            }

            protected override void Generate(CreateTableOperation createTableOperation)
            {
                SetCreatedUtcColumn(createTableOperation.Columns);

                base.Generate(createTableOperation);
            }

            private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
            {
                foreach (var columnModel in columns)
                {
                    SetCreatedUtcColumn(columnModel);
                }
            }

            private static void SetCreatedUtcColumn(PropertyModel column)
            {
                if (column.Name == "CreatedUtc")
                {
                    column.DefaultValueSql = "GETUTCDATE()";
                }
            }
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
