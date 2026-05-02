fun main() {
    println(devolveTroco(380))
}

fun devolveTroco (valor: Int): Map<Int, Int> {
    val notasParaTroco = intArrayOf(100, 50, 20, 10)
    val mapaTroco = mutableMapOf<Int, Int>()
    var valorAux = valor

    while (valorAux != 0) {
        notasParaTroco.forEach { nota ->
            if (valorAux >= nota) {
                mapaTroco[nota] = valorAux/nota
                valorAux %= nota
            }
        }
    }

    return mapaTroco
}