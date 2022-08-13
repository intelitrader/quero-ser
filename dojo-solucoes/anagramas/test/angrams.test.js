const factor = (num) => {
    if (num === 0) return 1
    else return num * factor(num - 1);
};

const anagrams = (word) => {
    const anagramsAmount = factor(word.length);
    const wordArr = word.split('');
    const anagramsList = [];
    let newWord = [];

    while (anagramsList.length <= anagramsAmount) { 
        for (let i = 0; i < anagramsAmount; i++) {
            for (let i = 0; i < word.length; i++) {
                let randomIndex = Math.floor(Math.random() * word.length);
            
                if (newWord.indexOf(wordArr[randomIndex]) === -1 && wordArr.length === word.length) {
                    newWord.push(wordArr[randomIndex]);
                }

            }
            let newWordStr = newWord.join('');
            if (newWordStr.length === word.length && anagramsList.indexOf(newWordStr) === -1 ) anagramsList.push(newWordStr);
            newWord = [];
        }
        if (anagramsList.length === anagramsAmount) return anagramsList.join(' ');
    }

    return anagramsList.join(' ');
};

describe('Teste da função que gera anagramas', () => {
    test('Testando para a palavra biro', () => {
        let word = 'biro';
        const result = anagrams(word);
        const anagramsAmount = factor(word.length); 
        console.log(result);

        expect(result.split(' ').length).toEqual(anagramsAmount);
    });
});