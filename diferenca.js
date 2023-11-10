// diferenca entre 2 strings
// realizei 1 exercicio a mais pois este não apresentou retorno igual ao esperado

let str1 = "O pássaro amarelo caiu";
let str2 = "O pássaro vermelho caiu bobão";

function diferenca(str1, str2){
  // separa as palavras
  wordsStr1 = str1.split(" ")
  wordsStr2 = str2.split(" ")

  let resultado = [];
  let resultado2 = [];

  for (var i = 0, l=wordsStr1.length; i < l; i++) {
    // se a palavra for igual
    if(wordsStr1[i] === wordsStr2[i]){
      resultado.push(wordsStr1[i])
      resultado2.push(wordsStr2[i])
    }

    // se for diferente adiciona os brackets 
    else{
      resultado.push('['+ wordsStr1[i] + ']')
      resultado2.push('['+ wordsStr2[i] + ']')
    }
  }

  return resultado.join(" ") + ". " + resultado2.join(" ")
}

console.log(diferenca(str1, str2))
