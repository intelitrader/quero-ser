//https://dojopuzzles.com/problems/jokenpo/


function jokenpo(jogador1, jogador2){
    let result;
    if(jogador1 === jogador2){
        return "Empate!"
    }
    if(jogador1 == "pedra" && jogador2 == "tesoura" || 
       jogador1 == "tesoura" && jogador2 == "papel" ||
       jogador1 == "papel" && jogador2 == "pedra"){
        result = "Jogador1 Venceu"  
    } else if (jogador2 == "pedra" && jogador2 == "tesoura" ||
               jogador2 == "tesoura" && jogador2 == "papel" ||
               jogador2 == "papel" && jogador2 == "pedra"){
        result = "Jogador2 Venceu"
    }

    return result;
};
console.log(jokenpo("tesoura", "tesoura"));