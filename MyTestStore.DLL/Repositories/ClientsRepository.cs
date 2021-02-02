using Microsoft.EntityFrameworkCore;
using MyTestStore.DLL.Entities;
using MyTestStore.DLL.Interfaces;
using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStore.DLL.Repositories
{
    public class ClientsRepository: IRepository<Client>
    {
        private readonly MyDbContext dbContext;
        public ClientsRepository(MyDbContext _context)
        {
            this.dbContext = _context;
        }
        public IEnumerable<Client> GetAll()
        {
            return dbContext.Clients;
        }

        public Client Get(int id)
        {
            return dbContext.Clients.Find(id);
        }

        public ActionResult Create(Client model)
        {
            try
            {
                dbContext.Clients.Add(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> CreateAsync(Client model)
        {
            try
            {
                await dbContext.Clients.AddAsync(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult Update(Client model)
        {
            try
            {
                dbContext.Entry(model).State = EntityState.Modified;
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public IEnumerable<Client> Find(Func<Client, Boolean> predicate)
        {
            return dbContext.Clients.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Client model = dbContext.Clients.Find(id);
                if (model != null)
                    dbContext.Clients.Remove(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> SaveChangesAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }
    }
}
