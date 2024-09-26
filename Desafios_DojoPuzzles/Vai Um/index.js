let firstNum = prompt('Informe o primeiro número:')
let secondNum = prompt('Informe o segundo número')

let vaiUm = 0
let soma = false

// Neste ponto é feita uma validação se os dois números possuem a mesma quantidade de casas decimais
if(firstNum.length != secondNum.length) {

    // Caso os números não tenham a mesma casa decimal é utilizado o padStart para igualar a quantidade de casas para que não retorne nenhum valor NaN durante a soma
    let newFirstNum = firstNum.padStart(Math.max(firstNum.length, secondNum.length), "0")    
    let newSecondNum = secondNum.padStart(Math.max(firstNum.length, secondNum.length), "0")
    console.log(newFirstNum, newSecondNum)
    
    // Utilizado o laço for para realizar a soma de cada elemento
    for(i = Math.max(firstNum.length, secondNum.length)-1; i >= 0; i--){        

        // Neste ponto é realizada uma validação se a soma dos dois elementos é maior que nove e computa como um "Vai Um"
        if(Number(newFirstNum[i]) + Number(newSecondNum[i]) > 9){
            vaiUm += 1
            // Neste ponto é utilizada uma validação booleana para "armazenar" o valor excedente para o calculo do próximo elemento
            soma = true
        } else if(soma == true) {
            //Neste ponto caso o validador soma seja True é feita uma validação somando os dois elementos e adicionando o valor 1 que veio da soma anterior e caso o total seja maior que 9 ele computa como um "Vai Um"
            if(Number(newFirstNum[i]) + Number(newSecondNum[i]) + 1 > 9){
                vaiUm +=1
            }else{
                soma = false
            }
        }
    }
    alert(`A soma dos números ${firstNum} e ${secondNum} possui ${vaiUm} "Vai Um".`)
}