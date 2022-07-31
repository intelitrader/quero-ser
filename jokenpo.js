// https://dojopuzzles.com/problems/jokenpo/

const jokenpo = (player1, player2) => {
  if (player1 === player2) {
    return 'Empate';
  } else if (player1 === 'pedra') {
    if (player2 === 'papel') {
      return 'Player 2 venceu';
    } else {
      return 'Player 1 venceu';
    }
  } else if (player1 === 'papel') {
    if (player2 === 'tesoura') {
      return 'Player 2 venceu';
    } else {
      return 'Player 1 venceu';
    }
  } else if (player1 === 'tesoura') {
    if (player2 === 'pedra') {
      return 'Player 2 venceu';
    } else {
      return 'Player 1 venceu';
    }
  }
}

// Exemplo de uso
console.log(jokenpo('pedra', 'tesoura'));