/*
Link do Desafio:
https://dojopuzzles.com/problems/caixa-eletronico/
*/ 

import dados from 'readline-sync'

// Como proposto no desafio, coloquei um numero finito de notas para aumentar a dificuldade e praticar.

let quantidadeNotasNaMaquina = 22000;

console.log("Caixa Eletrônico");

console.log("Notas disponíveis de R$ 100,00; R$ 50,00; R$ 20,00 e R$ 10,00");
let valor = dados.question("Digite um valor para saque ou 0 para cancelar: ");
var restante = Number(valor);

do {
    if(restante > quantidadeNotasNaMaquina) {
        console.log("Não a cedulas disponíveis na maquina")
        break
    } 
    else if(restante >= 100) {
        restante = restante - 100
        console.log("1 nota de R$100,00");
    }
    else if(restante >= 50) {
        restante = restante - 50
        console.log("1 nota de R$50,00");
    }
    else if(restante >= 20) {
        restante = restante - 20
        console.log("1 nota de R$20,00");
    }
    else if(restante >= 10) {
        restante = restante - 10
        console.log("1 nota de R$10,00");
    } else {
        console.log("fim da operação");
        break
    }

} while(restante != 0)
