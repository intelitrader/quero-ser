//https://dojopuzzles.com/problems/numeros-felizes/
#include<iostream>
#include<math.h>
#include<vector>

using namespace std;

int main(){
    int Numero;
    vector<int> NumeroVetor;
    vector<int> ColecaoDeSomas;

    cout<<"----------------------------"<<endl;
    cout<<"Digite um Numero inteiro: ";
    cin>>Numero;
    cout<<"----------------------------"<<endl;

    while(Numero != 1){
        while(abs(Numero) >= 1){
            NumeroVetor.push_back(Numero%10);
            Numero /= 10;
        }
        Numero = 0;
        for(int count = NumeroVetor.size()-1; count >= 0; count--){
            count == 0? cout<<NumeroVetor[count]<<"² = ": cout<<NumeroVetor[count]<<"² + ";
            Numero += pow(NumeroVetor[count],2);
            NumeroVetor.pop_back();
        }
        ColecaoDeSomas.push_back(Numero);
        cout<<Numero<<endl;
        if(ColecaoDeSomas.size() > 12){
            cout<<"----------------------------"<<endl;
            cout<<"Número triste :("<<endl;
            cout<<"----------------------------"<<endl;
            return 0;
        }

    }
    cout<<"----------------------------"<<endl;
    cout<<"Número felizz :)"<<endl;
    cout<<"----------------------------"<<endl;
    return 0;
}

