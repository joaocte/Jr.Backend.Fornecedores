using Flurl.Http;
using Flurl.Http.Configuration;
using Jr.Backend.Fornecedores.Infrastructure.Gateway.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace Jr.Backend.Fornecedores.Infrastructure.Gateway
{
    public class ApiBrasilGatewayClient : IApiBrasilGatewayClient
    {
        private readonly IFlurlClient client;

        public ApiBrasilGatewayClient(IFlurlClientFactory flurlClientFactory, IConfiguration configuration)
        {
            var uriApiBrasil = configuration["BasilApi:UriBase"];
            client = flurlClientFactory.Get(uriApiBrasil);
            client.BaseUrl = uriApiBrasil;
        }

        public IFlurlRequest RequestAsync(string url)
        {
            return client.Request(url);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                client?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}