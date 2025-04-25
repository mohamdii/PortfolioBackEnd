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

        public T Add(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public T Update(int id)
        {
            var obj = _context.Set<T>().Find(id);
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return obj;
        }
    }
}
