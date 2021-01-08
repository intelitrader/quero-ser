// Números divisiveis por outro número tem resto igual à 0

for (let i = 1; i <= 100; i++) {
    // Divisível por 3?
    if (i % 3 == 0) {
        // Divisível por 3 e 5?
        if ((i % 3) == 0 && (i % 5) == 0) {
            console.log('FizzBuzz');
        }
        else {
            console.log('Fizz');
        }
    }
    // Divisível por 5?
    else if (i % 5 == 0) {
        // Divisível por 3 e 5?
        if ((i % 3) == 0 && (i % 5) == 0) {
            console.log('FizzBuzz');
        }
        else {
            console.log('Buzz');
        }
    }
    // Caso NÃO for divisível por 3 ou 5?
    else {
        console.log(i)
    }
}