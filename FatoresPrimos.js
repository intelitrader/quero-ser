var readline = require('readline');

var leitor = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

leitor.question("Digite um número: ", function (answer) {

    var num = parseInt(answer);
    var fatores = [];

    while (num % 2 == 0) {
        fatores.push(2);
        num = num / 2;
    }

    var d = 3;
    var d2 = 9;
    while (d2 <= num) {
        if (num % d == 0) {
            fatores.push(d);
            num = num / d;
        } else {
            d = d + 2;
            d2 = d * d;
        }
    }

    if (num > 1) {
        fatores.push(num);
    }

    console.log(answer + ' = ' + fatores.join(' x '));

    leitor.close();
});