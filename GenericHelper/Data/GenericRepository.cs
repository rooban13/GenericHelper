using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericHelper.Data
{
    public class GenericRepository<T,T2> : IGenericRepository<T,T2> where T : BaseEntity<T2>  
    {
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> GetByIdAsync(T2 id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public virtual async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public virtual async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        private  IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T,T2>.GetQuery(_context.Set<T>().AsQueryable(), spec);
        }

        public virtual async Task<T> AddAsync(T entity)
        {
          await  _context.Set<T>().AddAsync(entity);
          return entity;
        }

        public virtual void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual Task<int> SaveAsync()
        {
          return  _context.SaveChangesAsync();
        }

        public  DbSet<T> Set()
        {
            return _context.Set<T>();
        }
    }
}
