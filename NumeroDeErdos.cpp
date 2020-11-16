#include <bits/stdc++.h>

using namespace std;

//Resolvido com busca em largura ou BFS
int main()
{
    int N;//qtd de arestas
    cin>>N;

    while(N)
    {
        cin.ignore();//vou usar getline embaixo de cin, e sempre buga, por isso cin.ignore() aqui
        string x;


        string ERDOS = "P. Erdos";
        map<string,int> dist;
        map<string,set<string> > grafo;

        for(int cnt = 1;cnt<=N;cnt++)//tudo neste for serve apenas para montar o grafo
        {
            getline(cin,x);
            vector<string> nomes;
            string aux;
            int i;
            for(int i = 0;i<x.size();i++)
            {
                if(x[i] == ',' or i == x.size()-1)
                {
                    dist[aux] = 1e9;
                    nomes.push_back(aux);
                    i++;aux = "";
                }
                else
                {
                    aux+=x[i];
                }

            }
            for(int i = 0;i<nomes.size();i++)
            {
                for(int j = 0;j<nomes.size();j++)
                {
                    if(i!=j)
                    {
                        grafo[nomes[i]].insert(nomes[j]);
                        grafo[nomes[j]].insert(nomes[i]);
                    }

                }
            }
        }

        //BFS começa aqui
        queue<string> kiwi;
        kiwi.push(ERDOS);
        dist[ERDOS] = 0;

        while(kiwi.size())
        {
            string atual = kiwi.front();kiwi.pop();

            for(auto i = grafo[atual].begin();i!=grafo[atual].end();i++)
            {
                if(dist[*i] == 1e9)
                {
                    kiwi.push(*i);
                    dist[*i] = dist[atual]+1;
                }
            }
        }

        cout<<"Resposta: "<<endl;
        for(auto i = dist.begin();i!=dist.end();i++)// não imprimi ordenado da forma que o problema queria no SPOJ pois o DojoPuzzle não pedia.
        {
            if(i->first!=ERDOS)
            {
                cout<<i->first<<": ";
                if(i->second!=1e9)
                    cout<<i->second<<endl;
                else
                    cout<<"infinito"<<endl;
            }
        }
        cin>>N;
    }
}













