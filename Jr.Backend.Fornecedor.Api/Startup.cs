using Jr.Backend.Fornecedores.Application.DependencyInjection;
using Jr.Backend.Fornecedores.Infrastructure.DependencyInjection;
using Jr.Backend.Libs.API.Abstractions;
using Jr.Backend.Libs.API.DependencyInjection;
using Jr.Backend.Libs.Framework.DependencyInjection;
using Jr.Backend.Libs.Security.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Jr.Backend.Fornecedor.Api
{
    /// <inheritdoc/>
    public class Startup
    {
        private readonly JrApiOption jrApiOption;

        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrApiOption
            {
                Title = "Jr.Backend.Fornecedor.Api",
                Description = "Api de Cadastro de Fornecedores",
                Email = "joaocte@gmail.com",
                Uri = "https://github.com/joaocte/Jr.Backend.Fornecedor",
            };
        }

        /// <inheritdoc/>
        public IConfiguration Configuration { get; }

        /// <inheritdoc/>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddServiceDependencyJrSecurityApi();
            services.AddServiceDependencyJrApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrFramework();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrApiSwaggerSecurity(env, () => jrApiOption);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}