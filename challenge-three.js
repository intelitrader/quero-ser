const fizzBuzz = number => {
  if (number < 1 || number > 100) {
    return 'O numero deve estar entre 1 e 100';
  }

  const result = [];

  for (let i = 0; i <= number; i++) {
    switch (true) {
      case i % 3 === 0 && i % 5 === 0:
        result.push('FizzBuzz');
        break;

      case i % 3 === 0:
        result.push('Fizz');
        break;

      case i % 5 === 0:
        result.push('Buzz');
        break;

      default:
        result.push(i);
    }
  }
  return result;
};

console.log(fizzBuzz(15));
