const toArabic = (roman) => {
    // transforma em array de letras
    const analyze = roman.split('');

    let result = 0;

    for (let i = 0; i <= analyze.length; i ++) {
        // iterar sobre array uma checagem para cada letra e incrementando o resultado
        const numeral = analyze[i];
        const numeralMaior = analyze[i + 1];
        switch (numeral) {
            case 'I':
                numeralMaior === 'V'|
                numeralMaior === 'X'|
                numeralMaior === 'L'|
                numeralMaior === 'C'|
                numeralMaior === 'D'|
                numeralMaior === 'M'  ? result -- : result ++;
                break;
            case 'V':
                result += 5;
                break;
            case 'X':
                numeralMaior === 'L'|
                numeralMaior === 'C'|
                numeralMaior === 'D'|
                numeralMaior === 'M' ? result -= 10 : result += 10;
                break;
            case 'L':
                result += 50;
                break;
            case 'C':
                numeralMaior === 'D'|
                numeralMaior === 'M'  ? result -= 100 : result += 100;
                break;
            case 'D':
                result += 500;
                break;
            case 'M':
                result += 1000;
                break;
        }
    }
    return result;
};

const Units = {
    1: 'I',
    2: 'II',
    3: 'III',
    4: 'IV',
    5: 'V',
    6: 'VI',
    7: 'VII',
    8: 'VIII',
    9: 'IX',
    0: '',
};
const Tens = {
    1: 'X',
    2: 'XX',
    3: 'XXX',
    4: 'XL',
    5: 'L',
    6: 'LX',
    7: 'LXX',
    8: 'LXXX',
    9: 'XC',
    0: '',
};
const Hundreds = {
    1: 'C',
    2: 'CC',
    3: 'CCC',
    4: 'CD',
    5: 'D',
    6: 'DC',
    7: 'DCC',
    8: 'DCCC',
    9: 'CM',
    0: '',
};
const Thousands = {
    1: 'M',
    2: 'MM',
    3: 'MMM',
    0: '',
};
const Map ={
    0: Units,
    1: Tens,
    2: Hundreds,
    3: Thousands
};

const toRoman = (number) => {
    const translate = [];

    // checar o total de algarisms do argumento para realizar a tradução
    const analyze = ('' + number).split('').reverse();
    const algarisms = analyze.length;

    // dado o total de algarisms, cada casa decimal é traduzida usando o seu numero correspondente
    for(let i = 0; i < algarisms; i++) {
        const transalteMap = Map[i];
        const translated = transalteMap[analyze[i]];
        translate.unshift(translated);
    }
    return translate.join('');
};

module.exports = { toArabic, toRoman };