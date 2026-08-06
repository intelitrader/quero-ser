/*
    Nome do desafio ----------:> Palavras Primas
    Link para o desafio ------:> https://dojopuzzles.com/problems/palavras-primas/
    Como rodar esse desafio --:> `node palavras-primas.js` (via terminal)
*/


// Importando o módulo do Node.js que permite a leitura de dados pelo terminal
const readline = require("readline");

// Criando a interface 
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});


// Criação da função challengeHeader() que cria o cabeçalho do desafio
function challengeHeader() {
    console.log('-=-=-=-=-=-=-=-=-=-=-=-=-=-=-')
    console.log('DojoPuzzle: Palavras Primas');
    console.log('-=-=-=-=-=-=-=-=-=-=-=-=-=-=-')
}

// Criação da função generateAlphabet() que gera o alfabeto com seus repectivos valores
function generateAlphabet() {
    let alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    let alphabetArray = alphabet.split('')
    let alphabetCollection = []

    for (let value = 0; value < alphabetArray.length; value++) {
        alphabetCollection.push({
            'ID': value + 1,
            'letter': alphabetArray[value] 
        })
    }

    return alphabetCollection
}

// Criação da função isPrimeNumber() verifica se um número é primo ou não
function isPrimeNumber(number) {

    for (let count = 2; count < number; count++) {
        if (number % count === 0) return 'Não é primo'
    }

    return 'É primo'
}

// Criação da função isPrimeWord() que faz a verificação se uma palavra se classifica como prima ou não
function isPrimeWord (words) {

    try {
        
        // Percorremos o array de palavras e eliminamos os espações desnecessários
        let wordsList = words.split(',').map( word => word.trim() )

        // Chamamos a função generateAlphabet() que traz a relação entre as letras e o seu valor
        let alphabet = generateAlphabet()

        console.log(`\nPalavras --:> [ ${wordsList} ]\n`)

        // Nesse primeiro laço percorremos as palavras e as dividimos por caracter
        for (let idx = 0; idx < wordsList.length; idx++) {

            let wordCharacters = wordsList[idx].split("")
            let sum = 0

            // Nesse segundo laço percorremos os caracteres de cada palavra e procuramos o seu
            // respectivo valor dentro da relação anteriormente já criada (palavra -> valor) e
            // realizamos a soma dos caracteres dessa palavra
            for (let el = 0; el < wordCharacters.length; el++) {
                let searchWord = alphabet.find(alphabet => alphabet.letter == wordCharacters[el])
                sum += searchWord.ID
            }

            // Após percorrer cada caracter e obter a soma, chamamos a função isPrimeNumber()
            // que verifica então por fim se a palvra se classifica como prima ou não  
            let result = isPrimeNumber(sum);

            // Aqui temos a exibição do resultado no console
            console.log(`${wordsList[idx]} -=-> Soma: ${sum} -=-> É primo: ${result}`)
        }

    } catch (error) {
        console.log(error);
    }

}

// Chamada da função que traz o cabeçalho do desafio
challengeHeader()


// Criação da pergunta e leitura da resposta no terminal
rl.question('Escreva uma lista de palavras, separando-as por virgula (,) : ', (wordsList) => {
    // Limpeza do console para melhor visibilidade
    console.clear()

    // Fechamento da instância da interface que permite a entrada dos dados no terminal
    rl.close()
    
    // Chamada da função que traz o cabeçalho do desafio
    challengeHeader()
    
    // Chamada da função isPrimeWord() que depende da variável `wordsList`
    isPrimeWord(wordsList)
}) 