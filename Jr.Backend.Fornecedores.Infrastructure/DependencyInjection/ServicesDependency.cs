using Flurl.Http.Configuration;
using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Gateway;
using Jr.Backend.Fornecedores.Infrastructure.Gateway.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Repository.MongoDb;
using Jr.Backend.Fornecedores.Infrastructure.Services;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Jr.Backend.Fornecedores.Infrastructure.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyInfrastructure(this IServiceCollection services)
        {
            services.AddServiceDependencyJrorInfrastructureMongoDb(ConnectionType.DirectConnection);

            services.AddScoped<IFornecedorRepository>(p =>
            {
                var mongoContext = p.GetService<IMongoContext>();
                return new FornecedorRepository(mongoContext, nameof(Fornecedor));
            });
            services.AddScoped<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
            services.AddScoped<IApiBrasilGatewayClient, ApiBrasilGatewayClient>();
            services.AddScoped<IApiBrasilService, ApiBrasilService>();
        }
    }
}