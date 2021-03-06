namespace Blog.DataAccess.Interfaces
{
    using Business.Entity;
    using System.Linq;
    using System.Collections.Generic;

    /// <summary>
    /// This interface must be implemented by all repositories to ensure UnitOfWork to work.
    /// Implement by generic version instead of this one.
    /// </summary>
    public interface IRepository
    {

    }

    /// <summary>
    /// This interface is implemented by all repositories to ensure implementation of fixed methods.
    /// </summary>
    /// <typeparam name="TEntity">Main Entity type this repository works on</typeparam>

    public interface IRepository<TEntity> : IRepository where TEntity : Entity
    {
        /// <summary>
        /// Used to get a IQueryable that is used to retrive entities from entire table.
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll();

        IList<TEntity> GetAll(List<FilterOption> filters, int pageNumber, int pageSize, string sortBy, string sortDirection, List<string> selectColumnsList = null);

        int CountGetAll(List<FilterOption> filters, int pageNumber, int pageSize);
        /// <summary>
        /// Gets an entity.
        /// </summary>
        /// <param name="id">Primary key of the entity to get</param>
        /// <returns>Entity</returns>
        TEntity Get(int id);

        /// <summary>
        /// Inserts a new entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(TEntity entity);

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(TEntity entity);

        /// <summary>
        /// Deletes an entity.
        /// </summary>
        /// <param name="id">Id of the entity</param>
        void Delete(int id);
    }
}