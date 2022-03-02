#include <iostream>
using namespace std;

//https://dojopuzzles.com/problems/produto-escalar-de-vetores/

//Função para calcular produto escalar
void produtoEscalar(int a[], int b[], int n){
  int resultado = 0;
  
  for(int i = 0; i < n; i++){
    resultado += a[i]*b[i];
  }    
  
  cout << "\nO valor do produto escalar é: " << resultado;
}

//Função para pegar valores
void pegaValores(int vetor[], int n){
  for(int i = 0; i < n; i++){
    cout << "Valor na posição " << i+1 << "\n";
    cin >> vetor[i];
  }
}

int main() {  
  
  //Input do tamanho máximo (n)
  int n;
  cout << "Qual o tamanho dos vetores? \n";
  cin >> n;

  //Atribuição de range dos vetores
  int vetorA[n];
  int vetorB[n];

  //Inputs dos valores individuais dos vetores (i+1)
  cout << "\n ---- Vetor A ---- \n";
  pegaValores(vetorA,n);    
  cout << "\n ---- Vetor B ---- \n";
  pegaValores(vetorB,n);

  //Produto escalar
  produtoEscalar(vetorA, vetorB, n);
  
}
