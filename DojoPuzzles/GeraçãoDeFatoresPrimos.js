// Aqui deve ser colocado o numero a ser fatorado
let fatorarNumero = 110;

// Coloco em uma variável para pode altera-lo e no fim poder mostrar o numero inicial.
let numero = fatorarNumero;

// Aqui é colocado o caminho percorrido até o resultado final
let divisões = [];

while (numero != 1){

    if (numero % 2 == 0) {
        numero /= 2
        divisões.push(2)
    } else if (numero % 3 == 0) {
        numero /= 3
        divisões.push(3)
    } else if (numero % 5 == 0) {
        numero /= 5
        divisões.push(5)
    } else if (numero % 7 == 0) {
        numero /= 7
        divisões.push(7)
    } else if (numero % 11 == 0) {
        numero /= 11
        divisões.push(11)
    } else {
        divisões.push(numero)
    }

    
}
// Transformar os números em string e colocar um "x" entre eles
let potencias = divisões.join(" x ");
console.log(fatorarNumero, "=", potencias);