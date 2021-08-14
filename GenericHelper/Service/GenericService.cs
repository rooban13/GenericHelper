using AutoMapper;
using CSharpFunctionalExtensions;
using GenericHelper.Core;
using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GenericHelper.Service
{
    public   class GenericService<T,T2,T3,T4,T5> : IGenericService<T,T3,T4,T5> where T : BaseEntity<T5> where T2 : IGenericRepository<T,T5> where T3 : BaseSpecParams where T4 : class
    {
        private readonly T2 _repository;
        private readonly IMapper _mapper;
        public GenericService(T2 repository,IMapper  mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public virtual  Task<T> GetByIdAsync(T5 id)
        {
            return   _repository.GetByIdAsync(id);
        }

        public virtual Task<IReadOnlyList<T>> ListAllAsync()
        {
            return   _repository.ListAllAsync();
        }

        public virtual Task<T> GetEntityWithSpec(ISpecification<T> spec)
        {
            return _repository.GetEntityWithSpec(spec);
        }

        public virtual Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return _repository.ListAsync(spec) ;
        }

        public virtual Task<int> CountAsync(ISpecification<T> spec)
        {
            return _repository.CountAsync(spec);
        } 
        public virtual async Task<Result<T>> AddAsync(T entity)
        {
            Result<T> ret ;
            var exists = await _repository.GetByIdAsync(entity.Id);
            if (exists!=null)
            {
                return Result.Failure<T>("entity already exists");
            }
            T value = await _repository .AddAsync(entity);
            int i = await  SaveAsync();
            ret = i > 0 ? Result.Success<T>(value) : Result.Failure<T>("Failure");
            return ret;
        }

        public virtual async Task UpdateAsync(T entity)
        {
              _repository.Update(entity);
            await  SaveAsync();
        }

        public virtual Task<int> SaveAsync()
        {
           return  _repository.SaveAsync();
        }

        public virtual async Task<int> DeleteAsync(T5 id)
        {
            var entity = await GetByIdAsync(id);
            _repository.Delete(entity);
            var result =  await   SaveAsync();
            return result;
        }

        public virtual async Task<T4> GetByIdWithSpecAsync(T5 id)
        {
            var spec = GetSpecificationForGetById(id); 

            var entity = await GetEntityWithSpec(spec);

            if (entity == null) return null;

            return _mapper.Map<T, T4>(entity);
        }

        public virtual async Task< Pagination<T4>>  GetEntitiesWithSpecAsync(
          T3 specParams)
        {
            var spec = GetSpecification(specParams);

            var countSpec =   GetSpecificationForCount(specParams);

            var totalItems = await  CountAsync(countSpec);

            var products = await  ListAsync(spec);

            var data = _mapper
                .Map<IReadOnlyList<T>, IReadOnlyList<T4>>(products);

            return  new Pagination<T4>(specParams.PageIndex, specParams.PageSize, totalItems, data) ;
        }

        public virtual ISpecification<T> GetSpecification(T3 specParams)
        {
            return new BaseSpecification<T>();
        }
        public virtual ISpecification<T> GetSpecificationForCount(T3 specParams)
        {
            return new BaseSpecification<T>();
        }
        public virtual ISpecification<T> GetSpecificationForGetById(T5 id)
        {
            return new BasePrimaryIdSpecification<T,T5>(id);
        }
         
    }
}
