//importar o modulo
const readline = require('readline');

//Criar a interface
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

//Pergunta ao usuário
rl.question('Qual sua jogada, pedra, papel ou tesoura? ', resposta => {
    const opcoes = {
        pedra: 1,
        papel: 2,
        tesoura: 3
    };

    //Requisitando os dados usuário e Maquina
    const escolhaDoUsuario = opcoes[resposta];
    const escolhaDoComputador = Math.round(Math.random() * 2) + 1;


    // Regra do Jogo
    if (escolhaDoUsuario === 1 && escolhaDoComputador === 3) {
        console.log('Você ganhou!');
    } else if (escolhaDoUsuario === 1 && escolhaDoComputador === 2) {
        console.log('Você perdeu!');
    } else if (escolhaDoUsuario === 1 && escolhaDoComputador === 1) {
        console.log('Empatou!');
    }

    if (escolhaDoUsuario === 2 && escolhaDoComputador === 1) {
        console.log('Você ganhou!');
    } else if (escolhaDoUsuario === 2 && escolhaDoComputador === 3) {
        console.log('Você perdeu!');
    } else if (escolhaDoUsuario === 2 && escolhaDoComputador === 2) {
        console.log('Empatou!');
    }

    if (escolhaDoUsuario === 3 && escolhaDoComputador === 2) {
        console.log('Você ganhou!');
    } else if (escolhaDoUsuario === 3 && escolhaDoComputador === 1) {
        console.log('Você perdeu!');
    } else if (escolhaDoUsuario === 3 && escolhaDoComputador === 3) {
        console.log('Empatou!');
    }

    rl.close();
});