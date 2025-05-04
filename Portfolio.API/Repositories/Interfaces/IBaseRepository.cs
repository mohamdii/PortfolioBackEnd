using Portfolio.API.Data.Experience;
using System.Linq.Expressions;

namespace Portfolio.API.BaseRepositoy.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        bool RemoveById(Expression<Func<T, bool>> Id);
        Task<T> FindById(int id);
        T Add(T obj);
        T Update(int id);
    }
}
