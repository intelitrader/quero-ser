//https://dojopuzzles.com/problems/fizzbuzz/
//FizzBuzz

function listarNumeros () {
    
    for (let numero = 1; numero <= 100; numero++) {

        if (numero % 3 == 0 && numero % 5 == 0) {
            document.write("<p> FizzBuzz </p>");
            
        }else if (numero % 3 == 0) {
            document.write("<p> Fizz </p>");

        }else if (numero % 5 == 0) {
            document.write("<p> Buzz </p>");

        }else {
            document.write(`<p> ${numero} </p>`);
        }

    }
}

listarNumeros();