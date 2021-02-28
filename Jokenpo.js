/**
*JS - Projeto Jokenpô - http://dojopuzzles.com/problemas/exibe/jokenpo/
*@author Thamara Crema
*/
function jogar() {
   if (document.getElementById("pedra").checked == false &&
   document.getElementById("papel").checked == false &&  
   document.getElementById("tesoura").checked == false){
	   alert("Selecione uma opção");
   } else{
	   //Idetificando qual foi o valor escolhido pelo oponente aleatoriamente
	   var sorteio = Math.floor(Math.random() * 3);
	   switch(sorteio){
		    case 0:
			    document.getElementById("pc").src="C:/Users/prode/Desktop/Projetos/jokenpo/computadorpedra.jpg";
				break;
			case 1:
			    document.getElementById("pc").src="C:/Users/prode/Desktop/Projetos/jokenpo/computadorpapel.jpg";
				break;
			case 2:
			    document.getElementById("pc").src="C:/Users/prode/Desktop/Projetos/jokenpo/computadortesoura.jpg";
				break;
			
		}
		//verificar o vencedor ou declarar empate
   if ((document.getElementById("pedra").checked == true && sorteio == 0) ||
   (document.getElementById("papel").checked == true && sorteio == 1) ||
   (document.getElementById("tesoura").checked == true && sorteio == 2)){
   
		document.getElementById("placar").innerHTML="Empate";
	 
		}
	else if ((document.getElementById("pedra").checked == true && sorteio == 2) ||
	(document.getElementById("papel").checked == true && sorteio == 0) ||
	(document.getElementById("tesoura").checked == true && sorteio == 1)){
		
		document.getElementById("placar").innerHTML ="Você Ganhou!";
		
		} else {
			
			document.getElementById("placar").innerHTML ="Você Perdeu";
		}
	}
}

function resetar(){
   document.getElementById("pc").src="C:/Users/prode/Desktop/Projetos/jokenpo/computador.jpg";
   document.getElementById("placar").innerHTML="";
}