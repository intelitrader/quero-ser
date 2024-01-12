import { FileHandler } from '../utils/file-handler.js';

export class Transfere{

    transferencias_array=[]

     transferencia(produtos,vendas) {
        for(let i=0; i<vendas.length;i++){
            if(vendas[i].status == 100 || vendas[i].status == 102 ){
                const produto = produtos.find(produto => produto.cod_produto === vendas[i].cod_produto);
                if(produto !== undefined){
                    produto.qtd_venda += vendas[i].qtd_vendida;
                    produto.qtd-=vendas[i].qtd_vendida

                    produto.qtd_necess = this.reposicao(produto.qtd_min, produto.qtd)
                    produto.qtd_armazem_co = this.armazem_co(produto.qtd_necess)
                }
            }
           
        }    
        this.transferencias_array = produtos
        this.imprime()

    } 
    
    reposicao(qtd_min, qtd_estoque){
        if(qtd_min<qtd_estoque){
            return 0;
        }
        else{
            return(qtd_min-qtd_estoque)
        }
    }

    armazem_co(produto){
        if(produto > 0 && produto < 10){
            return 10
        }
        else{
            return produto;
        }
    }

    imprime(){
        let impressao = 'Necessidade de Transfer�ncia Armaz�m para CO'
        impressao = impressao + '\n\n';
        impressao = impressao +'Produto  QtCO  QtMin  QtVendas  Estq.ap�s  Necess.  Transf. de\n'
        impressao = impressao +'                                   Vendas            Arm p/ CO\n'
        
        for(let i=0; i<this.transferencias_array.length;i++){
            let tam =0
            
            // COLUNA 1
            impressao = impressao + `${this.transferencias_array[i].cod_produto}`
            tam = this.transferencias_array[i].cod_produto.length
            
            // COLUNA 2
            let espc = this.calc_espaco(13, tam, String(this.transferencias_array[i].qtd+this.transferencias_array[i].qtd_venda).length)
            tam = tam + `${espc}${this.transferencias_array[i].qtd+this.transferencias_array[i].qtd_venda}`.length
            impressao = impressao + `${espc}${this.transferencias_array[i].qtd+this.transferencias_array[i].qtd_venda}`

            // COLUNA 3
            espc = this.calc_espaco(20,tam,String(this.transferencias_array[i].qtd_min).length)
            tam = tam + `${espc}${this.transferencias_array[i].qtd_min}`.length
            impressao = impressao + `${espc}${this.transferencias_array[i].qtd_min}`


            // COLUNA 4
            espc = this.calc_espaco(30,tam,String(this.transferencias_array[i].qtd_venda).length)
            tam = tam + `${espc}${this.transferencias_array[i].qtd_venda}`.length
            impressao = impressao + `${espc}${this.transferencias_array[i].qtd_venda}`

             // COLUNA 5
             espc = this.calc_espaco(41,tam,String(this.transferencias_array[i].qtd).length)
             tam = tam + `${espc}${this.transferencias_array[i].qtd}`.length
             impressao = impressao + `${espc}${this.transferencias_array[i].qtd}`

            // COLUNA 6
            espc = this.calc_espaco(50,tam,String(this.transferencias_array[i].qtd_necess).length)
            tam = tam + `${espc}${this.transferencias_array[i].qtd_necess}`.length
            impressao = impressao + `${espc}${this.transferencias_array[i].qtd_necess}`
            
            // COLUNA 7
            espc = this.calc_espaco(62,tam,String(this.transferencias_array[i].qtd_armazem_co).length)
            tam = tam + `${espc}${this.transferencias_array[i].qtd_armazem_co}`.length
            impressao = impressao + `${espc}${this.transferencias_array[i].qtd_armazem_co}\n`    
    
        }
            
        FileHandler.writeFile('./transfere.txt', impressao)
    
    }

    calc_espaco(col,valor1,valor2){
        let total = col-(valor1+valor2)
        let esp=''
        for(let i=0; i<total;i++){
          esp=esp+' '  
        }
        return esp
    }
}