using Flurl.Http;
using System;

namespace Jr.Backend.Fornecedores.Infrastructure.Gateway.Interfaces
{
    public interface IGatewayClient : IDisposable
    {
        /// <summary>
        ///  Realiza uma requisição utlizando a lib Flur com o cliente gateway já configurado.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        IFlurlRequest RequestAsync(string url);
    }
}