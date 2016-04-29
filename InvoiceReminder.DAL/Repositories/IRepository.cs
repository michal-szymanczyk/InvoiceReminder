using InvoiceReminder.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL.Repositories
{
    /// <summary>
    /// Generic repository, introducing common CRUD operations for specified entity
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    public interface IRepository<T> 
        where T : BaseEntity
    {
        #region - Sync calls
        /// <summary>
        /// Get Query object for complex Select queries
        /// </summary>
        /// <returns>Query object</returns>
        IQueryable<T> QueryAll();

        /// <summary>
        /// Query for a row with specified id
        /// </summary>
        /// <param name="id">Id of row read from DB</param>
        /// <returns>Entity object or null if it not exists</returns>
        T GetById(int id);

        /// <summary>
        /// Insert new entity to the database table, Id property is skipped
        /// </summary>
        /// <param name="entity">Entity to insert</param>
        void Insert(T entity);

        /// <summary>
        /// Deletes entity from database, only ID property is used
        /// </summary>
        /// <param name="id">Entity Id to delete</param>
        void Delete(int id);
        
        /// <summary>
        /// Update entity in db, Id is used for refernce to update all values from properties in DB
        /// </summary>
        /// <param name="entity">Entity object to update</param>
        void Update(T entity);

        /// <summary>
        /// Flush all changes to the DB
        /// </summary>
        void Flush();

        #endregion
        
        #region - Async calls

        /// <summary>
        /// Query for a row with specified id - asynchronous call
        /// </summary>
        /// <param name="id">Id of row read from DB</param>
        /// <returns>Entity object or null if it not exists</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Deletes entity from database, only ID property is used - asynchronous call
        /// </summary>
        /// <param name="id">Entity Id to delete</param>
        void DeleteAsync(int id);

        /// <summary>
        /// Flush all changes to the DB - asynchronous call
        /// </summary>
        void FlushAsync();

        #endregion

    }
}
