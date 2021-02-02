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
        private readonly MyDbContext _dbContext;
        public ClientsRepository(MyDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable<Client> GetAll()
        {
            return _dbContext.Clients;
        }

        public Client Get(int id)
        {
            return _dbContext.Clients.Find(id);
        }

        public ActionResult Create(Client model)
        {
            try
            {
                _dbContext.Clients.Add(model);
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
                await _dbContext.Clients.AddAsync(model);
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
                _dbContext.Entry(model).State = EntityState.Modified;
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public IEnumerable<Client> Find(Func<Client, Boolean> predicate)
        {
            return _dbContext.Clients.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Client model = _dbContext.Clients.Find(id);
                if (model != null)
                    _dbContext.Clients.Remove(model);
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
                _dbContext.SaveChanges();
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
                await _dbContext.SaveChangesAsync();
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }
    }
}
