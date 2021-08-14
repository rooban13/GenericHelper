using CSharpFunctionalExtensions;
using GenericHelper.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericHelper.Core.Interface
{
    public interface IGenericService<T,T2,T3,T4> where T : BaseEntity<T4> where T2: BaseSpecParams where T3:class
    {
        Task<T> GetByIdAsync(T4 id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> GetEntityWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        Task<Result<T>> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task<int> SaveAsync();
        Task<T3> GetByIdWithSpecAsync(T4 id);
        Task<int> DeleteAsync(T4 id);

        Task<Pagination<T3>> GetEntitiesWithSpecAsync(
          T2 specParams);
    }
}
