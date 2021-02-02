using Microsoft.EntityFrameworkCore;
using MyTestStore.DLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.DLL
{
    public class MyDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInPurchase> ProductsInPurchase { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
          => options.UseSqlite("Data Source=MySql.db");
    }
}
