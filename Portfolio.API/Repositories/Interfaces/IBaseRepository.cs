using Portfolio.API.Data.Experience;

namespace Portfolio.API.BaseRepositoy.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        List<T> FindByName(string name);
        T Add(T obj);
        T Update(int id);
    }
}
