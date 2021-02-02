using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestStore.DLL.Seeders
{
    public class ProductsSeeder
    {
        public static void SeedCategories(MyDbContext context)
        {
            if (context.Categories.FirstOrDefault(c => c.Name == "Automobile") == null)
            {
                context.Categories.Add(new Entities.Category()
                {
                    Description = "Sample decription",
                    Name="Automobile"
                });
                context.SaveChanges();
            }
            if (context.Categories.FirstOrDefault(c => c.Name == "Motorcycle") == null)
            {
                context.Categories.Add(new Entities.Category()
                {
                    Description = "Sample decription",
                    Name = "Motorcycle"
                });
                context.SaveChanges();
            }
        }

        public static void SeedProducts(MyDbContext context)
        {
            if (context.Products.FirstOrDefault(c => c.Article == "123qw123") == null)
            {
                context.Products.Add(new Entities.Product()
                {
                  Article= "123qw123", 
                  CategoryID=context.Categories.First(x=>x.Name== "Automobile").ID,
                  Price=500000,
                  Name="Toyota Land Cruser"
                });
                context.SaveChanges();
            }
            if (context.Products.FirstOrDefault(c => c.Article == "1qqqqq1") == null)
            {
                context.Products.Add(new Entities.Product()
                {
                    Article = "1qqqqq1",
                    CategoryID = context.Categories.First(x => x.Name == "Motorcycle").ID,
                    Price = 450000,
                    Name = "Yamasaki z1000"
                });
                context.SaveChanges();
            }
            if (context.Products.FirstOrDefault(c => c.Article == "ggg33") == null)
            {
                context.Products.Add(new Entities.Product()
                {
                    Article = "ggg33",
                    CategoryID = context.Categories.First(x => x.Name == "Motorcycle").ID,
                    Price = 433000,
                    Name = "Yamasaki z9000"
                });
                context.SaveChanges();
            }
        }
    }
}
