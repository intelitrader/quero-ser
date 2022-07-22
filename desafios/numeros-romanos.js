const toArabic = (roman) => {
    // transforma em array de letras
    const Analyze = roman.split('')

    let result = 0
    for (let i = 0; i <= Analyze.length; i ++) {
        // iterar sobre array uma checagem para cada letra e incrementando o resultado
        let numeral = Analyze[i]
        let numeralMaior = Analyze[i + 1]
        switch (numeral) {
            case 'I':
                numeralMaior === 'V'|
                numeralMaior === 'X'|
                numeralMaior === 'L'|
                numeralMaior === 'C'|
                numeralMaior === 'D'|
                numeralMaior === 'M'  ? result -- : result ++
                break
            case 'V':
                result += 5;
                break
            case 'X':
                numeralMaior === 'L'|
                numeralMaior === 'C'|
                numeralMaior === 'D'|
                numeralMaior === 'M' ? result -= 10 : result += 10
                break
            case 'L':
                result += 50;
                break
            case 'C':
                numeralMaior === 'D'|
                numeralMaior === 'M'  ? result -= 100 : result += 100;
                break
            case 'D':
                result += 500;
                break
            case 'M':
                result += 1000;
                break
        }
    }
    return result
}

const Units = {
    unit1() { return 'I'},
    unit2() { return 'II'},
    unit3() { return 'III'},
    unit4() { return 'IV'},
    unit5() { return 'V'},
    unit6() { return 'VI'},
    unit7() { return 'VII'},
    unit8() { return 'VIII'},
    unit9() { return 'IX'},
    unit0() { return },
}
const Tens = {
  ten1() { return 'X'},
  ten2() { return 'XX'},
  ten3() { return 'XXX'},
  ten4() { return 'XL'},
  ten5() { return 'L'},
  ten6() { return 'LX'},
  ten7() { return 'LXX'},
  ten8() { return 'LXXX'},
  ten9() { return 'XC'},
  ten0() {return},
}
const Hundreds = {
  hundred1() { return 'C'},
  hundred2() { return 'CC'},
  hundred3() { return 'CCC'},
  hundred4() { return 'CD'},
  hundred5() { return 'D'},
  hundred6() { return 'DC'},
  hundred7() { return 'DCC'},
  hundred8() { return 'DCCC'},
  hundred9() { return 'CM'},
  hundred0() { return },
}
const Thousands = {
  thousand1() { return 'M'},
  thousand2() { return 'MM'},
  thousand3() { return 'MMM'},
  thousand0() { return },
}

const toRoman = (number) => {
    const traducao = []
    let unidade, dezena, centena, milhar
    //checar o total de algarismos do argumento para realizar a tradução
    const Analyze = ('' + number).split('')
    const Algarismos = Analyze.length

    // dado o total de algarismos, cada casa decimal é traduzida usando o seu numero correspondente
    if( Algarismos === 1) {
        let unidade = Analyze[0]
        let translateUnit = Units[`unit${unidade}`]
        traducao.push(translateUnit());
    }

    if( Algarismos === 2) {
        let unidade = Analyze[1]
        let translateUnit = Units[`unit${unidade}`]

        let dezena = Analyze[0]
        let translateTen = Tens[`ten${dezena}`]

        traducao.unshift(translateUnit());
        traducao.unshift(translateTen());
    }

    if( Algarismos === 3) {
        let unidade = Analyze[2]
        let translateUnit = Units[`unit${unidade}`]

        let dezena = Analyze[1]
        let translateTen = Tens[`ten${dezena}`]

        let centena = Analyze[0]
        let translateHundred = Hundreds[`hundred${centena}`]

        traducao.unshift(translateUnit());
        traducao.unshift(translateTen());
        traducao.unshift(translateHundred());
    }
    if( Algarismos === 4) {
        let unidade = Analyze[3]
        let translateUnit = Units[`unit${unidade}`]

        let dezena = Analyze[2]
        let translateTen = Tens[`ten${dezena}`]

        let centena = Analyze[1]
        let translateHundred = Hundreds[`hundred${centena}`]

        let milhar = Analyze[0]
        let translateThousand = Thousands[`thousand${milhar}`]
        traducao.unshift(translateUnit());
        traducao.unshift(translateTen());
        traducao.unshift(translateHundred());
        traducao.unshift(translateThousand());
    }
    return traducao.join('')
}

export { toArabic, toRoman }