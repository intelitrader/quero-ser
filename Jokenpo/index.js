
function Jokenpo(jogada1, jogada2) {

  if ((jogada1 === 'pedra' && jogada2 === 'papel') ||
    (jogada2 === 'pedra' && jogada1 === 'papel')
  ) {
    return 'pedra ganhou'
  }

  if (
    (jogada1 === 'tesoura' && jogada2 === 'papel') ||
    (jogada2 === 'tesoura' && jogada1 === 'papel')
  ) {
    return 'tesoura ganhou'
  }

  if (
    (jogada1 === 'tesoura' && jogada2 === 'pedra') ||
    (jogada2 === 'tesoura' && jogada1 === 'pedra')
  ) {
    return 'pedra ganhou'
  }

  if (jogada1 === jogada2) {
    return 'empate'
  }
}

    console.log(Jokenpo('tesoura','pedra'))
