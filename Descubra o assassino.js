function descubraOAssassino(a, b, c) {
    // https://dojopuzzles.com/problems/descubra-o-assassino/
    // **assassino: Donald Duck Knuth usando um trezoitão em Tokio: (2, 3, 4)

    // jogo: chutar 3 números, o 1º de 1 a 7; o 2º de 1 a 6; o 3º de 1 a 10
    
    // regras:
    // todos certos: imprime 0
    // apenas 1 errado: imprime 1, 2 ou 3 (o que estiver errado)
    // 2 errados: imprime aleatoriamente um dos 2 errados
    // 3 (todos) errados: imprime aleatoriamente um dos 3 errados

    const assassinos = ['Charles B. Abbage', 'Donald Duck Knuth', 'Ada L. Ovelace', 'Alan T. Uring', 'Ivar J. Acobson', 'Ras Mus Ler Dorf'];
    
    const armas = ['Peixeira', 'DynaTAC 8000X', 'Trezoitão', 'Trebuchet', 'Maça', 'Gládio'];

    const locais = ['Redmond', 'Palo Alto', 'San Francisco', 'Tokio', 'Restaurante no Fim do Universo', 'São Paulo', 'Cupertino', 'Helsinki', 'Maida Vale', 'Toronto'];
    
    //todos certos
    if (assassinos[a - 1] ===  'Donald Duck Knuth' && armas[b - 1] === 'Trezoitão' && locais[c - 1] === 'Tokio') {
        console.log(0)
    
    //apenas 1 errado
    } else if (assassinos[a - 1] !==  'Donald Duck Knuth' && armas[b - 1] === 'Trezoitão' && locais[c - 1] === 'Tokio') {
        console.log(1)
        
    } else if (assassinos[a - 1] ===  'Donald Duck Knuth' && armas[b - 1] !== 'Trezoitão' && locais[c - 1] === 'Tokio') {
        console.log(2)

    } else if (assassinos[a - 1] ===  'Donald Duck Knuth' && armas[b - 1] === 'Trezoitão' && locais[c - 1] !== 'Tokio') {
        console.log(3)

    // 2 errados
    } else if (assassinos[a - 1] ===  'Donald Duck Knuth' && armas[b - 1] !== 'Trezoitão' && locais[c - 1] !== 'Tokio') {
        geraAleatorio(1, 3)

        function geraAleatorio(min, max) {
            const aleatorio = Math.floor(Math.random() * (max - min + 1)) + min

            if (aleatorio !== 1) {
                console.log(aleatorio)
                return
            }
            geraAleatorio(1, 3)
        }

    } else if (assassinos[a - 1] !==  'Donald Duck Knuth' && armas[b - 1] === 'Trezoitão' && locais[c - 1] !== 'Tokio') {
        geraAleatorio(1, 3)
                
        function geraAleatorio(min, max) {
            const aleatorio = Math.floor(Math.random() * (max - min + 1)) + min

            if (aleatorio !== 2) {
                console.log(aleatorio)
                return
            }
            geraAleatorio(1, 3)
        }        
    } else if (assassinos[a - 1] !==  'Donald Duck Knuth' && armas[b - 1] !== 'Trezoitão' && locais[c - 1] === 'Tokio') {
        geraAleatorio(1, 3)
                
        function geraAleatorio(min, max) {
            const aleatorio = Math.floor(Math.random() * (max - min + 1)) + min

            if (aleatorio !== 3) {
                console.log(aleatorio)
                return
            }
            geraAleatorio(1, 3)
        }   
    // todos errados     
    } else {
        geraAleatorio(1, 3)
        function geraAleatorio(min, max) {
            console.log(Math.floor(Math.random() * (max - min + 1)) + min)
        }
    }
}

descubraOAssassino(1, 1, 1)