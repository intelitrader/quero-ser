export default function jokenpo() {
  const player1 = document.getElementById("player1");
  const player2 = document.getElementById("player2");
  const buttonJokenpo = document.querySelector(".jokenpo__button");

  function mostraResultado(resultado) {
    const spanJokenpo = document.querySelector(".resultado-jokenpo");
    spanJokenpo.innerHTML = resultado;
  }

  function comparaEscolhas(player1Escolha, player2Escolha) {
    let resultado;
    switch (true) {
      case player1Escolha === player2Escolha:
        resultado = "Empate";
        break;
      case player1Escolha === "pedra" && player2Escolha === "papel":
        resultado = "Jogador 2 ganhou";
        break;
      case player1Escolha === "pedra" && player2Escolha === "tesoura":
        resultado = "Jogador 1 ganhou";
        break;
      case player1Escolha === "papel" && player2Escolha === "pedra":
        resultado = "Jogador 1 ganhou";
        break;
      case player1Escolha === "papel" && player2Escolha === "tesoura":
        resultado = "Jogador 2 ganhou";
        break;
      case player1Escolha === "tesoura" && player2Escolha === "pedra":
        resultado = "Jogador 2 ganhou";
        break;
      case player1Escolha === "tesoura" && player2Escolha === "papel":
        resultado = "Jogador 1 ganhou";
        break;
    }
    return resultado;
  }

  function comparaPlayers() {
    const player1Escolha = player1.options[player1.selectedIndex].value;
    const player2Escolha = player2.options[player2.selectedIndex].value;

    const resultado = comparaEscolhas(player1Escolha, player2Escolha);
    mostraResultado(resultado);
  }

  buttonJokenpo.addEventListener("click", comparaPlayers);
}
