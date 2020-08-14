let inputVetorA = window.document.querySelector('input#inputVetorA')
let inputVetorB = window.document.querySelector('input#inputVetorB')
let btnAddVetorA = window.document.querySelector('input#btnAddVetorA')
let btnAddVetorB = window.document.querySelector('input#btnAddVetorB')
let mostragemVetorA = window.document.querySelector('input#mostragemVetorA')
let mostragemVetorB = window.document.querySelector('input#mostragemVetorB')
let resultado = window.document.querySelector('div#resultado')
let btnCalcular = window.document.querySelector('input#btnCalcular')
let btnLimpar = window.document.querySelector('input#btnLimpar')
let pResultado = window.document.querySelector('p#pResultado')
let vetorA = [], vetorB = []

function addVetorA() {
    pResultado.innerHTML = ''
    if (inputVetorA.value === '') {
        window.alert('Campo vazio!')
        inputVetorA.focus()
    } else{
        let a = Number(inputVetorA.value)
        vetorA.push(a)
        mostragemVetorA.value = vetorA
        inputVetorA.value = ''
        inputVetorA.focus()
    }
}
btnAddVetorA.onclick = addVetorA

function addVetorB() {
    pResultado.innerHTML = ''
    if (inputVetorB.value === '') {
        window.alert('Campo vazio!')
        inputVetorB.focus()
    } else{
        let b = Number(inputVetorB.value)
        vetorB.push(b)
        mostragemVetorB.value = vetorB
        inputVetorB.value = ''
        inputVetorB.focus()
    }
}
btnAddVetorB.onclick = addVetorB

function limparCampos() {
    inputVetorA.value = ''
    inputVetorB.value = ''
    mostragemVetorA.value = ''
    mostragemVetorB.value = ''
    pResultado.innerHTML = ''
    while (vetorA.length > 0) {
        vetorA.pop()
    }
    while (vetorB.length > 0) {
        vetorB.pop()
    }
}
btnLimpar.onclick = limparCampos

function calcular() {
    let a, b, res, j, k
    if (vetorA.length == vetorB.length) {
        j = 0, k = 0, res = 0
        while (j < vetorA.length) {
            a = vetorA[j]
            if(j + 1 > k) {
                while (k <= j) {
                    b = vetorB[k]
                    res += a * b
                    k++
                }
            }
            j++
        }
        pResultado.innerHTML = `Resultado: ${res}`
    } else{
        window.alert('[ERRO]: Vetores não tem o mesmo tamanho!')
    }
}
btnCalcular.onclick = calcular