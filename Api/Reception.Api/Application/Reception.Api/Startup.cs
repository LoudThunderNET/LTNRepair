using Common.Lib.AutoMapper.Dependency;
using ComponentRegistrar;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reception.Handlers.Order.Queries;
using Reception.Infrastructure;

namespace Reception.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddMediatR(typeof(GetOrderByIdQuery))
                    .AddInfrastructure(Configuration)
                    .AddAppServices(Configuration)
                    .AddDomainServices(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(cfg => {
                cfg.AllowAnyOrigin();
                cfg.AllowAnyMethod();
                cfg.AllowAnyHeader();
            });

            app.UseSwagger();

            app.UseSwaggerUI(o => 
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "Reception Api");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
