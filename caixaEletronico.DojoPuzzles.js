// https://dojopuzzles.com/problems/caixa-eletronico/

function sacar(valor) {
  let notas = [100, 50, 20, 10];
  let resultado = [];

  for (let i = 0; i < notas.length; i++) {
    let quantidade = Math.floor(valor / notas[i]); 
    resultado.push(quantidade);
    valor -= quantidade * notas[i]; 
  }

  return resultado;
}

let valorSaque = 280;
let resultado = sacar(valorSaque);
console.log(`Valor do Saque: R$ ${valorSaque},00 - Resultado Esperado: Entregar ${resultado[0]} nota(s) de R$100,00, ${resultado[1]} nota(s) de R$50,00, ${resultado[2]} nota(s) de R$20,00 e ${resultado[3]} nota(s) de R$10,00.`);
