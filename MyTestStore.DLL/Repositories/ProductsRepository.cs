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
    public class ProductsRepository:IRepository<Product>
    {
        private readonly MyDbContext _dbContext;
        public ProductsRepository(MyDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable<Product> GetAll()
        {
            return _dbContext.Products;
        }

        public Product Get(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public ActionResult Create(Product model)
        {
            try
            {
                _dbContext.Products.Add(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> CreateAsync(Product model)
        {
            try
            {
                await _dbContext.Products.AddAsync(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult Update(Product model)
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

        public IEnumerable<Product> Find(Func<Product, Boolean> predicate)
        {
            return _dbContext.Products.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Product model = _dbContext.Products.Find(id);
                if (model != null)
                    _dbContext.Products.Remove(model);
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
