using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTestStore.DLL.Seeders
{
    public class ClientsSeeder
    {
        public static void SeedClients(MyDbContext context)
        {
            if (context.Clients.SingleOrDefault(c => c.ID == 1) == null)
            {
                context.Clients.Add(new Entities.Client()
                {
                    FIO="Andrew Smirnov Dmitrivich", 
                    BirthDay=DateTime.Now.AddYears(-18),
                    Registered=DateTime.Now
                }); 
                context.SaveChanges();
            }
            if (context.Clients.SingleOrDefault(c => c.ID == 2) == null)
            {
                context.Clients.Add(new Entities.Client()
                {
                    FIO = "Boris Kravtsov Victorievich",
                    BirthDay = DateTime.Now.AddYears(-15),
                    Registered = DateTime.Now
                });
                context.SaveChanges();
            }
        }
    }
}
