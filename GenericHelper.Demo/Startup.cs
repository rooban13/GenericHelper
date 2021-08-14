
using API.Extensions;
using FluentValidation.AspNetCore;
using GenericHelper.Demo.Helper;
using GenericHelper.Demo.Infrastructure.Data;
using GenericHelper.Demo.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;

namespace GenericHelper.Demo
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<StoreContext>(x =>
                x.UseSqlite(_config.GetConnectionString("DefaultConnection")));

            ConfigureServices(services);
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddControllers();
            services.AddFluentValidation(f=> {
                f.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            services.AddApplicationServices();
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });

            services.AddSwaggerGen((s) =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo() { Title = "GenericHelper Demo", Version = "V1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ExceptionMiddleware>();
             app.UseStatusCodePagesWithReExecute("/errors/{0}");


            app.UseRouting();
            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI((c) => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Generic Helper v1"); });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                //endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
