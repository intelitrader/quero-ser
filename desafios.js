// FAVOR DESCOMENTAR SOMENTE O CÓDIGO A SER EXECUTADO


//#1 fizzbuzz

/*
for(let c = 1;c<=100;c++){
    if(c % 5 == 0 && c % 3 == 0){
        console.log("FizzBuzz")}
        else if(c % 5 == 0)
        console.log("Buzz")
        else if(c % 3 == 0)
        console.log("Fizz")
    }
*/


//#2 torre de hanoi

/*
let n;
torre = function (pino1, pino3, pino2, n) {
    
   
    if (n <= 0) {
        return
    }

   torre(pino1, pino2, pino3, n - 1)

    console.log(`movendo disco ${n} de ${pino1} para ${pino3}`);

    torre(pino2, pino3, pino1, n - 1);
}

torre('pino1', 'pino3', 'pino2',3)
*/

//#3 Entre letras

/*
const alfabeto = ["A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"];

function numeros(letra1,letra2){
    if(alfabeto.lastIndexOf(letra1) > alfabeto.lastIndexOf(letra2)){
        console.log("Não está na ordem alfabética")
    }
    if(alfabeto.lastIndexOf(letra1) < alfabeto.lastIndexOf(letra2)){
        num1 = alfabeto.slice(alfabeto.lastIndexOf(letra1), alfabeto.lastIndexOf(letra2)-1)       
        console.log("há "+num1.length+ " letras entre "+letra1+ " e "+letra2)
    }
   
    

}
var num1 = []
numeros("C", "H")
*/