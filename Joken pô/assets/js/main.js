const resultado = document.querySelector("#resultado")
const jogadorUm = document.querySelector(".jogador-um");
const jogadorDois = document.querySelector(".jogador-dois");

let opcaoJogadorUm;
let opcaoJogadorDois;

jogadorUm.addEventListener("click", InseriropçaõJogadorUm);

function InseriropçaõJogadorUm(evento) {
    opcaoJogadorUm = evento.target.value;
}

jogadorDois.addEventListener("click", InseriropçaõJogadorDois);


function InseriropçaõJogadorDois(evento) {
    opcaoJogadorDois = evento.target.value;
}

function verOpçaoClicada() {
    if (opcaoJogadorUm && opcaoJogadorDois !== undefined) {
        calcularResultado();
    } else {
        alert("Escolha entre pedra, papel ou tesoura");
    }
}

function calcularResultado() {
    if (opcaoJogadorUm === "Papel") {
        if (opcaoJogadorDois === "Pedra") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 1"
        } else if (opcaoJogadorDois === "Tesoura") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 2"
        } else if (opcaoJogadorDois === "Papel") {
            resultado.innerHTML = "VENCEDOR: EMPATE"
        }
    }
    if (opcaoJogadorUm === "Pedra") {
        if (opcaoJogadorDois === "Papel") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 2"
        } else if (opcaoJogadorDois === "Tesoura") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 1"
        } else if (opcaoJogadorDois === "Pedra") {
            resultado.innerHTML = "VENCEDOR: EMPATE"
        }
    }
    if (opcaoJogadorUm === "Tesoura") {
        if (opcaoJogadorDois === "Pedra") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 2"
        } else if (opcaoJogadorDois === "Tesoura") {
            resultado.innerHTML = "VENCEDOR: EMPATE"
        } else if (opcaoJogadorDois === "Papel") {
            resultado.innerHTML = "VENCEDOR: JOGADOR 1"
        }
    }
}


