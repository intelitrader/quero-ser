// https://dojopuzzles.com/problems/fizzbuzz/

const fizzbuzz = (num) => {
  if (num % 15 === 0) {
    return 'fizzbuzz';
  } else if (num % 3 === 0) {
    return 'fizz';
  } else if (num % 5 === 0) {
    return 'buzz';
  } else {
    return num;
  }
}

console.log(fizzbuzz(15));