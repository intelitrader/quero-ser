/* Faça um programa que destaque a diferença entre duas string. Exemplo: Entradas: O pássaro amarelo caiu. 
O pássaro vermelho caiu. Saídas: O pássaro [amarel]o caiu. O pássaro [vermelh]o caiu. */

const primeiraString = "O pássaro amarelo caiu"
const segundaString = "O pássaro vermelho caiu"



let arrayPrimeiraString = primeiraString.split(" ")
let arraySegundaString = segundaString.split(" ")

let primeiraStringVerificada = ""
let segundaStringVerificada = ""

for (let i = 0; i < arrayPrimeiraString.length; i++) {

    if (arrayPrimeiraString[i] === arraySegundaString[i]) {
        primeiraStringVerificada += arrayPrimeiraString[i] + " "
        segundaStringVerificada += arraySegundaString[i] + " "
    } else {
        primeiraStringVerificada += "[" + arrayPrimeiraString[i] + "] "
        segundaStringVerificada += "[" + arraySegundaString[i] + "] "

    }
}

console.log(`${primeiraStringVerificada}. ${segundaStringVerificada}`)