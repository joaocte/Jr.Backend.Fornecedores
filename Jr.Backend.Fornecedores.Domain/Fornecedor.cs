using Jr.Backend.Fornecedores.Domain.Commands.Request;
using Jr.Backend.Fornecedores.Domain.Validations;
using Jr.Backend.Fornecedores.Domain.ValueObjects;
using Jr.Backend.Fornecedores.Domain.ValueObjects.Enums;
using Jr.Backend.Libs.Domain.Abstractions;
using Jror.Backend.Libs.Extensions;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Jr.Backend.Fornecedores.Domain
{
    public class Fornecedor : Entity
    {
        public Fornecedor(
            decimal capitalSocial, int cnaeFiscal, string cnaeFiscalDescricao, List<CnaesSecundario> cnaesSecundarios,
            string cnpj, int codigoNaturezaJuridica, DateTime? dataExclusaoDoSimples, DateTime dataInicioAtividade,
            DateTime? dataOpcaoPeloSimples, DateTime dataSituacaoCadastral, DateTime? dataSituacaoEspecial,
            string descricaoMatrizFilial, string descricaoPorte, string descricaoSituacaoCadastral,
            List<Endereco> enderecos, int identificadorMatrizFilial, int motivoSituacaoCadastral,
            string nomeCidadeExterior, string nomeFantasia, bool opcaoPeloMei, bool opcaoPeloSimples, int porte,
            List<Qsa> qsa, int qualificacaoDoResponsavel, string razaoSocial, int situacaoCadastral,
            string situacaoEspecial, IEnumerable<string> telefones)
        {
            CapitalSocial = capitalSocial;
            CnaeFiscal = cnaeFiscal;
            CnaeFiscalDescricao = cnaeFiscalDescricao;
            CnaesSecundarios = cnaesSecundarios;
            Cnpj = cnpj;
            CodigoNaturezaJuridica = codigoNaturezaJuridica;
            DataExclusaoDoSimples = dataExclusaoDoSimples;
            DataInicioAtividade = dataInicioAtividade;
            DataOpcaoPeloSimples = dataOpcaoPeloSimples;
            DataSituacaoCadastral = dataSituacaoCadastral;
            DataSituacaoEspecial = dataSituacaoEspecial;
            DescricaoMatrizFilial = descricaoMatrizFilial;
            DescricaoPorte = descricaoPorte;
            DescricaoSituacaoCadastral = descricaoSituacaoCadastral;
            Enderecos = enderecos;
            IdentificadorMatrizFilial = identificadorMatrizFilial;
            MotivoSituacaoCadastral = motivoSituacaoCadastral;
            NomeCidadeExterior = nomeCidadeExterior;
            NomeFantasia = nomeFantasia;
            OpcaoPeloMei = opcaoPeloMei;
            OpcaoPeloSimples = opcaoPeloSimples;
            Porte = porte;
            Qsa = qsa;
            QualificacaoDoResponsavel = qualificacaoDoResponsavel;
            RazaoSocial = razaoSocial;
            SituacaoCadastral = situacaoCadastral;
            SituacaoEspecial = situacaoEspecial;
            Telefones = telefones;
            DataCadastro = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        [JsonConstructor]
        public Fornecedor(Guid id, bool aceiteTermosDeUso, decimal capitalSocial, string celular, int cnaeFiscal,
            string cnaeFiscalDescricao, List<CnaesSecundario> cnaesSecundarios, string cnpj, int codigoNaturezaJuridica,
            DateTime dataCadastro, DateTime? dataExclusaoDoSimples, DateTime dataInicioAtividade,
            DateTime? dataOpcaoPeloSimples, DateTime dataSituacaoCadastral, DateTime? dataSituacaoEspecial,
            string descricaoMatrizFilial, string descricaoPorte, string descricaoSituacaoCadastral,
            ICollection<string> emailContato, ICollection<string> emailFatura, List<Endereco> enderecos,
            int identificadorMatrizFilial, InformacoesBancarias informacoesBancarias, int motivoSituacaoCadastral,
            string nomeCidadeExterior, string nomeContato, string nomeFantasia, bool opcaoPeloMei,
            bool opcaoPeloSimples, int porte, List<Qsa> qsa, int qualificacaoDoResponsavel, string razaoSocial,
            int situacaoCadastral, string situacaoEspecial, IEnumerable<string> telefones) :
            this(capitalSocial, cnaeFiscal, cnaeFiscalDescricao, cnaesSecundarios, cnpj, codigoNaturezaJuridica, dataExclusaoDoSimples, dataInicioAtividade, dataOpcaoPeloSimples, dataSituacaoCadastral, dataSituacaoEspecial, descricaoMatrizFilial, descricaoPorte, descricaoSituacaoCadastral, enderecos, identificadorMatrizFilial, motivoSituacaoCadastral, nomeCidadeExterior, nomeFantasia, opcaoPeloMei, opcaoPeloSimples, porte, qsa, qualificacaoDoResponsavel, razaoSocial, situacaoCadastral, situacaoEspecial, telefones)

        {
            AceiteTermosDeUso = aceiteTermosDeUso;
            Celular = celular;
            DataCadastro = dataCadastro;
            EmailContato = emailContato;
            EmailFatura = emailFatura;
            NomeContato = nomeContato;
            InformacoesBancarias = informacoesBancarias;
            Id = id;
        }

        public Fornecedor(bool aceiteTermosDeUso, decimal capitalSocial, string celular, int cnaeFiscal,
            string cnaeFiscalDescricao, List<CnaesSecundario> cnaesSecundarios, string cnpj, int codigoNaturezaJuridica,
            DateTime dataCadastro, DateTime? dataExclusaoDoSimples, DateTime dataInicioAtividade,
            DateTime? dataOpcaoPeloSimples, DateTime dataSituacaoCadastral, DateTime? dataSituacaoEspecial,
            string descricaoMatrizFilial, string descricaoPorte, string descricaoSituacaoCadastral,
            ICollection<string> emailContato, ICollection<string> emailFatura, List<Endereco> enderecos,
            int identificadorMatrizFilial, InformacoesBancarias informacoesBancarias, int motivoSituacaoCadastral,
            string nomeCidadeExterior, string nomeContato, string nomeFantasia, bool opcaoPeloMei,
            bool opcaoPeloSimples, int porte, List<Qsa> qsa, int qualificacaoDoResponsavel, string razaoSocial,
            int situacaoCadastral, string situacaoEspecial, IEnumerable<string> telefones) :
            this(capitalSocial, cnaeFiscal, cnaeFiscalDescricao, cnaesSecundarios, cnpj, codigoNaturezaJuridica, dataExclusaoDoSimples, dataInicioAtividade, dataOpcaoPeloSimples, dataSituacaoCadastral, dataSituacaoEspecial, descricaoMatrizFilial, descricaoPorte, descricaoSituacaoCadastral, enderecos, identificadorMatrizFilial, motivoSituacaoCadastral, nomeCidadeExterior, nomeFantasia, opcaoPeloMei, opcaoPeloSimples, porte, qsa, qualificacaoDoResponsavel, razaoSocial, situacaoCadastral, situacaoEspecial, telefones)

        {
            AceiteTermosDeUso = aceiteTermosDeUso;
            Celular = celular;
            DataCadastro = dataCadastro;
            EmailContato = emailContato;
            EmailFatura = emailFatura;
            NomeContato = nomeContato;
            InformacoesBancarias = informacoesBancarias;
        }

        public bool AceiteTermosDeUso { get; private set; }
        public decimal CapitalSocial { get; private set; }
        public string Celular { get; private set; }
        public int CnaeFiscal { get; private set; }
        public string CnaeFiscalDescricao { get; private set; }
        public List<CnaesSecundario> CnaesSecundarios { get; private set; }
        public string Cnpj { get; private set; }
        public int CodigoNaturezaJuridica { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataExclusaoDoSimples { get; private set; }
        public DateTime DataInicioAtividade { get; private set; }
        public DateTime? DataOpcaoPeloSimples { get; private set; }
        public DateTime DataSituacaoCadastral { get; private set; }
        public DateTime? DataSituacaoEspecial { get; private set; }
        public string DescricaoMatrizFilial { get; private set; }
        public string DescricaoPorte { get; private set; }
        public string DescricaoSituacaoCadastral { get; private set; }

        public ICollection<string> EmailContato { get; private set; }
        public ICollection<string> EmailFatura { get; private set; }
        public List<Endereco> Enderecos { get; private set; }
        public int IdentificadorMatrizFilial { get; private set; }
        public InformacoesBancarias InformacoesBancarias { get; private set; }
        public int MotivoSituacaoCadastral { get; private set; }
        public string NomeCidadeExterior { get; private set; }
        public string NomeContato { get; private set; }
        public string NomeFantasia { get; private set; }
        public bool OpcaoPeloMei { get; private set; }
        public bool OpcaoPeloSimples { get; private set; }
        public int Porte { get; private set; }
        public List<Qsa> Qsa { get; private set; }
        public int QualificacaoDoResponsavel { get; private set; }
        public string RazaoSocial { get; private set; }
        public int SituacaoCadastral { get; private set; }
        public string SituacaoEspecial { get; private set; }
        public IEnumerable<string> Telefones { get; private set; }
        public StatusCadastro StatusCadastro { get; private set; }

        public void AdicionarInformacoesCommand(CadastrarFornecedorCommand command)
        {
            AceiteTermosDeUso = command.AceiteTermosDeUso;
            Celular = command.Celular;
            EmailContato = command.EmailContato;
            EmailFatura = command.EmailFatura;
            NomeContato = command.NomeContato;
            InformacoesBancarias = new InformacoesBancarias(command.InformacoesBancarias.Banco, command.InformacoesBancarias.Agencia, command.InformacoesBancarias.Conta, command.InformacoesBancarias.TipoConta);
            Validate(this, new FornecedorValidation());
        }

        public void AdicionarInformacoesCommand(AtualizarFornecedorCommand command)
        {
            Celular = string.IsNullOrWhiteSpace(command.Celular) ? Celular : command.Celular;
            EmailContato.AddRange(command.EmailContato);
            EmailFatura.AddRange(command.EmailFatura);
            NomeContato = string.IsNullOrWhiteSpace(command.NomeContato) ? NomeContato : command.NomeContato;
            InformacoesBancarias = new InformacoesBancarias(command.InformacoesBancarias.Banco, command.InformacoesBancarias.Agencia, command.InformacoesBancarias.Conta, command.InformacoesBancarias.TipoConta);
            Validate(this, new FornecedorValidation());
        }
    }
}