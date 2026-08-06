const nextElement = (digit) => {
    const analyze = (digit + '').split('');
    const result = [];

    for(let i = 0; i < analyze.length; i ++) {
        let accumulator = 1;
        while(i + 1 < analyze.length && analyze[i] === analyze[i + 1]) {
            i ++;
            accumulator ++;
        }
        result.push('' + accumulator);
        result.push(analyze[i]);
    }
    return result.join('');
};

const lookAndSay = (digit, n) => {
    let element = digit;
    for(let i = 1; i < n; i++) {
        element = nextElement(element);
    }
    return element;
};

module.exports = lookAndSay;