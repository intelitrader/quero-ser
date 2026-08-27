import { FileHandler } from '../utils/file-handler.js';

export class Canal{
    
    qtd_array = [0,0,0,0];
    canal_array = ['1 - Representantes','2 - Website','3 - App m�vel Android','4 - App m�vel iPhone'];
    
    canais(vendas){
        for(let i=0; i<vendas.length;i++){
            if(vendas[i].status == 100 || vendas[i].status == 102 ){
             
                
                if(vendas[i].canal==="1"){
                    this.qtd_array[0]+= vendas[i].qtd_vendida
                }
                else if(vendas[i].canal==="2"){
                    this.qtd_array[1]+= vendas[i].qtd_vendida
                }
                else if(vendas[i].canal==="3"){
                    this.qtd_array[2]+= vendas[i].qtd_vendida
                }
                else if(vendas[i].canal==="4"){
                    this.qtd_array[3]+= vendas[i].qtd_vendida
                }
                
            }
           
        }

        this.imprime();
    }

    imprime() {


        let impressao = 'Quantidades de Vendas por canal';
        impressao = impressao + '\n\n';
        impressao = impressao + 'Canal                  QtVendas\n';

        for(let i=0; i<this.qtd_array.length; i++ ){
            
            let espc=this.calc_espaco(this.canal_array[i].length,String(this.qtd_array[i]).length)
            impressao = impressao + this.canal_array[i] + espc + this.qtd_array[i]+'\n'


        }

        FileHandler.writeFile('./TOTCANAIS.TXT',impressao)
          
    }

    calc_espaco(valor1, valor2){
        let espc = ''   
        let tam=31-(valor1+valor2)
        for(let i=0; i<tam;i++){
            espc=espc+" ";
        }
        return espc
    }
}