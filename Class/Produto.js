export default class Produto {
    constructor(codigo, quantidade, quantidadeMinima, vendas, estoque, necessidade, transferencia){
        this.codigo = codigo;
        this.quantidade = quantidade;
        this.quantidadeMinima = quantidadeMinima;
        this.vendas = vendas;
        this.estoque = estoque;
        this.necessidade = necessidade;
        this.transferencia = transferencia;
    }
}