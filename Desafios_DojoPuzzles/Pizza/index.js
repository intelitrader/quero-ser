let RENATO = { "Marguerita" : 4, "Quatro queijos" : 5, "Escarola" : 4, "Portuguesa" : 5, "Frango+Catupiry" : 4, "Napolitana" : 3 }

let	MARCELO = { "Marguerita" : 2, "Quatro queijos" : 2, "Escarola" : 1, "Portuguesa" : 3, "Frango+Catupiry" : 5, "Napolitana" : 2 }

let	LENON = { "Marguerita" : 4, "Quatro queijos" : 5, "Escarola" : 2, "Portuguesa" : 1, "Frango+Catupiry" : 1, "Napolitana" : 3 }

let	RENATA = { "Marguerita" : 4, "Quatro queijos" : 5, "Escarola" : 1, "Portuguesa" : 1, "Frango+Catupiry" : 3, "Napolitana" : 4 }

let	WASHINGTON = { "Marguerita" : 1, "Quatro queijos" : 1, "Escarola" : 2, "Portuguesa" : 3, "Frango+Catupiry" : 4, "Napolitana" : 3 }

let	TINO = { "Marguerita" : 1, "Quatro queijos" : 5, "Escarola" : 1, "Portuguesa" : 4, "Frango+Catupiry" : 3, "Napolitana" : 2 }

let	LUCA = { "Marguerita" : 5, "Quatro queijos" : 4, "Escarola" : 3, "Portuguesa" : 4, "Frango+Catupiry" : 3, "Napolitana" : 2 }



function compararPedidos(pessoa1, pessoa2){

    console.log("Sabores de Pizza compatíveis entre os avaliados" + "\n--------------------------------\n")

    // A função percorre a chave dos dois objetos informados como parâmetro e caso o elemento da primeira pessoa seja igual o da seguinda pessoa ele retorna o nome do saber e a pontuação que cada pessoa deu. Dessa forma será possível verificar quais são os sabores compatíveis em avaliação de cada pessoa.
    Object.keys(pessoa1, pessoa2).forEach(elemento =>{    
        
        if(pessoa1[elemento] === pessoa2[elemento]){
            console.log(elemento + " - " + pessoa1[elemento] + "\n" + elemento + " - " + pessoa2[elemento] + "\n----------------")
        }

    })
    

    
}


console.log(compararPedidos(RENATA, LENON))

