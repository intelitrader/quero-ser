//https://dojopuzzles.com/problems/jokenpo/
//Jokenpo

var jogador1 = prompt("Jogador 1, você escolhe: Pedra, Papel ou Tesoura?");
var jogador2 = prompt("Jogador 2, você escolhe: Pedra, Papel ou Tesoura?");

function jokenpo (jogador1, jogador2) {

    if (jogador1 == jogador2) {
        document.write("Empate");

    }else if (jogador1 == "Pedra" && jogador2 == "Tesoura") {
        document.write("Vitória do jogador número um!");

    }else if (jogador1 == "Tesoura" && jogador2 == "Papel") {
        document.write("Vitória do jogador número um!");       

    }else if (jogador1 == "Papel" && jogador2 == "Pedra") {
        document.write("Vitória do jogador número um!");
        

    }else if (jogador2 == "Pedra" && jogador1 == "Tesoura") {
        document.write("Vitória do jogador número dois!");

    }else if (jogador2 == "Tesoura" && jogador1 == "Papel") {
        document.write("Vitória do jogador número dois!");       

    }else if (jogador2 == "Papel" && jogador1 == "Pedra") {
        document.write("Vitória do jogador número dois!");
    }

}

jokenpo(jogador1, jogador2);