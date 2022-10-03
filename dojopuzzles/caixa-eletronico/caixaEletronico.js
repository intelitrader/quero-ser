/**
 * Problema retirado de: https://dojopuzzles.com/problems/caixa-eletronico/
 * 
 * _Caixa Eletrônico_ 
 * 
 * DESCRIÇÃO
 * 
 * Desenvolva um programa que simule a entrega de notas quando um cliente efetuar um saque em um caixa eletrônico. Os requisitos básicos são os seguintes:

-Entregar o menor número de notas;
-É possível sacar o valor solicitado com as notas disponíveis;
-Saldo do cliente infinito;
-Quantidade de notas infinito (pode-se colocar um valor finito de cédulas para aumentar a dificuldade do problema);
-Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00!

Exemplos:

Valor do Saque: R$ 30,00 – Resultado Esperado: Entregar 1 nota de R$20,00 e 1 nota de R$ 10,00.
Valor do Saque: R$ 80,00 – Resultado Esperado: Entregar 1 nota de R$50,00 1 nota de R$ 20,00 e 1 nota de R$ 10,00.

*/

const retornaInfoSaque = (valor) => {
  let resto = 0;
  let quantNotas100 = Math.trunc(valor / 100);
  resto = valor % 100;
  let quantNotas50 = Math.trunc(resto / 50);
  resto = resto % 50;
  let quantNotas20 = Math.trunc(resto / 20);
  resto = resto % 20;
  let quantNotas10 = resto / 10;

  return [
    valor,
    { valorNota: 100, quantidade: quantNotas100 },
    { valorNota: 50, quantidade: quantNotas50 },
    { valorNota: 20, quantidade: quantNotas20 },
    { valorNota: 10, quantidade: quantNotas10 },
  ];
};

const mostraResultadoSaque = (resultadoSaque) => {
  console.log(`Valor do saque R$${resultadoSaque[0]},00`);
  for (let i = 1; i < resultadoSaque.length; i++) {
    if (resultadoSaque[i].quantidade !== 0) {
      console.log(
        `${resultadoSaque[i].quantidade} notas de R$${resultadoSaque[i].valorNota},00`
      );
    } else continue;
  }
  console.log(`_______FIM_______`);
  console.log(`\n`);
};

// Caso de teste 1
let dadosSaque = retornaInfoSaque(290);
mostraResultadoSaque(dadosSaque);

// Caso de teste 2
dadosSaque = retornaInfoSaque(310);
mostraResultadoSaque(dadosSaque);

// Caso de teste 3
dadosSaque = retornaInfoSaque(1790);
mostraResultadoSaque(dadosSaque);
