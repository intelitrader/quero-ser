#include <bits/stdc++.h>

using namespace std;

int main()
{
    int x,y;
    cin>>x>>y;

    cout<<(x+y)*((y-x)+1)/2<<endl; //famoso somatório de gauss
    int a = x,b = y;
    if(x%2 == 0)
    {
        a++;
    }
    if(y%2 == 0)
    {
        b++;
    }
    cout<<(a+b)*((((b-a)+1)/2)+1)/2<<endl;//soma dos ímpares entre x e y, inclusive

    x+=x%2;//se for ímpar transforma em par somando o resto
    y-=y%2;//mesma coisa
    cout<<(x+y)*((((y-x)+1)/2)+1)/2<<endl;//soma dos pares entre x e y, inclusive
}
