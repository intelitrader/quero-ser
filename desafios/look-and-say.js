const nextElement = (digit) => {
    const separator = (digit + '').split('');
    const resultado = [];
    let acumulador = 1;

    for(let i = 0; i < separator.length; i ++) {
        // checagem se numero atual e o proximo sao iguais
        while(i + 1 < separator.length && separator[i] == separator[i + 1]) {
            i ++;
            acumulador ++;
        }
        // guardar o numero de ocorrencias no acumulador + o numero em si
        resultado.push('' + acumulador);
        resultado.push(separator[i]);
    }
    return resultado.join('');
};

const lookAndSay = (digit, n) => {
    // recursão para descobrir o elemento desejado
    let element = digit;
    for(let i = 1; i < n; i++) {
        element = nextElement(element);
    }
    return element;
};

module.exports = lookAndSay;