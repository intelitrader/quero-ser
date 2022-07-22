const { toRoman, toArabic } = require('../desafios/numeros-romanos')

describe('toRoman()', () => {
    test('converts 1', () => expect(toRoman(1)).toEqual('I'));
    test('converts 2', () => expect(toRoman(2)).toEqual('II'));
    test('converts 3', () => expect(toRoman(3)).toEqual('III'));
    test('converts 4', () => expect(toRoman(4)).toEqual('IV'));
    test('converts 5', () => expect(toRoman(5)).toEqual('V'));
    test('converts 6', () => expect(toRoman(6)).toEqual('VI'));
    test('converts 9', () => expect(toRoman(9)).toEqual('IX'));
    test('converts 27', () => expect(toRoman(27)).toEqual('XXVII'));
    test('converts 48', () => expect(toRoman(48)).toEqual('XLVIII'));
    test('converts 49', () => expect(toRoman(49)).toEqual('XLIX'));
    test('converts 59', () => expect(toRoman(59)).toEqual('LIX'));
    test('converts 93', () => expect(toRoman(93)).toEqual('XCIII'));
    test('converts 141', () => expect(toRoman(141)).toEqual('CXLI'));
    test('converts 163', () => expect(toRoman(163)).toEqual('CLXIII'));
    test('converts 402', () => expect(toRoman(402)).toEqual('CDII'));
    test('converts 575', () => expect(toRoman(575)).toEqual('DLXXV'));
    test('converts 911', () => expect(toRoman(911)).toEqual('CMXI'));
    test('converts 1024', () => expect(toRoman(1024)).toEqual('MXXIV'));
    test('converts 3000', () => expect(toRoman(3000)).toEqual('MMM'));
});

describe('toArabic()', () => {
    test('converts I', () => expect(toArabic('I')).toEqual(1));
    test('converts II', () => expect(toArabic('II')).toEqual(2));
    test('converts III', () => expect(toArabic('III')).toEqual(3));
    test('converts IV', () => expect(toArabic('IV')).toEqual(4));
    test('converts V', () => expect(toArabic('V')).toEqual(5));
    test('converts VI', () => expect(toArabic('VI')).toEqual(6));
    test('converts IX', () => expect(toArabic('IX')).toEqual(9));
    test('converts XXVII', () => expect(toArabic('XXVII')).toEqual(27));
    test('converts XLVIII', () => expect(toArabic('XLVIII')).toEqual(48));
    test('converts XLIX', () => expect(toArabic('XLIX')).toEqual(49));
    test('converts LIX', () => expect(toArabic('LIX')).toEqual(59));
    test('converts XCIII', () => expect(toArabic('XCIII')).toEqual(93));
    test('converts CXLI', () => expect(toArabic('CXLI')).toEqual(141));
    test('converts CLXIII', () => expect(toArabic('CLXIII')).toEqual(163));
    test('converts CDII', () => expect(toArabic('CDII')).toEqual(402));
    test('converts DLXXV', () => expect(toArabic('DLXXV')).toEqual(575));
    test('converts CMXI', () => expect(toArabic('CMXI')).toEqual(911));
    test('converts MXXIV', () => expect(toArabic('MXXIV')).toEqual(1024));
    test('converts MMM', () => expect(toArabic('MMM')).toEqual(3000));
  });