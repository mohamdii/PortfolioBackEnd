using Microsoft.EntityFrameworkCore;
using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.Data.Experience;
using Portfolio.API.DbContext;
using System.Runtime.InteropServices;

namespace Portfolio.API.BaseRepositoy
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;   
        }

        public Employee AddEmployee(Employee employee)
        {

            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> FindByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
