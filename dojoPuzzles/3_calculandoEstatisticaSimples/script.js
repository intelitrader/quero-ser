//https://dojopuzzles.com/problems/calculando-estatisticas-simples/
//Calculando estatísticas simples:

var numeros = [6, 9, 15, -2, 92, 11];

//Menor valor
var menorValor = numeros.reduce(function(a, b) {
  return Math.min(a, b);

});

document.write("O menor valor é: " + menorValor + "</br>");



//Maior valor
var maiorValor = numeros.reduce(function(a, b) {
  return Math.max(a, b);
}, -Infinity);

document.write("O maior valor é: " + maiorValor + "</br>");



//Numero de elementos na sequência
var numeroDeElementos = numeros.length;
document.write("O número de elementos na sequência é: " + numeroDeElementos + "</br>");



//Valor médio
var soma = 0;

for (num = 0; num < numeros.length; num++) {
    soma += parseInt(numeros[num]);
}

var valorMedio = soma / numeros.length;

document.write("O valor médio é de: " + valorMedio.toFixed(2));
//Para melhor visualização, serão apresentadas apenas duas casas decimais.