export class Venda{
    
    cod_produto;
    qtd_vendida;
    status;
    canal;

    constructor(input_cod_produto, input_qtd_vendida, input_status, input_canal){
        
        this.cod_produto = input_cod_produto;
        this.qtd_vendida = input_qtd_vendida;
        this.status = input_status;
        this.canal = input_canal;
    }

}