function jokenpo(jogada1, jogada2) {
    // verificação de empate
    if (jogada1 === jogada2) {
        return 'Empate';
    }

    // verificação das jogadas
    if (jogada1 === 'Pedra') {
        if (jogada2 === 'Tesoura') {
            return 'Jogador 1 venceu';
        } else {
            return 'Jogador 2 venceu';
        }
    } else if (jogada1 === 'Tesoura') {
        if (jogada2 === 'Papel') {
            return 'Jogador 1 venceu';
        } else {
            return 'Jogador 2 venceu';
        }
    } else if (jogada1 === 'Papel') {
        if (jogada2 === 'Pedra') {
            return 'Jogador 1 venceu';
        } else {
            return 'Jogador 2 venceu';
        }
    }
}

// Exemplo de uso:
console.log(jokenpo('Pedra', 'Tesoura')); // Jogador 1 venceu
console.log(jokenpo('Tesoura', 'Papel')); // Jogador 1 venceu
console.log(jokenpo('Papel', 'Pedra')); // Jogador 1 venceu
console.log(jokenpo('Tesoura', 'Tesoura')); // Empate
console.log(jokenpo('Papel', 'Pedra')); // Jogador 2 venceu



