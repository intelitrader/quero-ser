

let userChoice = '';
const resultUserJogada = new Image(200, 200);
const resultMaqJogada = new Image(200, 200);
const jokenpo = document.querySelector('.container-jokenpo');
let usuarioJogada = document.querySelector('#usuario');
let mJogada = document.querySelector('#maquina');
let opcoesMaquina = ['pedra', 'papel', 'tesoura'];
let macJogada = rand(opcoesMaquina);

jokenpo.addEventListener('click', function (e) {
    const el = e.target;
    if (el.classList.contains('pedra')) {
        userChoice = 'pedra';
        suaJogada();
    } else if (el.classList.contains('papel')) {
        userChoice = 'papel';
        suaJogada();
    } else if (el.classList.contains('tesoura')) {
        userChoice = 'tesoura';
        suaJogada();
    }
});

function suaJogada() {

    if (userChoice === 'pedra') {
        resultUserJogada.src = 'acets/imagens/pedra.png'
        usuarioJogada.appendChild(resultUserJogada);
    } else if (userChoice === 'papel') {
        resultUserJogada.src = 'acets/imagens/papel.png'
        usuarioJogada.appendChild(resultUserJogada);
    } else if (userChoice === 'tesoura') {
        resultUserJogada.src = 'acets/imagens/tesoura.png'
        usuarioJogada.appendChild(resultUserJogada);
    }
}

function maquinaJogada() {

    if (macJogada === 'pedra') {
        resultMaqJogada.src = 'acets/imagens/pedra.png'
        mJogada.appendChild(resultMaqJogada);
    } else if (macJogada === 'papel') {
        resultMaqJogada.src = 'acets/imagens/papel.png'
        mJogada.appendChild(resultMaqJogada);
    } else if (macJogada === 'tesoura') {
        resultMaqJogada.src = 'acets/imagens/tesoura.png'
        mJogada.appendChild(resultMaqJogada);
    }
}

function rand(opcoesMaquina) {
    return (opcoesMaquina[~~(opcoesMaquina.length * Math.random())]);
}

function verificaJogar() {
    if (userChoice === '') {
        window.alert('Escolha uma opção')
    } else {
        jogar();
    }
}

function resetar() {
    rand(opcoesMaquina);
    limpaSuaJogada();
}

function jogar() {
    macJogada = rand(opcoesMaquina);
    maquinaJogada();
    if ((userChoice === 'pedra' && macJogada === 'pedra') || (userChoice === 'papel' && macJogada === 'papel') || (userChoice === 'tesoura' && macJogada === 'tesoura')) {
        resultUserJogada.src = 'acets/imagens/empate.jpg'
    } else if ((userChoice === 'pedra' && macJogada === 'tesoura') || (userChoice === 'tesoura' && macJogada === 'papel') || (userChoice === 'papel' && macJogada === 'pedra')) {
        resultUserJogada.src = 'acets/imagens/youwin.png'
        usuarioJogada.appendChild(resultUserJogada);
    } else if ((userChoice === 'tesoura' && macJogada === 'pedra') || (userChoice === 'papel' && macJogada === 'tesoura') || (userChoice === 'pedra' && macJogada === 'papel')) {
        resultUserJogada.src = 'acets/imagens/gameover.png'
        usuarioJogada.appendChild(resultUserJogada);
    }
}

function limpaSuaJogada() {
    macChoice = ''
    userChoice = ''
    resultUserJogada.parentNode.removeChild(resultUserJogada);
    resultMaqJogada.parentNode.removeChild(resultMaqJogada);
}


