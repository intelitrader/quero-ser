//https://dojopuzzles.com/problems/sequencia-look-and-say/
#include<iostream>
#include<vector>

using namespace std;

int main(){
    int Number, Adding, Soma;
    vector<int> SeqNumbers, SeqNumbersAux;
    cout<<"---------------------------------------"<<endl;
    cout<<"Digite qualquer dígito de 1 a 9:";
    cin>>Number;
    cout<<"---------------------------------------"<<endl;
    SeqNumbers.push_back(Number);

    for(int count = 1; count <= 50; count++){
        if(count <= 10)
            cout<<endl<<count<<"º -> ";
        
        Adding = 1;
        for(int index = 0 ; index < SeqNumbers.size(); index++){
            if(SeqNumbers[index] == SeqNumbers[index + 1])
                Adding++;
            else{
                SeqNumbersAux.push_back(Adding);
                SeqNumbersAux.push_back(SeqNumbers[index]);
                if(count <= 10)
                cout<<Adding<<SeqNumbers[index];
                Soma += count == 50? Adding : 0;
                Soma += count == 50? SeqNumbers[index] : 0;
                Adding = 1;
            }
        }
        SeqNumbers.clear();
        SeqNumbers.assign(SeqNumbersAux.begin(),SeqNumbersAux.end());
        SeqNumbersAux.clear();

    }
    cout<<endl<<"..."<<endl;
    cout<<endl<<"---------------------------------------"<<endl;
    cout<<"Soma do 50º elemento = "<<Soma<<endl;
    cout<<"---------------------------------------"<<endl;
    return 0;
}