var jogador1 = prompt("Jogador1 - Escolha entre, 1-Pedra, 2-Papel, 3-Tesoura")
var jogador2 = prompt("Jogador2 - Escolha entre, 1-Pedra, 2-Papel, 3-Tesoura")

if (jogador1 == 1 && jogador2 == 3){
console.log("Jogador 1 Ganhou escolhendo Pedra")
} else if (jogador2 == 1 && jogador1 == 3){
    console.log("Jogador 2 Ganhou escolhendo Pedra")
}else if (jogador1 == 3 && jogador2 == 2){
    console.log("Jogador 1 Ganhou escolhendo Tesoura")
} else if (jogador2 == 3 && jogador1 == 2){
    console.log("Jogador 2 Ganhou escolhendo Tesoura")
} else if (jogador1 == 2 && jogador2 == 1){
    console.log("Jogador 1 Ganhou escolhendo Papel")
} else if (jogador2 == 2 && jogador1 == 1){
    console.log("Jogador 2 Ganhou escolhendo Papel");
} else {
    console.log("Empatou");
}