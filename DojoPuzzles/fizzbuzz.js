/*
    Nome do desafio -----------:> FizzBuzz
    Link para o desafio -------:> https://dojopuzzles.com/problems/fizzbuzz/
    Como rodar esse desafio ---:> `node fizzbuzz.js` (via terminal)
*/


console.log('-=--=--=--=--=--=--=-')
console.log('DojoPuzzle: FizzBuzz');
console.log('-=--=--=--=--=--=--=-')

// Laço de repetição FOR que percorre todos os números entre 0 e 100 (um a um)
for (let num = 1; num <= 100; num++) {

    // Caso o número seja divisível por 3 e por 5, ele é automaticamente 
    // divisível por 15, pois (3 x 5 = 15), logo `FizzBuzz` é exibido  
    if (num % 15 == 0) {
        console.log('FizzBuzz')
    } 
    
    // Caso o número seja divisível somente por 3 é exibido `Fizz`  
    else if (num % 3 == 0) {
        console.log('Fizz')
    } 
    
    // Caso o número seja divisível somente por 5 é exibido `Buzz`
    else if (num % 5 == 0) {
        console.log('Buzz')
    } 

    // Caso o número não seja divisível nem por 3 nem por 5, temos 
    // a exibição do número  
    else {
        console.log(num);
    }
}