function FizzBuzz() {

    // Laço para pegar os numeros necessarios
    for (let index = 0; index < 101; index++) {

        // Verifica se o numero é multiplo de 5 e 3
        if ((index % 3) == 0 && (index % 5) == 0) {
            console.log("FizzBuzz")
        }
        // Verifica se o numero é multiplo de 3
         else if ((index % 3) == 0) {
            console.log("Fizz")
        }
        // Verifica se o numero é multiplo de 5
        else if ((index % 5) == 0) {
            console.log("Buzz")
        }
        // Lista apenas o número caso não seja multiplo de 3 ou 5
        else {
            console.log(index)
        }
    }
}

FizzBuzz();