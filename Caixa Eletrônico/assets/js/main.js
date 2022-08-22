const valor = document.querySelector("#valor-input")

function mandaValor() {
    recebeValor(valor.value)
}

function recebeValor(valor) {
    if (valor % 10 == 0) {
        calculaNotas(valor)
    } else {
        alert("Só há notas divisiveis por 10 disponíveis")
    }
}

function calculaNotas(valor) {
    const notas = []
    let valorTotal = valor
    while (valorTotal > 0) {
        if (valorTotal >= 100) {
            const nota100 = Math.floor(valorTotal / 100)
            if (nota100 > 1) {
                notas.push(` ${nota100} notas de 100`)
            } else {
                notas.push(` ${nota100} nota de 100`)
            }
            valorTotal = valorTotal % 100
        }
        if (valorTotal >= 50 && valorTotal < 100) {
            const nota50 = Math.floor(valorTotal / 50)
            if (nota50 > 1) {
                notas.push(` ${nota50} notas de 50`)
            } else {
                notas.push(` ${nota50} nota de 50`)
            }
            valorTotal = valorTotal % 50
        }
        if (valorTotal >= 20 && valorTotal < 50) {
            const nota20 = Math.floor(valorTotal / 20)
            if (nota20 > 1) {
                notas.push(` ${nota20} notas de 20`)
            } else {
                notas.push(` ${nota20} nota de 20`)
            }
            valorTotal = valorTotal % 20
        }
        if (valorTotal >= 10 && valorTotal < 20) {
            const nota10 = Math.floor(valorTotal / 10)
            if (nota10 > 1) {
                notas.push(` ${nota10} notas de 10`)
            } else {
                notas.push(` ${nota10} nota de 10`)
            }
            valorTotal = valorTotal % 10
        }
    } mostraResultado(notas)
}

function mostraResultado(notas) {
    const resultado = document.querySelector(".resultado")
    resultado.innerHTML = notas
}