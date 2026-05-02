/* 
  Neste problema, você deverá exibir uma lista de 1 a 100, um em cada linha, com as seguintes exceções:
    > Números divisíveis por 3 devem aparecer como 'Fizz' ao invés do número;
    > Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
    > Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número.
 */

console.log("FizzBuzz Puzzle:");

for (let i = 1; i < 101; i++) {
  console.log((i % 3 ? "" : "Fizz") + (i % 5 ? "" : "Buzz") || i);
}

console.log("-----------------------------");
