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
    public class PurchaseProductsRepository : IRepository<ProductInPurchase>
    {
        private readonly MyDbContext _dbContext;
        public PurchaseProductsRepository(MyDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable<ProductInPurchase> GetAll()
        {
            return _dbContext.ProductsInPurchase;
        }

        public ProductInPurchase Get(int id)
        {
            return _dbContext.ProductsInPurchase.Find(id);
        }

        public ActionResult Create(ProductInPurchase model)
        {
            try
            {
                _dbContext.ProductsInPurchase.Add(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> CreateAsync(ProductInPurchase model)
        {
            try
            {
                await _dbContext.ProductsInPurchase.AddAsync(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult Update(ProductInPurchase model)
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

        public IEnumerable<ProductInPurchase> Find(Func<ProductInPurchase, Boolean> predicate)
        {
            return _dbContext.ProductsInPurchase.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                ProductInPurchase model = _dbContext.ProductsInPurchase.Find(id);
                if (model != null)
                    _dbContext.ProductsInPurchase.Remove(model);
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
