/*
    Escreva um programa que gere todos os anagramas potenciais de uma string.
    https://dojopuzzles.com/problems/anagramas/
*/

let gerarAnagramas = (palavra, anagrama = '', anagramas = []) => {
    if (!palavra) {
        anagramas.push(anagrama);
        return;
    }
    for(let i = 0; i < palavra.length; i++) {
        anagrama += palavra[i];
        gerarAnagramas(palavra.slice(0, i) + palavra.slice(i + 1), anagrama, anagramas);
        anagrama = anagrama.slice(0, anagrama.length - 1);
    }
    return [...new Set(anagramas)];
};

console.log(gerarAnagramas('AbCDe'));
