/*
	Número felizes
	Endereço: https://dojopuzzles.com/problems/numeros-felizes/
	Para saber se um número é feliz, você deve obter o quadrado de cada dígito deste número, em seguida você faz a soma desses resultados.
	A seguir o mesmo procedimento deve ser feito com o valor resultante desta soma.
	Se ao repetir o procedimento diversas vezes obtivermos o valor 1, o número inicial é considerado feliz.
    Tomamos o 7, que é um número feliz:
    7² = 49
    4² + 9² = 97
    9² + 7² = 130
    1² + 3² + 0² = 10
    1² + 0² = 1
    Podemos observar nesse exemplo que os números 49, 97, 130 e 10 também são felizes.
    Existem infinitos números felizes.
    E um número triste? Como sabemos que um número não será feliz?
    Desenvolva um programa que determine se um número é feliz ou triste.
*/

let numeroFeliz = (function() {
    function somaQuadradoDigitalizado(num) {
        let somaQuadrado = 0;
        for (let dig = num % 10; num > 0; num = (num / 10) | 0, dig = num % 10) {
            somaQuadrado += dig * dig;
        }
        return somaQuadrado;
    }

    function felicidadeMemorizada (num, memoria) {
        if (num > 10000) {
            return felicidadeMemorizada(somaQuadradoDigitalizado(num), memoria);
        }
        if (memoria[num] === undefined) {
            memoria[num] = 'buscando';
            return memoria[num] = felicidadeMemorizada(somaQuadradoDigitalizado(num), memoria);
        } else if (memoria[num] == 'feliz') {
            return 'feliz';
        } else {
            return 'triste';
        }
    }

    let memoria = [];
    memoria[1] = 'feliz';
    return (num) => felicidadeMemorizada(num, memoria) == 'feliz';
})();

for (let i = 0; i <= 130; i++) {
    if (numeroFeliz(i)) {
        console.log(i + ' - Número FELIZ');
    } else {
        console.log( i + ' - Número TRISTE')
    }
}
