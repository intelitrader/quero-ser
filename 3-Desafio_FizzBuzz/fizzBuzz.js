/*
Link do desafio:
https://dojopuzzles.com/problems/fizzbuzz/
*/

var num = 100;

function imprima(num) {
for(var i = 1; i <= num; i++) {
    i % 3 == 0 && i % 5 == 0 ? console.log("FizzBuzz") : false
    i % 3 == 0 && i % 5 != 0 ? console.log("Fizz") : false
    i % 3 != 0 && i % 5 == 0 ? console.log("Buzz") : false
    i % 3 != 0 && i % 5 != 0 ? console.log(i) : false
 }
}

imprima(num);
