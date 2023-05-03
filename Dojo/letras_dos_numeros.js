const numberInWords = [
    "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten",
    "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen",
    "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
];

function getNumberInWords(num) {
    if (num === 1000) {
        return "onethousand";
    }

    let str = "";

    if (num >= 100) {
        str += numberInWords[Math.floor(num / 100)] + "hundred";
        if (num % 100 !== 0) {
            str += "and";
        }
    }

    if (num % 100 >= 20) {
        str += numberInWords[Math.floor(num % 100 / 10) + 18] + numberInWords[num % 10];
    } else {
        str += numberInWords[num % 100];
    }

    return str;
}

let totalLetters = 0;

for (let i = 1; i <= 1000; i++) {
    totalLetters += getNumberInWords(i).length;
}

console.log(totalLetters); // output: 21124
