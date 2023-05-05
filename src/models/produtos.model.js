export class Produtos {
  codigo;
  qtdEstoque;
  qtdMinima;

  constructor(codigo, qtdEstoque, qtdMinima) {
    this.codigo = codigo;
    this.qtdEstoque = qtdEstoque;
    this.qtdMinima = qtdMinima;
  }
}
