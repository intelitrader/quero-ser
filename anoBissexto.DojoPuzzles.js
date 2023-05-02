// https://dojopuzzles.com/problems/ano-bissexto/


const anoBissexto = (ano) => {
  if (ano % 4 === 0 && ano % 100 === 0 && ano % 400 === 0) return ' é bissexto';
  if(ano % 4 === 0 && ano % 100 === 0) return ' não é bissexto';
  if (ano % 100 === 0) return ' não é bissexto';
  if (ano % 4 === 0) return ' é bissexto';
}

for (let i = 1; i < 2023; i++) {
  if (anoBissexto(i)) console.log(i + anoBissexto(i));
}
