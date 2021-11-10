
//https://dojopuzzles.com/problems/encontre-o-telefone/

class Frase{

    constructor(){
        this.frase = '';
    }

    fraseCompleta(letra){
        this.frase += letra;
    }

}


var transformaValores = function(letra){

    if(letra == 'A' || letra == 'B' || letra == 'C'){
        return 2;
    }
    if(letra == 'D' || letra == 'E' || letra == 'F'){
        return 3;
    }
    if(letra == 'G' || letra == 'H' || letra == 'I'){
        return 4;
    }
    if(letra == 'J' || letra == 'K' || letra == 'L'){
        return 5;
    }
    if(letra == 'M' || letra == 'N' || letra == 'O'){
       return 6;
    }
    if(letra == 'P' || letra == 'Q' || letra == 'R' || letra == 'S'){
        return 7;
    }
    if(letra == 'T' || letra == 'U' || letra == 'V'){
        return 8;
    }
    if(letra == 'W' || letra == 'X' || letra == 'Y' || letra == 'Z'){
        return 8;
    }
    if(letra == '1' || letra == '0' || letra == '-' || letra == ' '){
        return letra;
    }
    else{
        return 'erro'
    }

}


var expressao = function(x){

    let frase = new Frase();

    for(let i = 0; i < x.length; i++){

        let n = transformaValores(x[i])

        if(n === 'erro'){
            return 'Expressão incorreta, Uma expressão deve ser composta por letras maiúsculas (A-Z), hifens (-) e os números 1 e 0.'
        }
        else{
            frase.fraseCompleta(n)
        }

    };

    return frase.frase
}

//Testando impressão por frases especificas
//console.log(expressao('MY-MISERABLE-JOB'))


//Carregando arquivo já com algumas frases
const readline = require('readline')
const fs = require('fs')
const readable = fs.createReadStream('Expressoes.txt')

const rl = readline.createInterface({
    input: readable
})

rl.on('line', (line) =>{
    if(line != ''){
        console.log(line)
        if(line.length > 30){
            console.log('Expressão incorreta, cada expressão deve ter até 30 caracteres \n')
        }else{
            console.log(expressao(line) + '\n')
        }
    }
})




