//https://dojopuzzles.com/problems/matriz-espiral/
#include<iostream>
#include<vector>

using namespace std;

int main(){
    int linhas, colunas, total, LinhaAtual,ColunaAtual;
    int numberAdd = 1;
    

    cout<<"----------------------------"<<endl;
    cout<<"Digite o numero de linhas: ";
    cin>>linhas;
    cout<<"Digite o numero de colunas: ";
    cin>>colunas;
    cout<<"----------------------------"<<endl;

    total = linhas * colunas;

    int Matriz[linhas][colunas];
    for(int M = 0; M < linhas; M++){
        for(int N = 0; N < colunas; N++){
            Matriz[M][N] = 0;
        }
    }

    for(int count = 1; count <= total; count){
        
        LinhaAtual = count == 1? 0 : ++LinhaAtual;
        ColunaAtual = count == 1? (colunas-1) : --ColunaAtual;

        //normal linha primeira
        for(int M = 0; M < colunas; M++){
            if(!Matriz[LinhaAtual][M]){
                Matriz[LinhaAtual][M] = count;
                count++;
            }
        }

        //normal coluna ultima
        for(int N = 0; N < linhas; N++){
            if(!Matriz[N][ColunaAtual]){
                Matriz[N][ColunaAtual] = count;
                count++;
            }
        }
        LinhaAtual = count == 1? (linhas-1): (linhas-1)-LinhaAtual;
        ColunaAtual = count == 1? 0: (colunas-1)-ColunaAtual;

        //inverso linha ultima
        for(int M = colunas-1; M >= 0 ; M--){
            if(!Matriz[LinhaAtual][M]){
                Matriz[LinhaAtual][M] = count;
                count++;
            }
        }
        //inverso coluna primeira
        for(int N = linhas-1; N >= 0 ; N--){
            if(!Matriz[N][ColunaAtual]){
                Matriz[N][ColunaAtual] = count;
                count++;
            }
        }
        LinhaAtual = count == 1? 0: (linhas-1)-LinhaAtual;
        ColunaAtual = count == 1? (colunas-1): (colunas-1)-ColunaAtual;
        
    }
    for(int M = 0; M < linhas; M++){
        for(int N = 0; N < colunas; N++){
            if(Matriz[M][N] < 10)
                cout<<" "<<Matriz[M][N]<<" ";
            else
                cout<<Matriz[M][N]<<" ";
        }
        cout<<endl;
    }
    cout<<"----------------------------"<<endl;
    return 0;
}