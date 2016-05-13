using InvoiceReminder.Common.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL.Repositories
{
    /// <summary>
    /// Generic repository implementation
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    internal class GenericRepository<T> : IRepository<T>
        where T : BaseDataModel
    {
        // context for DB access
        private DatabaseContext _context;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
        }

        #region - Sync calls

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Insert(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
        
        public void Delete(int id)
        {
            var ent = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(ent);
        }

        public void Flush()
        {
            _context.SaveChanges();
        }

        #endregion

        #region - Async calls
        
        public async Task<IList<T>> QueryAsync(Func<IQueryable<T>, IQueryable<T>> query)
        {
            return await query(_context.Set<T>()).ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async void DeleteAsync(int id)
        {
            var ent = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(ent);
        }

        public void FlushAsync()
        {
            _context.SaveChangesAsync();
        }

        #endregion
    }
}
