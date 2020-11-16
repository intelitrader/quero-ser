#include <bits/stdc++.h>

using namespace std;

int L,C;

char mat[1001][1001];
int um,todos,qtd,dias;
bool vis[1001][1001];
int vetI[] = {1,-1,0,0};
int vetJ[] = {0,0,1,-1};

//a complexidade ficou péssima, peço perdão :(
void preenche(int i,int j)
{
    for(int k = 0;k<4;k++)
    {
        int x = i+vetI[k],y = j+vetJ[k];
        if(x >= 0 and x < L and y >= 0 and y < C and !vis[x][y])
        {
            if(mat[x][y] != '#')
            {
                if(mat[x][y] == 'A')
                {
                    if(!qtd)
                    {
                        um = dias;
                    }
                    qtd++;
                }
                mat[x][y] = '#';
                vis[x][y] = true;
            }
        }
    }
}

int main()
{
    cin>>L>>C;

    for(int i = 0;i<L;i++)
    {
        for(int j = 0;j<C;j++)
        {
            cin>>mat[i][j];
            if(mat[i][j] == 'A')
                todos++;
            vis[i][j] = 0;
        }
    }
    dias = 1;
    qtd = 0;
    while(qtd < todos)
    {
        for(int i = 0;i<L;i++)
        {
            for(int j = 0;j<C;j++)
            {
                vis[i][j] = 0;
            }
        }

        for(int i = 0;i<L;i++)
        {
            for(int j = 0;j<C;j++)
            {
                if(mat[i][j] == '#' and !vis[i][j])
                {
                    preenche(i,j);
                }
            }
        }
        dias++;
    }
    cout<<um<<" "<<dias-1<<endl;

}

