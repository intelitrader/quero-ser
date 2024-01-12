// Geração de Fatores Primos: https://dojopuzzles.com/problems/geracao-de-fatores-primos/

function PrimeFactors(number) {
  let factors = [];
  let divisor = 2;

  while (number > 1) {
    if (number % divisor === 0) {
      number /= divisor;
      if (factors.includes(divisor)) {
        continue;
      }
      factors.push(divisor);
    } else {
      divisor++;
    }
  }

  return factors;
}

// Exemplo de uso
const number = 412;
const result = PrimeFactors(number);
console.log(result);
