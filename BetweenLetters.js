// Entre letras : https://dojopuzzles.com/problems/entre-letras/

function BetweenLetter(letter1, letter2) {
    if (letter1 >= letter2) {
      return "As letras não estão em ordem alfabética.";
    }
  
    var codeLetter1 = letter1.charCodeAt(0);
    var codeLetter2 = letter2.charCodeAt(0);
  

    var result = codeLetter2 - codeLetter1 - 1;

  
    return result;
  }


// Exemplo de uso

//Insira a primeira letra
letter1 = 'a';

//Insira a segunda letra
letter2 = 'g';


numberOfLetters = BetweenLetter(letter1, letter2);
console.log("Quantidade de letras entre", letter1, "e", letter2 + ":", numberOfLetters);