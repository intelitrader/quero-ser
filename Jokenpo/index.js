// como pegar valores aleatorios de um array
function shuffle(array) {
    var currentIndex = array.length, randomIndex;

    // Enquanto ainda houver elementos para embaralhar
    while (0 !== currentIndex) {

        // Escolha um elemento restante
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex--;

        // E troque-o com o elemento atual.
        [array[currentIndex], array[randomIndex]] = [
            array[randomIndex], array[currentIndex]];
    }

    return array;
}

function Jakenpo() {

    // Array com as possibilidades de cada player
    var Pedra = "Pedra"
    var Papel = "Papel"
    var Tesoura = "Tesoura"
    // Itens repetidos para a possibilidade de empate
    let jogo = [Papel, Pedra, Tesoura, Tesoura, Papel, Pedra];

    // Usa função shuffle para embaralhar o array
    shuffle(jogo);

    // Define uma posição do array para cada player
    var Player1 = jogo[0];
    var Player2 = jogo[2];

    // Descreve o valor que os players receberam
    console.log("O Player 1 escolheu: ", Player1);
    console.log("O Player 2 escolheu: ", Player2);

    // Caso ambos recebam o mesmo valor
    if (Player1 == Player2) {
        console.log("Empate");
    }

    // Caso Player1 coloque pedra
    else if (Player1 == Pedra) {
        if (Player2 == Tesoura) {
            console.log("Player 1 Venceu");
        }
        if (Player2 == Papel) {
            console.log("Player 2 Venceu");
        }
    }

    // Caso Player1 coloque papel
    else if (Player1 == Papel) {
        if (Player2 == Tesoura) {
            console.log("Player 2 Venceu")
        }
        if (Player2 == Pedra) {
            console.log("Player 1 Venceu")
        }
    }

    // Caso Player1 coloque Tesoura
    else if (Player1 == Tesoura) {
        if (Player2 == Papel) {
            console.log("Player 1 Venceu")
        }
        if (Player2 == Pedra) {
            console.log("Player 2 Venceu")
        }
    }


}

    Jakenpo();