// Link: https://drive.google.com/file/d/10aNQ3kYPIK8wZqzmYjemPl44Qv_O0Up8/view?usp=sharing

const readline = require("readline");
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
  terminal: false,
});

rl.on("line", (entrada) => {
  // Separar a entrada em um array de palavras
  const words = entrada.split(" ");
  /*
   ** Uma função que verifica (checagem) um array de strings
   ** à procura de uma palavra que possui duplicação,
   ** retornando true se encontrado, e false se não.
   */
  function isThereAWordWithoutDuplication(words) {
    const result = words.find((word) => {
      // Casos: a o
      if (word.length === 1) {
        return true;
      }
      // Casos: oo de banana bacana
      if (word.length >= 2 && word.length % 2 === 0) {
        const halfWord = word.length / 2;
        const firstPart = word.slice(0, halfWord);
        const secondPart = word.slice(halfWord);
        if (firstPart === secondPart) {
          return false;
        } else {
          if (word.length >= 6) {
            const wordWithoutFirstSyllable = word.slice(2);
            const halfWord = wordWithoutFirstSyllable.length / 2;
            const firstPart = wordWithoutFirstSyllable.slice(0, halfWord);
            const secondPart = wordWithoutFirstSyllable.slice(halfWord);
            if (firstPart === secondPart) {
              return false;
            } else {
              return true;
            }
          } else {
            return true;
          }
        }
      }
      // Casos: dee deu ratoato rinha
      if (word.length >= 3 && word.length % 2 !== 0) {
        const wordWithoutFirstLetter = word.slice(1);
        const halfWord = wordWithoutFirstLetter.length / 2;
        const firstPart = wordWithoutFirstLetter.slice(0, halfWord);
        const secondPart = wordWithoutFirstLetter.slice(halfWord);
        if (firstPart === secondPart) {
          return false;
        } else {
          return true;
        }
      }
    });

    let answer;
    if (result) {
      answer = true;
    } else {
      answer = false;
    }

    return answer;
  }
  /*
   ** Uma função que lida (tratativa) com um array de strings,
   ** corrigindo palavra por palavra apropriadamente,
   ** as adicionando à um novo array de palavras corrigidas,
   ** e retornando este novo array.
   */
  function correctWords(words) {
    let correctedWord = "";
    let array = [""];

    words.forEach((word) => {
      // Casos: oo de banana bacana
      if (word.length >= 2 && word.length % 2 === 0) {
        const halfWord = word.length / 2;
        const firstPart = word.slice(0, halfWord);
        const secondPart = word.slice(halfWord);
        if (firstPart === secondPart) {
          correctedWord = firstPart;
        } else {
          const firstSyllable = word.slice(0, 2);
          const wordWithoutFirstSyllable = word.slice(2);
          const halfWord = wordWithoutFirstSyllable.length / 2;
          const firstPart = wordWithoutFirstSyllable.slice(0, halfWord);
          correctedWord = firstSyllable + firstPart;
        }
      }
      // Casos: dee deu ratoato rinha
      if (word.length >= 3 && word.length % 2 !== 0) {
        const firstLetter = word.slice(0, 1);
        const wordWithoutFirstLetter = word.slice(1);
        const halfWord = wordWithoutFirstLetter.length / 2;
        const firstPart = wordWithoutFirstLetter.slice(0, halfWord);
        correctedWord = firstLetter + firstPart;
      }
      // adicionar palavra corrigida à frase corrigida
      array.push(correctedWord);
    });

    // remove o espaço vazio criado na inicialização da variável
    array.shift();

    return array;
  }
  /*
   ** Verifica se há uma palavra sem duplicação.
   ** Se sim, retorna toda a entrada original formatada.
   ** Se não, retorna a entrada corrigida e formatada.
   */
  const result = isThereAWordWithoutDuplication(words);
  if (result) {
    console.log(`${entrada}.`);
  } else {
    // transforma o array em string e adiciona ponto final na frase
    const correctedPhrase = correctWords(words).join(" ") + ".";
    console.log(correctedPhrase);
  }

  // fechar readline
  rl.close();
});
