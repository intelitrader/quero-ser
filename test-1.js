/*

Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.

O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.

As regras são as seguintes:

Pedra empata com Pedra e ganha de Tesoura
Tesoura empata com Tesoura e ganha de Papel
Papel empata com Papel e ganha de Pedra

*/




const pedra = "pedra";
const papel = "papel";
const tesoura = "tesoura";

const jokenpo = (jogador1, jogador2) => {
  if (jogador1 === jogador2) {
    return "Empate";
  } else if (
    (jogador1 === pedra && jogador2 === tesoura) ||
    (jogador1 === tesoura && jogador2 === papel) ||
    (jogador1 === papel && jogador2 === pedra)
  ) {
    return "Jogador 1 venceu";
  } else {
    return "Jogador 2 venceu";
  }
}

console.log(jokenpo(pedra, tesoura))
