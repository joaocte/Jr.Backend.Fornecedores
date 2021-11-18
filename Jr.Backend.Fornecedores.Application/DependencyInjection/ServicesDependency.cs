using AutoMapper;
using Jr.Backend.Fornecedores.Application.AutoMapper;
using Jr.Backend.Fornecedores.Application.UseCase.AtualizarFornecedor;
using Jr.Backend.Fornecedores.Application.UseCase.CadastrarFornecedor;
using Jr.Backend.Fornecedores.Application.UseCase.ObterFornecedor;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace Jr.Backend.Fornecedores.Application.DependencyInjection
{
    public static class ServicesDependency
    {
        public static void AddServiceDependencyApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICadastrarFornecedorUseCase, CadastrarFornecedorUseCase>();
            services.Decorate<ICadastrarFornecedorUseCase, CadastrarFornecedorUseCaseValidation>();

            services.AddScoped<IAtualizarFornecedorUseCase, AtualizarFornecedorUseCase>();
            services.Decorate<IAtualizarFornecedorUseCase, AtualizarFornecedorValidationUseCase>();

            services.AddScoped<IObterFornecedorUseCase, ObterFornecedorUseCase>();

            services.AddMediatR(Assembly.GetExecutingAssembly());

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfileToDomain());
                mc.AddProfile(new MappingProfileToEntity());
                mc.AddProfile(new MappingProfileToEnvent());
                mc.AddProfile(new MappingProfileToResponse());
                mc.AddProfile(new MappingProfileToEnvent());
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddMassTransit(x =>
            {
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(config =>
                    {
                        var uri = configuration["RabbitSetting:UriBase"];
                        var user = configuration["RabbitSetting:User"];
                        var password = configuration["RabbitSetting:Password"];
                        var virtualHost = configuration["RabbitSetting:VirtualHost"];
                        config.Host(new Uri(uri), virtualHost, h =>
                        {
                            h.Username(user);
                            h.Password(password);
                        });
                    }
                ));
            });

            services.AddMassTransitHostedService();
        }
    }
}