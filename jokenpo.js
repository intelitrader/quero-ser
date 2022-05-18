function jokenpo(player1, player2) {
  if (player1 == 'pedra') {
    if (player2 == 'pedra') {
      console.log('empate');
    } else if (player2 == 'papel') {
      console.log('player2 vence');
    } else if (player2 == 'tesoura') {
      console.log('player1 vence');
    }
  }

  if (player1 == 'papel') {
    if (player2 == 'pedra') {
      console.log('player1 vence');
    } else if (player2 == 'papel') {
      console.log('empate');
    } else if (player2 == 'tesoura') {
      console.log('player2 vence');
    }
  }

  if (player1 == 'tesoura') {
    if (player2 == 'pedra') {
      console.log('player2 vence');
    } else if (player2 == 'papel') {
      console.log('player1 vence');
    } else if (player2 == 'tesoura') {
      console.log('empate');
    }
  }
}

// https://dojopuzzles.com/problems/jokenpo/

jokenpo('papel', 'pedra');