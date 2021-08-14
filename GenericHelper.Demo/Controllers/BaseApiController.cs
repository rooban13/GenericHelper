using AutoMapper;
using CSharpFunctionalExtensions;
using GenericHelper.Core.Errors;
using GenericHelper.Core.Interface;
using GenericHelper.Core.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GenericHelper.Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController<T,T2,T3,T4,T5> : ControllerBase where T2: IGenericService<T,T3,T4,T5> where T:BaseEntity<T5> where T3:BaseSpecParams where T4 : class
    {
        protected readonly T2 _service;
        

        public BaseApiController(T2 service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<ActionResult<Pagination<T4>>> GetEntitiesAsync(
            [FromQuery] T3 specParms)
        {
            var result = await  _service.GetEntitiesWithSpecAsync(specParms);
            return Ok(result);
        }


        [HttpGet("{id}")]
        [ProducesResponseType( StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<T4>> GetByIdAsync(T5 id)
        {
            var entity = await _service.GetByIdWithSpecAsync(id);
            if (entity == null) return NotFound(new ApiResponse(404));
            return entity;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<T>> Post([FromBody] T product)
        { 
          Result<T> result =  await _service.AddAsync(product);

          if (result.IsFailure) 
                return BadRequest(new ApiResponse(400,result.Error));

            return Ok(result.Value);
        }


        [HttpPut]
        public async Task<ActionResult> Put(T5 id, [FromBody] T product)
        {
            product.Id = id;
            await  _service.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(T5 id)
        {
            await  _service.DeleteAsync(id);
             return NoContent();
        }

    }

}
