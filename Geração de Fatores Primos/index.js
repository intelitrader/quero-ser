let primo = [2,3,5,7,11,13,17,19,23,29,31]
let dividendo = []
let fator = []
let i = 0
let num = parseInt(prompt("Digite um numero para ser fatorado: "))

while(num != 1){
    if(num in primo){
        dividendo.push(num)
        fator.push(num)
        num = 1
    }else if(num%primo[i]==0){
        dividendo.push(num)
        fator.push(primo[i])
        num = num/primo[i]
    }
}

console.log("Dividendos: "+ dividendo)
console.log("Fatores: "+ fator)