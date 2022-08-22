const jogada1 = "pedra"
const jogada2 = "tesoura"




if (jogada1 === "pedra" && jogada2 === "tesoura") {
    console.log("jogada ganhadora", jogada1)
} else if (jogada1 === "tesoura" && jogada2 === "pedra") {
    console.log("jogada ganhadora", jogada2)
} else if (jogada1 === "pedra" && jogada2 === "papel") {
    console.log("jogada ganhadora", jogada1)
} else if (jogada1 === "papel" && jogada2 === "pedra") {
    console.log("jogada ganhadora", jogada1)
} else if (jogada1 === "tesoura" && jogada2 === "papel") {
    console.log("jogada ganhadora", jogada1)
} else if (jogada1 === "papel" && jogada2 === "tesoura") {
    console.log("jogada ganhadora", jogada2)
} else {
    console.log("empate")
}