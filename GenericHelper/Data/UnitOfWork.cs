using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace GenericHelper.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private Hashtable _repositories;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IGenericRepository<TEntity,T2> Repository<TEntity,T2>() where TEntity : BaseEntity<T2>
        {
            if (_repositories == null) _repositories = new Hashtable();

            var type = typeof(TEntity).Name; 

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<,>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity), typeof(T2)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IGenericRepository<TEntity,T2>)_repositories[type];
        }
    }
}
