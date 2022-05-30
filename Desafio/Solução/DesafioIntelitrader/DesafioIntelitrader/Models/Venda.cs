using DesafioIntelitrader.Enums;
using System;

namespace DesafioIntelitrader.Models
{
    public class Venda
    {
        public Venda(string codigoProduto, int quantidadeVendida, int situacao, int canal, int linha, Produto produto)
        {
            this.CodigoProduto = codigoProduto;
            this.QuantidadeVendida = quantidadeVendida;
            this.Situacao = RetornaSituacao(situacao);
            this.Canal = RetornaCanal(canal);
            this.MensagemDivergencia = produto == null ? ProdutoNaoEncontrado(linha, codigoProduto) : CriaMensagemDivergencia(linha, situacao);
        }

        public string CodigoProduto { get; set; }
        public int QuantidadeVendida { get; set; }
        public SituacaoVenda Situacao { get; set; }
        public CanalVenda Canal { get; set; }
        public string MensagemDivergencia { get; set; }

        public static string ProdutoNaoEncontrado(int linha, string codigoProduto)
        {
            return $"Linha {linha} - Código de Produto Não Encontrado {codigoProduto}";
        }            

        public static string CriaMensagemDivergencia(int linha, int situacao) =>
            situacao switch
            {                
                135 => $"Linha {linha} - Venda Cancelada",
                190 => $"Linha {linha} - Venda Não Finalizada",
                999 => $"Linha {linha} - Erro Desconhecido. Acionar Equipe de TI",
                _ => null
            };

        public static SituacaoVenda RetornaSituacao(int situacao) =>
            situacao switch
            {
                100 => SituacaoVenda.CONFIRMADA,
                102 => SituacaoVenda.PENDENTE,
                135 => SituacaoVenda.CANCELADA,
                190 => SituacaoVenda.NAO_CONFIRMADA,
                999 => SituacaoVenda.ERRO,
                _ => throw new Exception("Situação inválida!")
            };

        public static CanalVenda RetornaCanal(int canal) =>
           canal switch
           {
               1 => CanalVenda.REPRESENTANTE_COMERCIAL,
               2 => CanalVenda.WEBSITE,
               3 => CanalVenda.ANDROID,
               4 => CanalVenda.IPHONE,
               _ => throw new Exception("Canal inválido!")
           };


    }
}
