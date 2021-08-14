using GenericHelper.Core.Model;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericHelper.Core.Interface
{
    public interface IGenericRepository<T,T2> where T : BaseEntity<T2>
    {
        Task<T> GetByIdAsync(T2 id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<int> SaveAsync();
    }
}
