const diamante = function(inicio = 'a', fim) {
    const alfabeto = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];

    const espaço = (alfabeto.indexOf(fim.toLowerCase())) - (alfabeto.indexOf(inicio.toLowerCase()) + 1)

    console.log(inicio.toUpperCase().padStart(espaço + 2))

    for (let i = 0; i < espaço + 1; i++) {
        console.log(alfabeto[i + 1].toUpperCase()
        .padStart(espaço - i + 1)
        .padEnd(i + espaço + 1),
        
        alfabeto[i + 1].toUpperCase())            
    }

    const arr = [];
    for (let i = 0; i < espaço + 1; i++) {
        arr.push(alfabeto[i].toUpperCase())
    }
    arr.reverse().pop()
    
    for (let i = 0; i < espaço; i++) {
        console.log(arr[i].padStart(i + 2).padEnd(espaço * 2 - i),
        arr[i]
        )
    }
    console.log(inicio.toUpperCase().padStart(espaço + 2))
}

diamante('a', 'f')