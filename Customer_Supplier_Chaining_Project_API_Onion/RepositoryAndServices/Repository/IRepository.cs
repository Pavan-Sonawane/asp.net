using System.Linq.Expressions;

namespace RepositoryAndServices.Repository
{
    public interface IRepository<T>
    {
        T Find(int id);
        IEnumerable<T> FindAll();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }

}
