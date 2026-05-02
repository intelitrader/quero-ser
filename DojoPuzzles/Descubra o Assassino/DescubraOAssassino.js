// Primeiro defini a resposta randomicamente
let suspeito = Math.floor(Math.random() * 6) + 1;
let local = Math.floor(Math.random() * 10) + 1;
let armas = Math.floor(Math.random() * 6) + 1;

// Então foi feita uma função para pegar a resposta do "investigador"
function testeDeTeoria(){

    // Teorias do investigador
    let teoriaSuspeito = document.getElementById('Suspeito').value;
    let teoriaLocal = document.getElementById('Local').value;
    let teoriaArma = document.getElementById('Arma').value;

    // recebo a tag html e coloco ela em uma variável
    let testemunha = document.getElementById('testemunha');

    // Então é feito os teste comparando a resposta com a teoria do investigador
    // Para diminuir o número de tentativas, a testemunha diz na ordem das respostas qual está incorreta até que o investigador acerte

    if(suspeito == teoriaSuspeito && local == teoriaLocal && armas == teoriaArma){
        testemunha.innerHTML = 'Você desvendou o mistério!';
    } else if (suspeito != teoriaSuspeito) {
        testemunha.innerHTML = 'Esse não foi o assassino.'
    } else if (local != teoriaLocal) {
        testemunha.innerHTML = 'Não foi neste local.'
    } else if ( armas != teoriaArma ) {
        testemunha.innerHTML = 'Não foi essa arma.'
    }

}

// Função para que ao clicar no botão testando a teoria, não recarregue a pagina.
document.getElementById('button').addEventListener('click', function(e) {
    e.preventDefault();
    return true;
  });