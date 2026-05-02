
var jogadorEscolha = 0;
var computadorEscolha = 0;
var ganhador = -1;
var pontuacaoComputador = 0;
var pontuacaoJogador = 0;

//0=empate
//1=ponto do jogador
//2=ponto do computador

function jogar(escolha){
    jogadorEscolha=escolha;

    computadorEscolha=Math.floor((Math.random() *  (3 - 1 + 1))) +1;

    if ((jogadorEscolha == 1) && (computadorEscolha == 1)) {

        ganhador = 0;
    }
    else if ((jogadorEscolha == 1) && (computadorEscolha == 2)) {

        ganhador = 2;
        
    }
     else if ((jogadorEscolha == 1) && (computadorEscolha == 3)) {

        ganhador = 1;
       
    }
     else if ((jogadorEscolha == 2) && (computadorEscolha == 1)) {

        ganhador = 1;
        
    }
     else if ((jogadorEscolha == 2) && (computadorEscolha == 2)) {

        ganhador = 0;
    }
     else if ((jogadorEscolha == 2) && (computadorEscolha == 3)) {

        ganhador = 2;
      
    }
      else if ((jogadorEscolha == 3) && (computadorEscolha == 1)) {

        ganhador = 2;
       
    }
     else if ((jogadorEscolha == 3) && (computadorEscolha == 2)) {

        ganhador = 1;
       
    }
     else if ((jogadorEscolha == 3) && (computadorEscolha == 3)) {

        ganhador = 0;
    }
  

     document.getElementById("jogador-escolha-" + jogadorEscolha).classList.add('selecionado');
    document.getElementById("computador-escolha-" + computadorEscolha).classList.add('selecionado');

    if(ganhador== 0){
        document.getElementById('msm').innerHTML = 'Empate';  
    }
    else if (ganhador == 1) {
        document.getElementById('msm').innerHTML = 'Jogador ganhou';
        pontuacaoJogador = pontuacaoJogador + 1;
    }
    else if (ganhador == 2) {
        document.getElementById('msm').innerHTML = 'Computador ganhou';
        pontuacaoComputador = pontuacaoComputador + 1;
    }

    document.getElementById('jogador-pontos').innerHTML = pontuacaoJogador;
    document.getElementById('computador-pontos').innerHTML = pontuacaoComputador;
}