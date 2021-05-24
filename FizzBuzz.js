let lista = [100];
var numero1 = 0;
var numero = 0;

for (numero1=1;numero1<=100;numero1++){
    lista[numero1]=numero1
}
for (numero2=1;numero2<=100;numero2++){
    if ((numero2%3 == 0 && numero2%5 ==0)){
        console.log("FizzBuzz")
    } else if ((numero2%3==0)){
        console.log("Fizz")
    }else if ((numero2%5 == 0)){
        console.log("Buzz")
    }else if ((numero2%3 != 0) && (numero2%5 != 0)){
        console.log(lista[numero2]);
    } 
}