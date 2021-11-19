using Flurl.Http;
using Jr.Backend.Fornecedores.Domain;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Infrastructure.Gateway.Interfaces;
using Jr.Backend.Fornecedores.Infrastructure.Services.Interface;
using Jr.Backend.Fornecedores.Infrastructure.Services.Model.ApiBrasil;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Infrastructure.Services
{
    public class ApiBrasilService : IApiBrasilService
    {
        private readonly IApiBrasilGatewayClient gatewayClient;
        private readonly IConfiguration configuration;

        public ApiBrasilService(IApiBrasilGatewayClient gatewayClient, IConfiguration configuration)
        {
            this.gatewayClient = gatewayClient;
            this.configuration = configuration;
        }

        public async Task<Fornecedor> ObterInformacoesDaEmpresaPorCnpj(string cnpj)
        {
            try
            {
                var uriCnpj = configuration["BasilApi:UriCnpj"];
                var uri = $"{uriCnpj}/{cnpj}";
                var gateway = await gatewayClient.RequestAsync(uri)
                    .AllowHttpStatus(HttpStatusCode.NotFound).GetAsync();

                if (gateway.StatusCode == (int)HttpStatusCode.NotFound)
                {
                    return default;
                }

                var response = await gateway.GetJsonAsync<ApiBrasilResponse>();

                return MapToDomain(response);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Fornecedor MapToDomain(ApiBrasilResponse response)
        {
            var cnaeSecundarios =
                response.CnaesSecundarios?.Select(x => new Domain.ValueObjects.CnaesSecundario(x.Codigo, x.Descricao)).ToList();

            var enderecos = new List<Endereco>()

            {
                new Endereco(response.Bairro, response.Cep, response.Municipio, response.Complemento,
                    response.DescricaoTipoLogradouro, response.Uf, response.Logradouro, response.Numero,
                    response.CodigoMunicipio)
            };

            var qsas = response.Qsa?.Select(x => new Domain.ValueObjects.Qsa(x.IdentificadorDeSocio, x.NomeSocio,
                x.CnpjCpfDoSocio, x.CodigoQualificacaoSocio, x.PercentualCapitalSocial, x.DataEntradaSociedade,
                x.CpfRepresentanteLegal, x.NomeRepresentanteLegal, x.CodigoQualificacaoRepresentanteLegal)).ToList();

            var telefones = new List<string>
            {
                response.DddTelefone1,
                response.DddFax,
                response.DddTelefone2
            };
            return new Fornecedor(response.CapitalSocial, response.CnaeFiscal, response.CnaeFiscalDescricao, cnaeSecundarios, response.Cnpj, response.CodigoNaturezaJuridica, response.DataExclusaoDoSimples, response.DataInicioAtividade, response.DataOpcaoPeloSimples, response.DataSituacaoCadastral, response.DataSituacaoEspecial, response.DescricaoMatrizFilial, response.DescricaoPorte, response.DescricaoSituacaoCadastral, enderecos, response.IdentificadorMatrizFilial, response.MotivoSituacaoCadastral, response.NomeCidadeExterior, response.NomeFantasia, response.OpcaoPeloMei, response.OpcaoPeloSimples, response.Porte, qsas, response.QualificacaoDoResponsavel, response.RazaoSocial, response.SituacaoCadastral, response.SituacaoEspecial, telefones);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                gatewayClient?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}