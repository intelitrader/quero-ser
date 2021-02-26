// https://dojopuzzles.com/problems/numeros-felizes/

const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
  });

const numeroFeliz = (num) => {
    let novosNumeros = num.toString().split('');
    let novoNumero = novosNumeros
        .map(num => {
            return parseInt(num) ** 2;
        })
        .reduce((numAnterior, numAtual) => {
            return numAnterior + numAtual;
        })
    
    if (novoNumero === 1) return true;

    if (novoNumero === 4) return false

    return numeroFeliz(novoNumero)
}



rl.question('Insira um número para sabermos se ele é feliz ou triste: ', (entrada) => {
    
    if (numeroFeliz(entrada)) {
        console.log(`O numero ${entrada} é feliz!`);
    } else {
        console.log(`O numero ${entrada} não é feliz!`);
    } 
    
    rl.close();
});
