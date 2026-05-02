using DesafioIntelitrader.Enums;
using DesafioIntelitrader.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesafioIntelitrader.Service
{
    public static class RelatoriosService
    {        
        public static List<VendasConfirmadas> Relatorio01_VendasConfirmadas(List<Produto> produtos, List<Venda> vendas)
        {
            var vendasConfirmadas = (from p in produtos
                                     join v in vendas on p.CodigoProduto equals v.CodigoProduto
                                     where v.Situacao == SituacaoVenda.CONFIRMADA || v.Situacao == SituacaoVenda.PENDENTE
                                     group new { p, v } by new { p.CodigoProduto } into gb
                                     let qtVendas = gb.Sum(x => x.v.QuantidadeVendida)
                                     let firstGroup = gb.FirstOrDefault()
                                     let produtoBase = firstGroup.p
                                     let vendaBase = firstGroup.v
                                     let estoquePosVendas = produtoBase.Quantidade - qtVendas
                                     let necessidadeReposicao = estoquePosVendas < produtoBase.QuantidadeMinimaCO ? (produtoBase.QuantidadeMinimaCO - estoquePosVendas) : 0
                                     select new VendasConfirmadas
                                     {
                                         Produto = produtoBase.CodigoProduto,
                                         QtCO = produtoBase.Quantidade,
                                         QtMin = produtoBase.QuantidadeMinimaCO,
                                         QtVendas = qtVendas,
                                         EstoquePosVendas = estoquePosVendas,
                                         NecessidadeReposicao = necessidadeReposicao,
                                         QuantidadeTransferir = necessidadeReposicao > 1 && necessidadeReposicao < 10 ? 10 : necessidadeReposicao
                                     }).ToList();
            return vendasConfirmadas;
        }

        public static List<Venda> Relatorio02_Divergencias(List<Venda> vendas)
        {
            var vendasDivergentes = new List<Venda>();
            foreach (var venda in vendas)
            {
                if (!string.IsNullOrEmpty(venda.MensagemDivergencia))
                    vendasDivergentes.Add(venda);
            }

            return vendasDivergentes;
        }

        public static List<VendaCanal> Relatorio03_QtVendasPorCanal(List<Venda> vendas)
        {
            var query = (from v in vendas
                         where v.Situacao == SituacaoVenda.CONFIRMADA || v.Situacao == SituacaoVenda.PENDENTE
                         orderby (int)v.Canal ascending
                         group new { v } by new { v.Canal } into gb
                         select new VendaCanal
                         {
                             Canal = $"{(int)gb.Key.Canal} - {gb.Key.Canal}",
                             QtVendas = gb.Sum(x => x.v.QuantidadeVendida)
                         }).ToList();

            return query;
        }
    }
}
