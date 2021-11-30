using Jr.Backend.Fornecedores.Application.DependencyInjection;
using Jr.Backend.Fornecedores.Infrastructure.DependencyInjection;
using Jror.Backend.Libs.Api.DependencyInjection;
using Jror.Backend.Libs.API.Abstractions;
using Jror.Backend.Libs.Framework.DependencyInjection;
using Jror.Backend.Libs.Security.DependencyInjection;
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
        private readonly JrorApiOption jrApiOption;

        /// <inheritdoc/>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            jrApiOption = new JrorApiOption
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
            services.AddServiceDependencyJrorSecurityApi();
            services.AddServiceDependencyJrorApiSwagger(Configuration, () => jrApiOption);
            services.AddServiceDependencyApplication(Configuration);
            services.AddServiceDependencyInfrastructure();
            services.AddServiceDependencyJrorFramework();
        }

        /// <inheritdoc/>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseJrorApiSwaggerSecurity(env, () => jrApiOption);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}