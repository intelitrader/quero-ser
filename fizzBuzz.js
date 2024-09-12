function fizzBuzz() {
  for (let i = 1; i <= 100; i += 1){
    const testFizz = i % 3;
    const testBuzz = i % 5;
  
    if (testFizz === 0 && testBuzz !== 0) {
      console.log('Fizz'); 
    } else if (testFizz !== 0 && testBuzz === 0) {
      console.log('Buzz');
    } else if (testFizz === 0 && testBuzz === 0) {
      console.log('FizzBuzz');
    } else console.log(i);
  }
}

fizzBuzz();

// https://dojopuzzles.com/problems/fizzbuzz/