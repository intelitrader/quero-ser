// caixa eletronico

function caixaEletronico(valor){
    let nota100 = 0
    let nota50 = 0
    let nota20 = 0
    let nota10 = 0
  
    if(valor >= 100){
      nota100 = parseInt(valor / 100);
      valor = valor - (nota100 * 100);
    }
    if(valor >= 50){
      nota50 =  parseInt(valor / 50);
      valor = valor - (nota50 * 50);
    }
    if(valor >= 20){
      nota20 = parseInt(valor / 20);
      valor = valor - (nota20 * 20);
    }
    if(valor >= 10){
      nota10 = parseInt(valor / 10);
      valor = valor - (nota10 * 10);
    }      
  
    console.log("Notas de 100: " + nota100 + " - " + "R$"+ nota100 * 100 + ",00")
    console.log("Notas de 50: " + nota50 + " - " + "R$"+ nota50 * 50 + ",00")
    console.log("Notas de 20: " + nota20 + " - " + "R$"+ nota10 * 20 + ",00")
    console.log("Notas de 10: " + nota10 + " - " + "R$"+ nota10 * 10 + ",00")
  
    console.log("Valor Restante: R$" + valor + ",00")
  }
  
  caixaEletronico(32)