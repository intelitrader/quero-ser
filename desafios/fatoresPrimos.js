//https://dojopuzzles.com/problems/geracao-de-fatores-primos/

const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
  });


const gerarFatoresPrimos = (num) => {
    let fatores = [];
    
    for (let i = 2; i <= num; i++) {
        if (num % i === 0 ) {
            let aux = 0;
            for (let j = 2; j <= i; j++) {
                if (i % j === 0) aux++;
            }
            
            if (aux === 1) {
                let numb = num / i;
                let restoDivisao = 0;
                while (restoDivisao === 0) {
                    fatores.push(i);
                    restoDivisao = numb % i;
                    numb = numb / i;
                }      
            }
            aux = 0; 
        }
    }
    
    console.log(fatores);
}

rl.question('Insira um número para sabermos seus fatores primos: ', (entrada) => {
    
    gerarFatoresPrimos(entrada);
   
    rl.close();
});
