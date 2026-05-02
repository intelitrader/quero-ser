fun main() {
    calculaTudo(listOf(63, 26, 12, 43, 67, 1289))
}

fun calculaTudo (lista: List<Int>) {
    valorMinimo(lista)
    valorMaximo(lista)
    qtdEmSequencia(lista)
    media(lista)
}

fun valorMinimo (lista: List<Int>) {
    var aux = lista[0]

    lista.forEach { valor ->
        if (valor < aux) {
            aux = valor
        }
    }

    println("Valor minimo: $aux")
}

fun valorMaximo (lista: List<Int>) {
    var aux = lista[0]

    lista.forEach { valor ->
        if (valor > aux) {
            aux = valor
        }
    }

    println("Valor maximo: $aux")
}

fun media (lista: List<Int>) {
    var total = 0.0

    lista.forEach { valor ->
        total += valor
    }

    println("Valor medio: ${total / lista.size}")
}

fun qtdEmSequencia (lista: List<Int>) {
    println("Número de elementos na sequência: ${lista.size}")
}