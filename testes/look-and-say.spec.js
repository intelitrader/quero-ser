const lookAndSay = require('look-and-say')

describe ('look and say', () => {
    test('numero inicial 1, segundo elemento', () =>
        expect(lookAndSay(1, 2)).toEqual('11'));

    test('numero inicial 1, terceiro elemento', () =>
        expect(lookAndSay(1, 3)).toEqual('21'));

    test('numero inicial 1, quarto elemento', () =>
        expect(lookAndSay(1, 4)).toEqual('1211'));

    test('numero inicial 1, quinto elemento', () =>
        expect(lookAndSay(1, 5)).toEqual('111221'));

    test('numero inicial 1, sexto elemento', () =>
        expect(lookAndSay(1, 6)).toEqual('312211'));

    test('numero inicial 2, terceiro elemento', () =>
        expect(lookAndSay(2, 3)).toEqual('1112'));
})