//Quebra de Linha - Coding Dojo - https://dojopuzzles.com/problems/quebra-de-linha/

function formatLine (phrase: string, columns: number):string {
  const phraseWords = phrase.split(' ');
  let formattedLine = [] as string[];
  let currentLine = "";
  
  for (let index = 0; index < columns; index++) {

    if (currentLine.length <= columns) {
      const placeholderLine = currentLine + " " + phraseWords[index];

      if (placeholderLine.length <= columns) {
        //remove o espaço vazio
        if (index === 1) {
          currentLine = placeholderLine.slice(1);
        } else {
          currentLine = placeholderLine;
        }

        formattedLine.push(currentLine);
      }
    }
  }

  if(phrase === ''){
    return null
  }

  return formattedLine.reverse()[0];
}

function formatPhrase(phrase: string, columns: number):string[] {

  let phraseLines = [] as string[];
  
  for (let index = 0; index < 4; index++) {
    if(phraseLines[0] === undefined){
      phraseLines.push(formatLine(phrase, columns))
    }else{
      const newLine = phrase.split(phraseLines[index - 1]).reverse()[0].slice(1)
      const newFormattedLine = formatLine(newLine, 20) 

      if(newFormattedLine === null){
        break;
      }

      phraseLines.push(newFormattedLine)
    } 
  }
   
  return phraseLines
}

const phraseFormatted = formatPhrase("Um pequeno jabuti xereta viu dez cegonhas felizes.", 20);
console.log(phraseFormatted)

// output: ["Um pequeno jabuti", "xereta viu dez", "cegonhas felizes."]
