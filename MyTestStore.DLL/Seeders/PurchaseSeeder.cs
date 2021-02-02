using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestStore.DLL.Seeders
{
    public class PurchaseSeeder
    {
        public static void SeedPurchases(MyDbContext context)
        {
            if (context.Purchases.FirstOrDefault(c => c.ID == 1) == null)
            {
                context.Purchases.Add(new Entities.Purchase()
                {
                    Date = DateTime.Now, ClientID=context.Clients.First(x=>x.ID==1).ID
                }) ;
                context.SaveChanges();
            }
            if (context.Purchases.FirstOrDefault(c => c.ID == 2) == null)
            {
                context.Purchases.Add(new Entities.Purchase()
                {
                    Date = DateTime.Now,
                    ClientID = context.Clients.First(x => x.ID == 2).ID
                });
                context.SaveChanges();
            }
        }

        public static void SeedProductsInPurchase(MyDbContext context)
        {
            if (context.ProductsInPurchase.FirstOrDefault(c => c.ID == 1) == null)
            {
                context.ProductsInPurchase.Add(new Entities.ProductInPurchase()
                {
                   ProductID=context.Products.First(x=>x.ID==1).ID,
                   PurchaseID=context.Purchases.First(x=>x.ID==1).ID,
                   Count=2
                });
                context.SaveChanges();
            }
            if (context.ProductsInPurchase.FirstOrDefault(c => c.ID == 2) == null)
            {
                context.ProductsInPurchase.Add(new Entities.ProductInPurchase()
                {
                    ProductID = context.Products.First(x => x.ID == 2).ID,
                    PurchaseID = context.Purchases.First(x => x.ID == 1).ID,
                    Count = 5
                });
                context.SaveChanges();
            }
            if (context.ProductsInPurchase.FirstOrDefault(c => c.ID == 3) == null)
            {
                context.ProductsInPurchase.Add(new Entities.ProductInPurchase()
                {
                    ProductID = context.Products.First(x => x.ID == 1).ID,
                    PurchaseID = context.Purchases.First(x => x.ID == 2).ID,
                    Count = 1
                });
                context.SaveChanges();
            }
            if (context.ProductsInPurchase.FirstOrDefault(c => c.ID == 4) == null)
            {
                context.ProductsInPurchase.Add(new Entities.ProductInPurchase()
                {
                    ProductID = context.Products.First(x => x.ID == 2).ID,
                    PurchaseID = context.Purchases.First(x => x.ID == 2).ID,
                    Count = 2
                });
                context.SaveChanges();
            }
        }
        public static void SeedPurchasesSum(MyDbContext context)
        {
            if (context.Purchases.FirstOrDefault(c => c.ID == 1) != null)
            {
                double sum = 0;
                var products = context.Purchases.FirstOrDefault(c => c.ID == 1).Products;
                foreach (var item in products)
                {
                    sum += item.Product.Price * item.Count;
                }
                context.Purchases.FirstOrDefault(c => c.ID == 1).Sum = sum;
                context.SaveChanges();
            }
            if (context.Purchases.FirstOrDefault(c => c.ID == 2) != null)
            {
                double sum = 0;
                var products = context.Purchases.FirstOrDefault(c => c.ID == 2).Products;
                foreach (var item in products)
                {
                    sum += item.Product.Price * item.Count;
                }
                context.Purchases.FirstOrDefault(c => c.ID == 2).Sum = sum;
                context.SaveChanges();
            }
        }
    }
}
