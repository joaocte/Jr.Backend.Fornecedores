using Jr.Backend.Fornecedores.Infrastructure.Entity;
using Jr.Backend.Fornecedores.Infrastructure.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.Abstractions.Interfaces;
using Jr.Backend.Libs.Infrastructure.MongoDB.Repository;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace Jr.Backend.Fornecedores.Infrastructure.Repository.MongoDb
{
    public class FornecedorRepository : MongoRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(IMongoContext context, string collectionName) : base(context, collectionName)
        {
        }

        public async Task<bool> ExistsAsync(string cnpj, CancellationToken cancellationToken = default)
        {
            var filter = Builders<Fornecedor>.Filter
        .Eq(z => z.Cnpj, cnpj);
            var data = await _dbSet.FindAsync(filter, null, cancellationToken).ConfigureAwait(false);

            return await data.AnyAsync(cancellationToken: cancellationToken);
        }
    }
}