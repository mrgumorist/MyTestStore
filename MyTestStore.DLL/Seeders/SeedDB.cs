using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTestStore.DLL.Seeders
{
    public class SeederDb
    {
        public static void SeedData(IServiceProvider services)
        {
            using (var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<MyDbContext>();
                ClientsSeeder.SeedClients(context);
                ProductsSeeder.SeedCategories(context);
                ProductsSeeder.SeedProducts(context);
                PurchaseSeeder.SeedPurchases(context);
                PurchaseSeeder.SeedProductsInPurchase(context);
                PurchaseSeeder.SeedPurchasesSum(context);
            }
        }
    }
}
