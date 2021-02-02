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
    public class CategoriesRepository:IRepository<Category>
    {
        private readonly MyDbContext _dbContext;
        public CategoriesRepository(MyDbContext context)
        {
            this._dbContext = context;
        }
        public IEnumerable<Category> GetAll()
        {
            return _dbContext.Categories;
        }

        public Category Get(int id)
        {
            return _dbContext.Categories.Find(id);
        }

        public ActionResult Create(Category model)
        {
            try
            {
                _dbContext.Categories.Add(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public async Task<ActionResult> CreateAsync(Category model)
        {
            try
            {
                await _dbContext.Categories.AddAsync(model);
                return new ActionResult(true, "Fine");
            }
            catch (Exception ex)
            {
                return new ActionResult(false, ex.Message);
            }
        }

        public ActionResult Update(Category model)
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

        public IEnumerable<Category> Find(Func<Category, Boolean> predicate)
        {
            return _dbContext.Categories.Where(predicate).ToList();
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Category model = _dbContext.Categories.Find(id);
                if (model != null)
                    _dbContext.Categories.Remove(model);
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
