/*
Link do desafio:
https://dojopuzzles.com/problems/jokenpo/
*/


let escolha = ['Pedra', 'Papel', 'Tesoura'];

var jogador1 = 0;
var jogador2 = 0;

let totalArray = escolha.length;

let escolhaSorteada = Math.floor(Math.random() * totalArray);
let escolhaSorteada2 = Math.floor(Math.random() * totalArray);
jogador1 = escolha[escolhaSorteada]
jogador2 = escolha[escolhaSorteada2]

if(jogador1 == jogador2) {
    console.log("Empate");
} 
else if(jogador1 == 'Pedra' && jogador2 == 'Tesoura') {
    console.log("Jogador1 venceu pois pedra quebra tesoura");
}
else if(jogador1 == 'Papel' && jogador2 == 'Pedra') {
    console.log("Jogador1 venceu papel cobre pedra");
}
else if(jogador1 == 'Tesoura' && jogador2 == 'Papel') {
    console.log("Jogador1 venceu tesoura corta papel");
}
else if(jogador1 == 'Papel' && jogador2 == 'Tesoura') {
    console.log("Jogador2 venceu tesoura corta papel");
}
else if(jogador1 == 'Pedra' && jogador2 == 'Papel') {
    console.log("Jogador2 venceu papel cobre pedra");
}
else if(jogador1 == 'Tesoura' && jogador2 == 'Pedra') {
    console.log("Jogador2 venceu pedra quebra tesoura");
} else {
    console.log("Faça uma escolha valida e reinicie o jogo");
}