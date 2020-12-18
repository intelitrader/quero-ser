var readline = require('readline');

var leitor = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

leitor.question("Digite o valor que deseja sacar: ", function (answer) {
    var nota100 = [];
    var nota50 = [];
    var nota20 = [];
    var nota10 = [];
    var saque = parseInt(answer);

    if (saque < 0) {
        console.log("Informe um valor positivo");
    }
    if (isNaN(saque)) {
        console.log("Informe um número");
    }
    if (saque < 10) {
        console.log("Saque apenas acima de 10 reais");
    }
    if ((saque % 10) !== 0) {
        console.log("Valor inválido para saque");
    }
    else {
        do {
            if ((saque - 100) >= 0) {
                saque -= 100;
                nota100.push("nota");
            }
            else if ((saque - 50) >= 0) {
                saque -= 50;
                nota50.push("nota");
            }
            else if ((saque - 20) >= 0) {
                saque -= 20;
                nota20.push("nota");
            }
            else if ((saque - 10) >= 0) {
                saque -= 10;
                nota10.push("nota");
            }
        } while (saque > 0);
    }

    console.log()

    if (nota100.length > 0) {
        console.log("Você receberá " + nota100.length + " nota(s) de R$100,00");
    }
    if (nota50.length > 0) {
        console.log("Você receberá " + nota50.length + " nota(s) de R$50,00");
    }
    if (nota20.length > 0) {
        console.log("Você receberá " + nota20.length + " nota(s) de R$20,00");
    }
    if (nota10.length > 0) {
        console.log("Você receberá " + nota10.length + " nota(s) de R$10,00");
    }
    console.log()

    leitor.close();
});