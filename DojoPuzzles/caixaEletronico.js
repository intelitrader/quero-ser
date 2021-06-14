// https://dojopuzzles.com/problems/caixa-eletronico/


// importando modulo do node.js que nos permite ler dados 
const readline = require("readline");

// Cria a interface
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

console.log()
console.log('################################')
console.log('####### Caixa Eletrônico #######')
console.log('################################')
console.log()


// Pergunta e Lê a resposta no console
rl.question('Quanto você gostaria de sacar? ', (valor) => {
    console.clear()
    // Fecha a permissão de inserção de dados no console, o que permite a finalização do código por meio do node, 
    //pois a interface sempre esperá para que os dados sejam recebidos pelo input
    rl.close()

    // Mostra o valor requirido pelo suposto cliente
    console.log(`Valor a ser sacado: R$ ${valor}`);

    // Chama a função abaixo: quantidadeNotas() que depende da váriavel {valor}
    quantidadeNotas(valor)

});

// Cria a função quantidadeNotas() que depende da váriavel {valor}
const quantidadeNotas = (valor) => {
    // Variavéis de quantidades de notas
    let qtdNotas100 = 0
    let qtdNotas50 = 0
    let qtdNotas20 = 0
    let qtdNotas10 = 0

    try {
        // Se o valor for maior ou igual ao valor da nota
        //dá a quantidade de notas, pela divisão do valor solicitado pelo valor da nota
        //depois pega o valor da nota e subtrai pelo valor da nota multiplicado pela quantidade de notas
        //este ciclo ocorre com as notas de 100, 50, 20 e 10

        if (valor >= 100) {
            qtdNotas100 = parseInt(valor / 100)
            valor = valor - (100 * qtdNotas100)
        }
        if (valor >= 50) {
            qtdNotas50 = parseInt(valor / 50)
            valor = valor - (50 * qtdNotas50)
        }
        if (valor >= 20) {
            qtdNotas20 = parseInt(valor / 20)
            valor = valor - (20 * qtdNotas20)
        }
        if (valor >= 10) {
            qtdNotas10 = parseInt(valor / 10)
            valor = valor - (10 * qtdNotas10)
        }
        
        //Mostra os valores das notas e o valor restante no console
        console.log(`Notas de 100:  ${qtdNotas100} - R$${qtdNotas100 * 100},00`);
        console.log(`Notas de 50:  ${qtdNotas50} - R$${qtdNotas50 * 50},00`);
        console.log(`Notas de 20:  ${qtdNotas20} - R$${qtdNotas20 * 20},00`);
        console.log(`Notas de 10:  ${qtdNotas10} - R$${qtdNotas10 * 10},00`);
        console.log(`Valor Restante:  R$${valor },00`);
    } 
    //Caso dê errado, irá printar o erro no console
    catch (error) {
        console.error(error)
    }




}