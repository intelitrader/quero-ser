//https://dojopuzzles.com/problems/entre-letras/

const readline = require('readline');

const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
  });

const entreLetras = (letra1, letra2) => { 
    letras = ["A" , "B" , "C" , "D" , "E" , "F" , "G" , "H" , "I" , "J" , "K" , "L" , "M" , "N" , "O" , "P" , "Q" , "R" , "S" , "T" , "U" , "V" , "W" , "X" , "Y" , "Z"]

    let indexLetra1 = letras.indexOf(letra1.toUpperCase()) + 1;
    let indexLetra2 = letras.indexOf(letra2.toUpperCase());

    console.log(indexLetra1);
    console.log(indexLetra2);


    if (indexLetra1 >= indexLetra2) return console.log('Não está na ordem alfabética');

    console.log(`${letra1}, ${letra2} =  ${indexLetra2 - indexLetra1}`);

}

rl.question('Insira as duas letras em ordem alfabética separadas por espaço: ', (entrada) => {
    
    let letras = entrada.replace(/\s+/g, '').split('')
    console.log(letras);
    entreLetras(letras[0], letras[1]);
   
    rl.close();
});


