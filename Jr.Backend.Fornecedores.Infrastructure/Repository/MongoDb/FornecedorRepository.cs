using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jror.Backend.Libs.Infrastructure.MongoDB.Repository;

namespace Jr.Backend.Fornecedores.Infrastructure.Repository.MongoDb
{
    public class FornecedorRepository : MongoRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }
    }
}