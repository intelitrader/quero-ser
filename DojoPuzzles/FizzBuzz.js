// Dentro de um loop for faço a contagem de 1 até 100
for(let numero = 1; numero <= 100; numero++ ){
    // Primeiro faço o teste se é divisível por ambos os números com o operador lógico (E), e então testo individualmente.
    if (numero % 3 == 0 && numero % 5 == 0) {
        console.log('FizzBuzz')
    } else if (numero % 3 == 0) {
        console.log('Fizz')
    } else if (numero % 5 == 0) {
        console.log('Buzz')
    } else {
        console.log(numero)
    }
}