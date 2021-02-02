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
    public class PurchaseRepository : IRepository<Purchase>
    {
        private readonly MyDbContext _dbContext;
        public PurchaseRepository(MyDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable<Purchase> GetAll()
        {
            return _dbContext.Purchases;
        }

        public Purchase Get(int id)
        {
            return _dbContext.Purchases.Find(id);
        }

        public ActionResult Create(Purchase model)
        {
            try
            {
                _dbContext.Purchases.Add(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> CreateAsync(Purchase model)
        {
            try
            {
                await _dbContext.Purchases.AddAsync(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult Update(Purchase model)
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

        public IEnumerable<Purchase> Find(Func<Purchase, Boolean> predicate)
        {
            return _dbContext.Purchases.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Purchase model = _dbContext.Purchases.Find(id);
                if (model != null)
                    _dbContext.Purchases.Remove(model);
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
