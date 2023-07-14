// Números Felizes: https://dojopuzzles.com/problems/numeros-felizes/

function isHappyNumber(number) {
  let sumOfSquares = number;
  let visitedNumbers = {};

  while (sumOfSquares !== 1 && !visitedNumbers[sumOfSquares]) {
    visitedNumbers[sumOfSquares] = true;
    let digits = sumOfSquares.toString().split('').map(Number);
    sumOfSquares = digits.reduce((sum, digit) => sum + (digit * digit), 0);
  }

  return sumOfSquares === 1;
}
//Exemplos de uso
console.log(isHappyNumber(7)); // true
console.log(isHappyNumber(4)); // false