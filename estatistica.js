// calculo estatistica simples
// solucao sem usar operadores Math

// valores da lista
arr = []
sortedArr = arr.sort((a,b) => a-b)

let min = sortedArr[0]
let max = sortedArr[sortedArr.length - 1]
let total = sortedArr.length 
let media = arr.reduce((a, b) => a + b, 0) / total

console.log('Valor mínimo: ' + min)
console.log('Valor máximo: ' + max)
console.log('Número de elementos na seqüência: ' + total)
console.log('Valor médio: ' + media)
