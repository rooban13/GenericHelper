using System.Linq;
using GenericHelper.Core.Interface;
using GenericHelper.Data;
using GenericHelper.Demo.Core.Entities;
using GenericHelper.Demo.Core.Interface;
using GenericHelper.Demo.Infrastructure.Data;
using GenericHelper.Demo.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{ 
public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<DbContext, StoreContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
           // services.AddScoped<IOrderService, OrderService>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped(typeof(IGenericRepository<,>), (typeof(GenericRepository<,>)));
            services.AddScoped<IProductService,  ProductService>();
            services.AddScoped<IProductTypeService, ProductTypeService>();
            services.AddScoped<ICustomerService, CustomerService>();
            //            services.Configure<ApiBehaviorOptions>(options =>
            //{
            //    options.InvalidModelStateResponseFactory = actionContext => 
            //    {
            //        var errors = actionContext.ModelState
            //            .Where(e => e.Value.Errors.Count > 0)
            //            .SelectMany(x => x.Value.Errors)
            //            .Select(x => x.ErrorMessage).ToArray();

            //        var errorResponse = new ApiValidationErrorResponse
            //        {
            //            Errors = errors
            //        };

            //        return new BadRequestObjectResult(errorResponse);
            //    };
            //});

            return services;
        }
    }
}