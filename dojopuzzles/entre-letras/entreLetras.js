/*
  Problema retirado de: https://dojopuzzles.com/problems/entre-letras/

* _Entre Letras_ 
* 
* DESCRIÇÃO
*
*Faça um programa que receba duas letras, e diga quantas letras há entre elas. As letras passadas devem estar em ordem alfabética. Se não estiverem o programa deve avisar o usuário. Exemplo: 'a', 'b' = 0 'a', 'c' = 1 'a', 'z' = 24 'w', 'e' = Não está na ordem alfabética.
*/

const numberLettersBetweenTwoLetters = (firstLetter, secondLetter) => {
  if (secondLetter.charCodeAt() - firstLetter.charCodeAt() < 0) {
    return `Não está na ordem alfabética.`;
  } else {
    return secondLetter.charCodeAt() - firstLetter.charCodeAt() - 1;
  }
};

// Caso de teste 1
console.log(numberLettersBetweenTwoLetters("e", "l"));
// Caso de teste 2
console.log(numberLettersBetweenTwoLetters("z", "a"));
// Caso de teste 3
console.log(numberLettersBetweenTwoLetters("c", "v"));
