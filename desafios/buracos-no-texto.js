const letrasComBuraco = ['A', 'D', 'O', 'P', 'Q', 'R', 'a', 'b', 'd', 'e', 'g', 'o', 'p', 'q'];

const buracosNoTexto = (texto) => {
    const separator = texto.split('');
    let result = 0;
    for(const letra of separator) {
        if (letra === 'B') {
            result += 2;
        }
        if (letrasComBuraco.includes(letra)) {
            result ++;
        }
    }
    return result;
};
module.exports = buracosNoTexto;