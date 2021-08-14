using GenericHelper.Core.Model;
using System;
using System.Threading.Tasks;

namespace GenericHelper.Core.Interface
{
    public interface IUnitOfWork : IDisposable
    {
       IGenericRepository<TEntity,T2> Repository<TEntity,T2>() where TEntity : BaseEntity<T2>;
        Task<int> Complete();
    }
}
