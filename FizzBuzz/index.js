var divisivelPorTres = "Fizz" 
var divisivelPorCinco = "Buzz"
var divisivlPorTresECinco = "FizzBuzz"

for(var i = 1; i < 101; i++){
    if (i % 3 ===0 && i % 5 === 0){
    console.log(divisivlPorTresECinco)
    }else if (i % 5 === 0){
    console.log(divisivelPorCinco)
    }else if (i % 3 === 0){
    console.log(divisivelPorTres)
    }else{
    console.log(i);
    }
}