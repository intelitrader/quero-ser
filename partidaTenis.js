var jogador1 = prompt("Digite o nome do Primeiro Jogador")
var jogador2 = prompt("Digite o nome do Segundo Jogador")
var pontos1 = 0
var pontos2 = 0
pontos1 = prompt("Quantos Pontos está o " + jogador1 + "?")
pontos2 = prompt("Quantos Pontos está o " + jogador2 + "?")
if(pontos1 >= 40 && pontos2 < 40){
    console.log(jogador1 + " Venceu a Partida")
} else if (pontos1 < 40 && pontos2 >= 40) {
    console.log(jogador2 + " Venceu a Partida")
} else if (pontos1 == 40 && pontos2 == 40){
    console.log("Ocorreu um Empate")  
    empate1 = prompt("Quantos Pontos está o " + jogador1 + "?")
    empate2 = prompt("Quantos Pontos está o " + jogador2 + "?")
    if (empate1 == 2 && empate2 == 0){
        console.log("Acabou o Jogo o vencedor foi o " + jogador1)
    } else if (empate1 == 0 && empate2 == 2){
        console.log("Acabou o Jogo o vencedor foi o " + jogador2)
    } else {
        console.log("Empatou Novamente")
    }
}else {
    console.log("Jogo ainda não acabou, o jogo está " + pontos1 + "X" + pontos2 )
}