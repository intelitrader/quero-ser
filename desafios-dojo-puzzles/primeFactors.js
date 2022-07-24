// CÓDIGO COMPILADO DO MESMO ARQUIVO EM TYPESCRIPT
// Link: https://dojopuzzles.com/problems/geracao-de-fatores-primos/
// Função que recebe um número e retorna true ou false, se número primo ou não.
function isPrimeNumber(number) {
  var dividers = [];
  for (var i = 1; i <= number; i++) {
    if (number % i === 0) {
      dividers.push(i);
    }
  }
  if (!number) {
    throw new Error("Pass a valid number. The argument is ".concat(number));
  }
  return dividers.length === 2;
}
// Função que recebe um número e retorna o próximo número primo em ordem crescente à ele.
function generateNextPrimeNumber(number) {
  var i = 1;
  while (!isPrimeNumber(number + i)) {
    i++;
  }
  return number + i;
}
// Função que recebe um array de números, multiplicando todos os items, e retornando o resultado da multiplicação.
function multiplyArrayNumbers(array) {
  var result = array.reduce(function (acc, currentItem) {
    return acc * currentItem;
  });
  return result;
}
// Função que recebe um número e retorna um array de números com os seus fatores primos.
function generatePrimeFactors(number) {
  /* A lógica basicamente consiste em dividir o número da entrada o máximo possível
   ** por números primos, e adicionar o divisor ao array de fatores primos
   */
  // VARIÁVEIS
  var primeFactors = [];
  var primeFactorsMultiplied = 0;
  var primeNumber = 2;
  while (number > 1) {
    if (number % primeNumber === 0) {
      primeFactors.push(primeNumber);
      number = number / primeNumber;
      primeFactorsMultiplied = multiplyArrayNumbers(primeFactors);
    } else {
      primeNumber = generateNextPrimeNumber(primeNumber);
    }
  }
  return primeFactors;
}
