namespace Jr.Backend.Fornecedores.Domain.ValueObjects.Endereco
{
    public class EnderecoComercial : Endereco
    {
        public EnderecoComercial(Cep cep, Logradouro logradouro, Numero numero, Complemento complemento, Bairro bairro, Cidade cidade, Estado estado) : base(cep, logradouro, numero, complemento, bairro, cidade, estado)
        {
        }
    }
}