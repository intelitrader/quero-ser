export class Produto{
    
    cod_produto;
    qtd;
    qtd_min;
    qtd_venda;
    qtd_necess;
    qtd_armazem_co;

    constructor(input_cod_produto, input_qtd, input_qtd_min){
        
        this.cod_produto = input_cod_produto;
        this.qtd = input_qtd;
        this.qtd_min = input_qtd_min;
        this.qtd_venda = 0;
        this.qtd_necess = 0;
        this.qtd_armazem_co = 0;

    }

}