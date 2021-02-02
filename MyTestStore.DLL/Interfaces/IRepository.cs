using MyTestStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyTestStore.DLL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T Get(int id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        ActionResult Create(T item);
        Task<ActionResult> CreateAsync(T item);
        ActionResult Update(T item);
        ActionResult Delete(int id);
        ActionResult SaveChanges();
        Task<ActionResult> SaveChangesAsync();
    }
}
