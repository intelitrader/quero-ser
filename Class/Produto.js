export default class Produto {
    constructor(codigo, quantidade, quantidadeMinima, vendas, estoque, necessidade, transferencia){
        this.codigo = codigo ?? 0;
        this.quantidade = quantidade ?? 0;
        this.quantidadeMinima = quantidadeMinima ?? 0;
        this.vendas = vendas ?? 0;
        this.estoque = estoque ?? 0;
        this.necessidade = necessidade ?? 0;
        this.transferencia = transferencia ?? 0;
    }
}