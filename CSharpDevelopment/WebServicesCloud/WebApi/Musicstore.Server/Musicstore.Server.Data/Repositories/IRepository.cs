using System.Linq;

namespace Musicstore.Server.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll { get; }
        T GetById(int id);
        T Add(T entity);
        T Update(T entity);
        void Delete(int id);
    }
}
