using interworks_assignment.Data;
using interworks_assignment.Models.Base;
using interworks_assignment.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace interworks_assignment.Repositories
{
    public class Repository<T>: IRepository<T> where T : BaseEntity
    {
        protected DataContext _dataContext;
        protected DbSet<T> _dbSet;
        public Repository(DataContext dataContext)
        {
            this._dataContext = dataContext;
            this._dbSet = _dataContext.Set<T>();
        }

        public virtual IEnumerable<T> GetAll ()
        {
            return _dbSet;
        }
        public virtual T GetById(int id)
        {
           return _dbSet.Find(id);
        }

        public virtual void Create(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }


        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
