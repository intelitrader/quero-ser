// Neste problema você deverá implementar as regras de um jogo de tênis simples (apenas dois jogadores).

// As regras de um jogo de tênis tem diversos detalhes, mas para simplificar o problema, você deve implementar apenas as regras de um game:

// Em uma game cada jogador pode ter a seguinte pontuação: 0, 15, 30, ou 40;
// Os jogadores sempre começam com 0 pontos;
// Se o jogador possui 40 pontos e ganha a disputa, ele vence o game;
// Se ambos jogadores atingem 40 pontos, ocorre um empate (deuce);
// Estando em empate, o jogador que ganhar a bola seguinte está em vantagem (advantage);
// Se um jogador em vantagem ganha novamente a bola, ele vence o game;
// Se um jogador estiver em vantagem e o outro ganhar a bola, volta a ocorrer o empate (deuce).

function JogoTênis(pontoJogador1, pontoJogador2) {

    if (pontoJogador1 === pontoJogador2)
        console.log("Empate")

    else if (pontoJogador1 === 41) {
        console.log("Jogador 1 está em vantagem")

    }
    else if (pontoJogador2 === 41) {
        console.log("Jogador 2 está em vantagem")
    }
    else if (pontoJogador1 > 40 || pontoJogador1 === 42 && pontoJogador2 < 40) {
        console.log("Jogador 1 venceu o game")
    }
    else if (pontoJogador2 > 40 || pontoJogador2 === 42 && pontoJogador1 < 40) {
        console.log("Jogador 2 venceu o game")
    }
    else if (pontoJogador1 > pontoJogador2) {
        console.log("Jogador 1 venceu o game")
    }
    else if (pontoJogador1 < pontoJogador2) {
        console.log("Jogador 2 venceu o game ")
    }
}
//Jogador 2 venceu o game
const resultado = JogoTênis(40,42)
console.log(resultado)