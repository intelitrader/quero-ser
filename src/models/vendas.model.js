import { Produtos } from "./produtos.model.js";

export class Vendas {
  codigoProd;
  qtdVenda;
  situacao;
  canalCod;

  constructor(codigoProd, qtdVenda, situacao, canalCod) {
    this.codigoProd = codigoProd;
    this.qtdVenda = qtdVenda;
    this.situacao = situacao;
    this.canalCod = canalCod;
  }
}

export class VendasConfirmadas extends Produtos {
  qtdVendida;
  qtdEstoqueAtual;
  qtdNecessaria;
  qtdTransf;

  constructor(
    codigo,
    qtdEstoqueInicial,
    qtdMinima,
    qtdVendida,
    qtdEstoqueAtual,
    qtdNecessaria,
    qtdTransf
  ) {
    super(codigo, qtdEstoqueInicial, qtdMinima);

    this.qtdVendida = qtdVendida;
    this.qtdEstoqueAtual = qtdEstoqueAtual;
    this.qtdNecessaria = qtdNecessaria;
    this.qtdTransf = qtdTransf;
  }
}
