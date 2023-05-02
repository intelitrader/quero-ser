export default class Produto {
    constructor(codigo, quantidade, quantidadeMinima, vendas, estoque, necessidade, transferencia){
        this.codigo = isNaN(codigo) ? 0 : codigo;
        this.quantidade = isNaN(quantidade) ? 0 : quantidade;
        this.quantidadeMinima = isNaN(quantidadeMinima) ? 0 : quantidadeMinima;
        this.vendas = vendas ?? 0;
        this.estoque = estoque ?? 0;
        this.necessidade = necessidade ?? 0;
        this.transferencia = transferencia ?? 0;
    }
}