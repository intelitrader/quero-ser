const buracosNoTexto = require('../desafios/buracos-no-texto');

describe ('buracos no texto', () => {
    test('apenas letras maiúsculas', () =>
        expect(buracosNoTexto('TESTANDO LETRAS')).toEqual(5));

    test('apenas letras maiúsculas', () =>
        expect(buracosNoTexto('testar o codigo é divertido')).toEqual(11));

    test('alternando maiusculas e minusculas', () =>
        expect(buracosNoTexto('AlTeRnAnDo MaiUsCuLaS e MiNuScUlAs')).toEqual(10));

    test('contabilizar exceção do B maiúsculo', () =>
        expect(buracosNoTexto('Bora testar')).toEqual(6));
});
