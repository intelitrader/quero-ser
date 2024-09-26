let jogador1 = prompt("Jogador 1, joque pedra, papel ou tesoura!")


let jogador2 = prompt("Jogador 2, joque pedra, papel ou tesoura!")

//pedra empata com pedra
if(jogador1 === "pedra" && jogador2 === "pedra" || jogador1 === "PEDRA" && jogador2 === "PEDRA" || jogador1 === "Pedra" && jogador2 === "Pedra"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("EMPATE!")

//tesoura empata com tesoura
}else if(jogador1 === "tesoura" && jogador2 === "tesoura" || jogador1 === "TESOURA" && jogador2 === "TESOURA" || jogador1 === "Tesoura" && jogador2 === "Tesoura"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("EMPATE!")

//papel empata com papel
}else if(jogador1 === "papel" && jogador2 === "papel" || jogador1 === "PAPEL" && jogador2 === "PAPEL" || jogador1 === "Papel" && jogador2 === "Papel"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("EMPATE!")

//pedra ganha de tesoura
}else if(jogador1 === "pedra" && jogador2 === "tesoura" || jogador1 === "PEDRA" && jogador2 === "TESOURA" || jogador1 === "Pedra" && jogador2 === "Tesoura"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 1 VENCEU!")
}else if(jogador2 === "pedra" && jogador1 === "tesoura" || jogador2 === "PEDRA" && jogador1 === "TESOURA" || jogador2 === "Pedra" && jogador1 === "Tesoura"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 2 VENCEU!")

//tesoura ganha de papel
}else if(jogador1 === "tesoura" && jogador2 === "papel" || jogador1 === "TESOURA" && jogador2 === "PAPEL" || jogador1 === "Tesoura" && jogador2 === "Papel"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 1 VENCEU!")
}else if(jogador1 === "papel" && jogador2 === "tesoura" || jogador1 === "PAPEL" && jogador2 === "TESOURA" || jogador1 === "Papel" && jogador2 === "Tesoura"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 2 VENCEU!")

//papel ganha de pedra
}else if(jogador1 === "papel" && jogador2 === "pedra" || jogador1 === "PAPEL" && jogador2 === "PEDRA" || jogador1 === "Papel" && jogador2 === "Pedra"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 1 VENCEU!")
}else if(jogador1 === "pedra" && jogador2 === "papel" || jogador1 === "PEDRA" && jogador2 === "PAPEL" || jogador1 === "Pedra" && jogador2 === "Papel"){
    console.log("Jogador 1 jogou "+ jogador1 + " e o jogador 2 jogou " + jogador2)
    console.log("JOGADOR 2 VENCEU!")
}


