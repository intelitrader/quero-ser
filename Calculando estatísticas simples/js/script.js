let inputNumber = window.document.querySelector('input#inputNumber')
let btnAdicionar = window.document.querySelector('input#btnAdicionar')
let selectNumeros = window.document.querySelector('select#selectNumeros')
let btnCalcular = window.document.querySelector('input#btnCalcular')
let btnLimpar = window.document.querySelector('input#btnLimpar')
let resultado = window.document.querySelector('div#resultado')
let numeros = []

function adicionar() {
    if (inputNumber.value.length == 0) {
        window.alert('Campo vazio!')
        inputNumber.focus()
    } else {
        let num = Number(inputNumber.value)
        numeros.push(num)
        let opt = window.document.createElement('option')
        opt.innerHTML = num
        selectNumeros.appendChild(opt)
        inputNumber.value = ''
        inputNumber.focus()
    }
}
btnAdicionar.onclick = adicionar

function calcular() {
    if (numeros.length === 0) {
        window.alert('Adicione alguns números para continuar!')
    } else {
        //Pega a quantidade de itens
        let qtd = numeros.length
        //Variáveis para receber o menor, maior e média
        let maior, menor, media = 0

        /*
            Podemos pegar os valores de menor, maior e média da seguinte forma
            numeros.sort()
            menor = numeros[0]
            maior = numeros[numeros.length - 1]
            for (const n of numeros) {
                media += n;
            }
        */

        maior = numeros[0]
        menor = numeros[0]
        for (const i in numeros) {
            if (numeros[i] > maior) {
                maior = numeros[i]
            } else {
                if (numeros[i] < menor) {
                    menor = numeros[i]
                }
            }
            media += numeros[i]
        }

        //Imprime o resultado na tela
        resultado.innerHTML = `Valor mínimo: ${menor}<br>`
        resultado.innerHTML += `Valor máximo: ${maior}<br>`
        resultado.innerHTML += `Número de elementos na seqüência: ${qtd}<br>`
        resultado.innerHTML += `Valor médio: ${(media / qtd).toFixed(2)}`
    }
}
btnCalcular.onclick = calcular

function limpar() {
    inputNumber.value = ''
    selectNumeros.innerHTML = ''
    while (numeros.length > 0) {
        numeros.pop()
    }
    resultado.innerHTML = ' '
}
btnLimpar.onclick = limpar