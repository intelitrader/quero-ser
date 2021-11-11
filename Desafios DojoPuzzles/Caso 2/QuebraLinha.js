
//var frase = "Um pequeno jabuti xereta viu dez cegonhas felizes."
var frase = "Vasco melhor do mundo todo!"
var colunas = 6


//Função para validar o tamanho da coluna em relação as palavras da frase
var valida = function(frases, colunas){
    let palavras = frases.split(' ')
    for(var i = 0; i < palavras.length; i++){
        if(palavras[i].length > colunas){
            return false
        }
    }
    return true
}


//Função principal, quebra a frase em linhas e no final imprimi(console.log)
var QuebraLinha = function (frase, colunas){

    var vetorLinha = []

    //Primeira validação, palavras x coluna
    if(!valida(frase, colunas)){
        return console.log("\nTamanho de coluna invalido! O tamanho da coluna deve ser maior que a quantidade de caracteres da maior palavra na frase\n")
    }

    //Retira um pedaço da expressão passada por argumento e insere no vetor
    //O laço de repetição acontece até que essa frase esteja em branco
    while (frase.length > 0){

        //Importante verificação para a ultima palavra da expressão
        if(frase.length <= colunas){
            vetorLinha.push(frase)
            frase = ''
        }
        
        //Procura o espaço em branco mais próximo ao indice indicado nas colunas
        //inicia uma variavel no indice correspondente
        let espaco = frase[colunas]
        let cont = 0
        //caso a letra correspondente a esse respectivo indice nao seja vazio(espaço na frase)
        //diminui um no indice até encontrar o espaço
        while (espaco != ' ' && frase != ''){
            cont++
            espaco = frase[colunas - cont]
        }
        
        //caso a frase nao esteja vazia
        //adiciona a parte da frase correspondente em um vetor que conterá todas as linhas formadas
        if(frase != ''){
            vetorLinha.push(frase.substring(0, colunas - cont))
            frase = frase.slice(colunas - cont + 1)
        }
    }

    //Percorre todo o vetor mostrando no console as linhas já separadas 
    for(var i = 0; i < vetorLinha.length; i++){
        console.log(vetorLinha[i])
    }

}

QuebraLinha(frase, colunas)


