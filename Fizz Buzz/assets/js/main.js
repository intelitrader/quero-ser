function chamarFizzBuzz() {

    for (let i = 1; i <= 100; i++) {

        let numero;

        if (i % 3 == 0 && i % 5 == 0) {

            numero = "FizzBuzz";
        }
        else if (i % 3 == 0) {

            numero = "Fizz";

        } else if (i % 5 == 0) {

            numero = "Buzz";

        }

        else {

            numero = i;

        }
        console.log(numero);
    }

}

