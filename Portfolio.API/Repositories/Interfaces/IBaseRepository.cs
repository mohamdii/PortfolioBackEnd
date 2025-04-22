using Portfolio.API.Data.Experience;

namespace Portfolio.API.BaseRepositoy.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IQueryable<T> FindAll();
        List<T> FindByName(string name);
        Employee AddEmployee(Employee employee);
    }
}
