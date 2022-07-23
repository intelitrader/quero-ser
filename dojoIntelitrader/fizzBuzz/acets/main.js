function criaParagrafo() {
    fizzBuzz = document.createElement('p');
    document.querySelector('.result').appendChild(fizzBuzz);
};

function analizaFizzBuzz() {

    for (let n = 0; n <= 100; n++) {

        if ((n % 3 === 0) && (n % 5 === 0)) {
            criaParagrafo();
            fizzBuzz.innerHTML += `FizzBuzz`;

        } else if (n % 5 === 0) {
            criaParagrafo();
            fizzBuzz.innerHTML += `Buzz`

        } else if (n % 3 === 0) {
            criaParagrafo();
            fizzBuzz.innerHTML += `Fizz`

        } else {
            criaParagrafo();
            fizzBuzz.innerHTML += `${n}`
        }
    }
};