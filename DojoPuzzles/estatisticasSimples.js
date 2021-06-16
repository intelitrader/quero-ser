// https://dojopuzzles.com/problems/calculando-estatisticas-simples/


const readline = require("readline");

// Cria a interface
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Pergunta e Lê a resposta no console
rl.question('Digite sua lista, separada por ( , ) : ', (lista) => {
    console.clear()
    // Fecha a permissão de inserção de dados no console, o que permite a finalização do código por meio do node, 
    //pois a interface sempre esperá para que os dados sejam recebidos pelo input
    rl.close()

    // Mostra o valor requirido pelo suposto cliente
    console.log('####### Calculando estatísticas simples #######')
    console.log()

    console.log(`Lista (${lista})`);

    // Chama a função abaixo: calculoLista() que depende da váriavel {lista}
    calculoLista(lista)

});

const calculoLista = (valor) => {
    try {

        // Separa os valores da lista dentro do array lista
        lista = valor.split(',');

        // Pega o número de elementos da lista
        let length = lista.length;

        // declaro a variável sum
        let sum = 0

        for (i = 0; i < length; i++) {
            lista[i] = +parseInt(lista[i])
             sum += parseInt(lista[i])
        }
        
        // declaro a variável max que pega o maior valor da Lista
        let max = Math.max(...lista);

        // declaro a variável min que pega o menor valor da Lista
        let min = Math.min(...lista);

        // declaro a variável avg que faz a média dos valores da 
        //lista atráves da soma dividida pela quantidade de elementos da lista
        let avg = (sum / length)

        // declaro a variável sumSquared que faz o valor da soma dos ao quadrado   
        let sumSquared = Math.pow(sum,2)

        // mostra todos os valores no console
        console.log(`Valor máximo: ${max}`)
        console.log(`Valor mínimo: ${min}`)
        console.log(`Número de elementos na seqüência: ${length}`)
        console.log(`Valor médio:  ${avg}`)
        console.log(`Soma dos elementos na seqüência:  ${sum}`)
        console.log(`Soma dos elementos na seqüência ao quadrado:  ${sumSquared}`)

    //Caso algo dê errado, irá printar o erro no console
    } catch (error) {
        console.error(error)
    }

}