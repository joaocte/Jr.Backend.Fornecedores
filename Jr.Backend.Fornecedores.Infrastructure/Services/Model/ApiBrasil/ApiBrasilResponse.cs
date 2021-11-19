using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Jr.Backend.Fornecedores.Infrastructure.Services.Model.ApiBrasil
{
    public class ApiBrasilResponse
    {
        [JsonProperty("cnpj")]
        public string Cnpj { get; set; }

        [JsonProperty("identificador_matriz_filial")]
        public int IdentificadorMatrizFilial { get; set; }

        [JsonProperty("descricao_matriz_filial")]
        public string DescricaoMatrizFilial { get; set; }

        [JsonProperty("razao_social")]
        public string RazaoSocial { get; set; }

        [JsonProperty("nome_fantasia")]
        public string NomeFantasia { get; set; }

        [JsonProperty("situacao_cadastral")]
        public int SituacaoCadastral { get; set; }

        [JsonProperty("descricao_situacao_cadastral")]
        public string DescricaoSituacaoCadastral { get; set; }

        [JsonProperty("data_situacao_cadastral")]
        public DateTime DataSituacaoCadastral { get; set; }

        [JsonProperty("motivo_situacao_cadastral")]
        public int MotivoSituacaoCadastral { get; set; }

        [JsonProperty("nome_cidade_exterior")]
        public string NomeCidadeExterior { get; set; }

        [JsonProperty("codigo_natureza_juridica")]
        public int CodigoNaturezaJuridica { get; set; }

        [JsonProperty("data_inicio_atividade")]
        public DateTime DataInicioAtividade { get; set; }

        [JsonProperty("cnae_fiscal")]
        public int CnaeFiscal { get; set; }

        [JsonProperty("cnae_fiscal_descricao")]
        public string CnaeFiscalDescricao { get; set; }

        [JsonProperty("descricao_tipo_logradouro")]
        public string DescricaoTipoLogradouro { get; set; }

        [JsonProperty("logradouro")]
        public string Logradouro { get; set; }

        [JsonProperty("numero")]
        public string Numero { get; set; }

        [JsonProperty("complemento")]
        public string Complemento { get; set; }

        [JsonProperty("bairro")]
        public string Bairro { get; set; }

        [JsonProperty("cep")]
        public string Cep { get; set; }

        [JsonProperty("uf")]
        public string Uf { get; set; }

        [JsonProperty("codigo_municipio")]
        public int CodigoMunicipio { get; set; }

        [JsonProperty("municipio")]
        public string Municipio { get; set; }

        [JsonProperty("ddd_telefone_1")]
        public string DddTelefone1 { get; set; }

        [JsonProperty("ddd_telefone_2")]
        public string DddTelefone2 { get; set; }

        [JsonProperty("ddd_fax")]
        public string DddFax { get; set; }

        [JsonProperty("qualificacao_do_responsavel")]
        public int QualificacaoDoResponsavel { get; set; }

        [JsonProperty("capital_social")]
        public decimal CapitalSocial { get; set; }

        [JsonProperty("porte")]
        public int Porte { get; set; }

        [JsonProperty("descricao_porte")]
        public string DescricaoPorte { get; set; }

        [JsonProperty("opcao_pelo_simples")]
        public bool OpcaoPeloSimples { get; set; }

        [JsonProperty("data_opcao_pelo_simples")]
        public DateTime? DataOpcaoPeloSimples { get; set; }

        [JsonProperty("data_exclusao_do_simples")]
        public DateTime? DataExclusaoDoSimples { get; set; }

        [JsonProperty("opcao_pelo_mei")]
        public bool OpcaoPeloMei { get; set; }

        [JsonProperty("situacao_especial")]
        public string SituacaoEspecial { get; set; }

        [JsonProperty("data_situacao_especial")]
        public DateTime? DataSituacaoEspecial { get; set; }

        [JsonProperty("cnaes_secundarias")]
        public List<CnaesSecundario> CnaesSecundarios { get; set; }

        [JsonProperty("qsa")]
        public List<Qsa> Qsa { get; set; }
    }
}