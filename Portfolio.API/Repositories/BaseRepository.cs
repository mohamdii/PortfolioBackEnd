using Microsoft.EntityFrameworkCore;
using Portfolio.API.BaseRepositoy.Interfaces;
using Portfolio.API.DbContext;
using System.Linq.Expressions;

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
            return _context.Set<T>();
        }

        public async Task<T> FindById(int id)
        {
            var obj = await _context.Set<T>().FindAsync(id);
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Detached;
            }
            return obj;
        }
        public IQueryable<T> GetByQuery(Func<IQueryable<T>, IQueryable<T>> query)
        {
            return query(_context.Set<T>());
            
        }
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().Where(predicate);
        }
        public async Task<List<T>> FindByConditionAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            return await query.Where(predicate).ToListAsync();
        }

   

        public T Update(Expression<Func<T, bool>> id)
        {
            var obj = _context.Set<T>().Find(id);
            if (obj != null)
            {
                _context.Entry(obj).State = EntityState.Modified;
                _context.SaveChanges();
            }
            return obj;
        }

        public bool RemoveById(Expression<Func<T, bool>> id)
        {
            var obj = _context.Set<T>().FirstOrDefault(id);
            if (obj != null)
            {
                _context.Set<T>().Remove(obj);
                _context.SaveChanges();
                return true;
            }
            return false;

        }

        public T Update(int id)
        {
            throw new NotImplementedException();
        }
    }
}
