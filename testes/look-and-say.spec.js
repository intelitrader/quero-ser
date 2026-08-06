const lookAndSay = require('../desafios/look-and-say');

describe ('look and say', () => {
    test('numero inicial 1, segundo elemento espera "11"', () =>
        expect(lookAndSay(1, 2)).toEqual('11'));

    test('numero inicial 1, terceiro elemento espera "21"', () =>
        expect(lookAndSay(1, 3)).toEqual('21'));

    test('numero inicial 1, quarto elemento espera "1211"', () =>
        expect(lookAndSay(1, 4)).toEqual('1211'));

    test('numero inicial 1, quinto elemento espera "111221"', () =>
        expect(lookAndSay(1, 5)).toEqual('111221'));

    test('numero inicial 1, sexto elemento espera "312211"', () =>
        expect(lookAndSay(1, 6)).toEqual('312211'));

    test('numero inicial 2, terceiro elemento "1112"', () =>
        expect(lookAndSay(2, 3)).toEqual('1112'));
});