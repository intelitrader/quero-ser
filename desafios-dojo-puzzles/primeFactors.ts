// Link: https://dojopuzzles.com/problems/geracao-de-fatores-primos/
// Função que recebe um número e retorna true ou false, se número primo ou não.
function isPrimeNumber(number: number): boolean {
  let dividers: number[] = [];

  for (let i = 1; i <= number; i++) {
    if (number % i === 0) {
      dividers.push(i);
    }
  }

  if (!number) {
    throw new Error(`Pass a valid number. The argument is ${number}`);
  }

  return dividers.length === 2;
}
// Função que recebe um número e retorna o próximo número primo em ordem crescente à ele.
function generateNextPrimeNumber(number: number): number {
  let i = 1;
  while (!isPrimeNumber(number + i)) {
    i++;
  }
  return number + i;
}
// Função que recebe um array de números, multiplicando todos os items, e retornando o resultado da multiplicação.
function multiplyArrayNumbers(array: number[]): number {
  const result = array.reduce((acc, currentItem) => {
    return acc * currentItem;
  });
  return result;
}
// Função que recebe um número e retorna um array de números com os seus fatores primos.
function generatePrimeFactors(number: number): number[] {
  /* A lógica basicamente consiste em dividir o número da entrada o máximo possível
   ** por números primos, e adicionar o divisor ao array de fatores primos
   */
  // VARIÁVEIS
  let primeFactors: number[] = [];
  let primeFactorsMultiplied = 0;
  let primeNumber = 2;

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
