/*
  Desenvolva um programa que simule a entrega de notas quando um cliente efetuar um saque em um caixa eletrônico. Os requisitos básicos são os seguintes:

    >Entregar o menor número de notas;
    >É possível sacar o valor solicitado com as notas disponíveis;
    >Saldo do cliente infinito;
    >Quantidade de notas infinito (pode-se colocar um valor finito de cédulas para aumentar a dificuldade do problema);
    >Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00

  Exemplos:

    >Valor do Saque: R$ 30,00 – Resultado Esperado: Entregar 1 nota de R$20,00 e 1 nota de R$ 10,00.
    >Valor do Saque: R$ 80,00 – Resultado Esperado: Entregar 1 nota de R$50,00 1 nota de R$ 20,00 e 1 nota de R$ 10,00.
*/

console.log("Cash Machine Puzzle:");

function withdraw(value) {
  let money = value;
  let amount100 = 0;
  let amount50 = 0;
  let amount20 = 0;
  let amount10 = 0;

  while (money >= 100) {
    money -= 100;
    amount100++;
  }

  while (money >= 50) {
    money -= 50;
    amount50++;
  }

  while (money >= 20) {
    money -= 20;
    amount20++;
  }

  while (money >= 10) {
    money -= 10;
    amount10++;
  }

  if (value >= 10) {
    console.log(`Withdraw amount: $${value}\n\nReceived dollar bills $100: ${amount100}\nReceived dollar bills $50: ${amount50}\nReceived dollar bills $20: ${amount20}\nReceived dollar bills $10: ${amount10}\n\nRemaining amount: $${money.toFixed(2)}
    `);
  } else {
    console.log("Withdraw amount must be greater than $10.");
  }
}

withdraw(285);
