using interworks_assignment.Models.Base;

namespace interworks_assignment.Repositories
{
    public interface IRepository<T> where T :BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
