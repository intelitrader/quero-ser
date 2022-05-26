import React, { useState } from "react";

//https://dojopuzzles.com/problems/numeros-felizes/


function NumerosFelizes(){
    const [num, setNum] = useState(0);
    const [feliz, setFeliz] = useState('');

    function eFeliz(numero){

        numero = numero.toString().split('');
        var soma = 0;

        for(var i=0; i<numero.length; i++){
            soma+= numero[i] * numero[i];
        }

        if (soma > 9){
            return eFeliz(soma);
        } else {
            if (soma===1 || soma === 7) {
                setFeliz("O número é feliz");
                return true;
            } else {
                setFeliz("O número não é feliz");
                return false;
            }
        }

    }
    

    function handleSubmit(e){
        e.preventDefault();
        
        console.log(eFeliz(num));
        

    }
    
    return (
        <>

            <div>

                <h2>Número Feliz</h2>

            </div>
            <div>
                <form  onClick={handleSubmit}>
                    <input
                        type="number"
                        placeholder="Digite um número"
                        value={num}
                        onChange = {(e) => setNum(e.target.value)}
                    />

                    <button type="submit"> Esse número é feliz? </button>

                </form>
                <p>{feliz}</p>

            </div>
        </>
    )
}

export default NumerosFelizes;