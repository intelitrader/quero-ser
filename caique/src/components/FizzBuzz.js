import React from "react";

function FizzBuzz(){ 

    
    function fizzBuzzTeste(){
        var resultado = [];

        for(var i=1; i<=100; i++){
            if(i%3===0 && i%5===0){
                console.log("FizzBuzz ");
                resultado.push("FizzBuzz ");
            } else if (i%3===0){
                console.log("Fizz ");
                resultado.push("Fizz ");
            } else if(i%5===0){
                console.log("Buzz ");
                resultado.push("Buzz ");
            } else{
                console.log(i);
                resultado.push(i +" ");
            }
        }

        return resultado;
    }
    
    const teste = fizzBuzzTeste();

    return(
        <>
            <div>
                <h2> FizzBuzz </h2>
                <br/>
                {teste}
                
            </div>
        </>
    );
}

export default FizzBuzz;