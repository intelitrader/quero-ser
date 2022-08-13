const fizzBuzz = () => {
  const array = [];

  for (let i = 1; i <= 100; i++) {
    if (i % 3 === 0 && i % 5 === 0) {
      array.push('FizzBuzz');
    } else if (i % 3 === 0) {
      array.push('Fizz');
    } else if (i % 5 === 0) {
      array.push('Buzz');
    } else {
      array.push(i);
    }
  }

  const stringWithLineBreaks = array.join('\n');

  console.log(stringWithLineBreaks);
  return stringWithLineBreaks;
};

fizzBuzz();
