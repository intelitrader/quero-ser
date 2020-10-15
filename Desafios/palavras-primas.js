    // LINK DO PROBLEMA: http://dojopuzzles.com/problemas/exibe/palavras-primas/

function verificarPrimo (soma){
    if (soma > 1){
        for (var l = 2; l < soma; l ++){
            if (soma% l == 0) { 
                return false;
            }
        }
        return true;
    }
}

var letras = ['a','b','c','d','e','f','g','h','i','j',
            'k','l','m','n','o','p','q','r','s','t','u',
            'v','w','x','y','z','A','B','C','D','E','F',
            'G','H','I','J','K','L','M','N','O','P','Q',
            'R','S','T','U','V','W','X','Y','Z'];

var palavras = ['Migalha', 'Telefone', 'Pacote', 'Geometria', 'Constante'];

for (var i = 0; i < palavras.length; i++){
    
    var palavra = palavras[i];
    var soma = 0;    
    
    for  (var j = 1; j <= palavra.length; j++){
        var fraseNumerica = [];

        var letra = palavra.substring(j-1, j);
        var index = letras.indexOf(letra)+1;
        fraseNumerica.push(index);

        for (var k = 0; k < fraseNumerica.length; k++){
            soma += fraseNumerica[k];
        }
    }

    if (verificarPrimo(soma) == true){
        console.log("A palavra " + palavra + " equivale a " + soma + " é prima");
    } else if (verificarPrimo(soma) == false){
        console.log("A palavra " + palavra + " equivale a " + soma + " não é prima");
    }
}