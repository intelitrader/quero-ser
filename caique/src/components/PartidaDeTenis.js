import React from "react";
import { useState } from "react/cjs/react.development";

//https://dojopuzzles.com/problems/partida-de-tenis/

function PartidaDeTenis(){
    const [pontosJog1, setPontosJog1] = useState(0);
    const [pontosJog2, setPontosJog2] = useState(0);
    const [gamesJog1, setGamesJog1] = useState(0);
    const [gamesJog2, setGamesJog2] = useState(0);
    const [fimDeGame, setFimDeGame] = useState(false);
    const [ganhou, setGanhou] = useState("");

    function adicionaPontosJog1(){


        if (!fimDeGame){
            var pontosSomados = somaPontos(pontosJog1, pontosJog2);
            setPontosJog1(pontosSomados[0]);
            setPontosJog2(pontosSomados[1]);


        } else{
            setGamesJog1(gamesJog1+1);
            setFimDeGame(false);


        }

        if(gamesJog1===3){
            setGanhou("Jogador 1 ganhou");
            reiniciarJogo();

        } 


    }

    function adicionaPontosJog2(){
  


        var pontosSomados = (somaPontos(pontosJog2, pontosJog1));
        setPontosJog2(pontosSomados[0]);
        setPontosJog1(pontosSomados[1]);

        if (fimDeGame){
            setGamesJog2(gamesJog2+1);
            setFimDeGame(false);


        }

        
        if(gamesJog2===3){
            setGanhou("Jogador 2 ganhou");
            reiniciarJogo();
        }

    }

    function reiniciarJogo(){
        setPontosJog1(0);
        setPontosJog2(0);
        setGamesJog1(0);
        setGamesJog2(0);
        console.log("jogo reiniciado");
        setFimDeGame(false);
    }


    
    function somaPontos(pontos, pontos2){


        if (pontos < 30){
            pontos+=15;
        } else
        if (pontos === 30) {
            if (pontos2 === 40){
                pontos = "deuce";
                pontos2 = "deuce";
            } else {
                pontos+=10;
            }
            
        } else if(pontos === 40 ){
            if(pontos2 === "advantage"){
                pontos = "deuce";
                pontos2 = "deuce";
            } else if(pontos2 < 40){
                setFimDeGame(true);

                pontos = 0;
                pontos2 = 0;
            }
        }else if(pontos === "deuce"){
            pontos = "advantage";
            pontos2 = 40;
        } else if(pontos === "advantage"){
            setFimDeGame(true);

            pontos2 = 0;
            pontos = 0;
        }
        console.log(fimDeGame);
        return [pontos, pontos2];

    }


    return (
        <>
            <div>
                <h2> Partida De Tênis</h2>
                <button onClick={adicionaPontosJog1} >Jogador 1</button> 
                {gamesJog1} |  
                 {pontosJog1} x {pontosJog2}  
                | {gamesJog2}
                <button onClick={adicionaPontosJog2} >Jogador 2</button>
                <br/>
                <button onClick={reiniciarJogo}>Reiniciar</button>
                <br/>
                {ganhou}
            </div>
        </>
    )
}

export default PartidaDeTenis;