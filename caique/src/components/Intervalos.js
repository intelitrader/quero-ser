import React from "react";
import { useState } from "react/cjs/react.development";

//https://dojopuzzles.com/problems/intervalos/


function Intervalos(){
    const numeros  = [1, 2, 13, 23, 24, 50, 51,52 ,53, 25, 27, 100, 101, 102, 103, 104, 105, 110, 111, 113, 114, 115, 150, 8 ];
    const [resultado, setResultado] = useState([[],[]]);

    const numerosOrdenados = numeros.sort(function(a,b){
        if(a>b) return 1;
        if(b>a) return -1;
        return 0;
    });
    
    function verificaSequencia(){
        var arr = [];
        
        
        for(var i=0; i<numeros.length; i++){
            if (numeros[i]+1 === numeros[i+1]){
                arr.push(numeros[i]+" ")
                console.log(numeros[i]);
            } else if (numeros[i]-1 !== numeros[i-1] && numeros[i]+1 !== numeros[i+1]) {
                arr.push(" "+ numeros[i]+", ");
            } else {

            }
        }

        return arr;
    }
    
    const sequencia = verificaSequencia();


    return(
        <>
            <div>
                <h2> Intervalos </h2>

                <br/>
                <ul> 
                    {numerosOrdenados.map((numero) =><li>{numero}</li>)}
                    <br/>
                    {sequencia}
                </ul>
                
            </div>
        </>
    );
}

export default Intervalos;