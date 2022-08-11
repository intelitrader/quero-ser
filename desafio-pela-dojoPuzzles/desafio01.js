/*
FizzBuzz
Endereço: https://dojopuzzles.com/problems/fizzbuzz/
Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha,
com as seguintes exceções: https://dojopuzzles.com/problems/fizzbuzz/
Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;
Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.
 */

 class Buzz {
     constructor() {
         for (let i = 1; i <= 100; i++) {
             if (i % 15 == 0) console.log(i + " FizzBuzz");
             else if (i % 3 == 0) console.log(i + " Fizz");
             else if (i % 5 == 0) console.log(i + " Buzz");
         }
     }

}

let buuz = new Buzz()
Buzz.constructor()
