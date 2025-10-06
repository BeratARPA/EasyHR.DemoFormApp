using EasyHR.DemoFormApp.DataAccess.Abstract;
using EasyHR.DemoFormApp.DataAccess.Context;
using EasyHR.DemoFormApp.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EasyHR.DemoFormApp.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly EasyHRContext _context;

        public GenericRepository(EasyHRContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
        {
            if (filter != null)
            {
                return await _context.Set<T>().Where(filter).ToListAsync();
            }

            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(filter);
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
