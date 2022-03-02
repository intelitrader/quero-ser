#include <iostream>
using namespace std;

//https://dojopuzzles.com/problems/jokenpo/

//declaração da função jokenpo
void jokenpo(int p1, int p2){    
  int ganhador;
  
  if (p1 == p2){
   cout << "Empate";
  }
  
  if((p1 == 1 && p2 == 2) || (p1 == 2 && p2 == 1)){
    ganhador = 2;
   cout << "Ganhador: Papel";
  }

  if((p1 == 1 && p2 == 3) || (p1 == 3 && p2 == 1)){
    ganhador = 1;
   cout << "Ganhador: Pedra";
  }

  if((p1 == 2 && p2 == 3) || (p1 == 3 && p2 == 2)){
    ganhador = 3;
    cout << "Ganhador: Tesoura";
  }

 
  if(p1 == ganhador){
    cout << " (Jogador 1)";
  } else{
    cout << " (Jogador 2)";
  }
  
}

int main() {
  //Declaração de variáveis
  int pedra = 1;
  int papel = 2;
  int tesoura = 3;
  int jogador1, jogador2;

  //Inicio do jogo
  cout << "\n---- Opções ----\n1 - Pedra\n2 - Papel\n3 - Tesoura\n";

  while(true){
    cout<<"\n";
    do{    
      cout << "Jogador 1, digite uma das opções: ";
      cin >> jogador1;   
    }while(jogador1 < 1 || jogador1 > 3);
    
    do{    
      cout << "Jogador 2, digite uma das opções: ";
      cin >> jogador2;   
    }while(jogador2 < 1 || jogador2 > 3);
    
    //Chamada da função jokenpo
    jokenpo(jogador1, jogador2);     
    cout<<"\n";
  } 
}