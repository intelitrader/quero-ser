// metodo readline para pegar dinamicamente e amigavelmente o input da pessoa usuária
import * as readline from 'node:readline';
import { stdin, stdout } from 'process';

// Função para fatoração para descobrir a quantidade de anagramas que uma palavra tem
export const factor = (num: number): number => {
    if (num === 0) return 1
    else return num * factor(num - 1);
};

// Função para gerar anagramas retorna uma string com todos os anagramas
export const anagrams = (word: string): string => {
    const anagramsAmount: number = factor(word.length);
    const wordArr: string[] = word.split('');
    const anagramsList: string[] = [];
    let newWord: string[] = [];

    while (anagramsList.length <= anagramsAmount) { 
        for (let i = 0; i < anagramsAmount; i++) {
            for (let i = 0; i < word.length; i++) {
                let randomIndex: number = Math.floor(Math.random() * word.length);
            
                if (newWord.indexOf(wordArr[randomIndex]) === -1 && wordArr.length === word.length) {
                    newWord.push(wordArr[randomIndex]);
                }

            }
            let newWordStr: string = newWord.join('');
            if (newWordStr.length === word.length && anagramsList.indexOf(newWordStr) === -1 ) anagramsList.push(newWordStr);
            newWord = [];
        }
        if (anagramsList.length === anagramsAmount) return anagramsList.join(' ');
    }

    return anagramsList.join(' ');
};

// Criando interação com pessoa usuária usando readline
const rl: readline.Interface = readline.createInterface({
    input: stdin,
    output: stdout
});

rl.question('Por gentileza escreva uma palavra que não tenha letras repetidas -> ', (word: string) => {
    if (isNaN(Number(word))) {
        console.log('Os possíveis anagramas são:',anagrams(word));
        return rl.close();
    }
    else {
        console.log('Um número não conta!');
        rl.question('escreva uma palavra -> ', (word: string) => {
            console.log('Os possíveis anagramas são:', anagrams(word));
            return rl.close();
        });
    }
});