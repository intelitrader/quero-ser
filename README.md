// Login : https://dojopuzzles.com/problems/gerar-login/ by Lucas Tanaka

#ifndef LOGIN_H
#define LOGIN_H

#include

using namespace std;

bool validarNome(string nome, string sobrenome, string &msg){
if(nome[0] < 64 or nome[0] > 91){
cout << endl;
msg = "Erro. A primeira letra deve ser uma letra maiuscula. Digite novamente. \n";
return false;
}
for(int i = 1; i < nome.size(); i++){
if(nome[i] < 96 or nome[i] > 123){
cout << endl;
msg = "Erro! O nome não devem ter simbolos e deve começar com letra maiuscula e o restante minuscula. Digite novamente. \n";
return false;
}
}
if(sobrenome[0] < 64 or sobrenome[0] > 91){
cout << endl;
msg = "Erro. A primeira letra do sobrenome deve ser uma letra maiuscula. Digite novamente. \n";
return false;
}
for(int i = 1; i < sobrenome.size(); i++){
if(sobrenome[i] < 96 or sobrenome[i] > 123){
cout << endl;
msg = "Erro! O nome não deve ter simbolos e deve começar com letra maiuscula e o restante minuscula. Digite novamente. \n";
return false;
}
}
return true;
}

bool validarNascimento(string nascimento, string &msg){
if(nascimento[2] != '/' and nascimento[5] != '/'){
cout << endl;
msg = "Erro! O dia, mes e o ano devem ser separadas por /. Digite novamente. \n";
return false;
}
if(nascimento[0] > 52 or nascimento[0] < 48 and nascimento[1] > 57 or nascimento[1] < 48){
cout << endl;
msg = "Erro! Dia invalido. Digite novamente. \n";
return false;
}
if(nascimento[3] < 48 or nascimento[3] > 50 and nascimento[4] > 57 or nascimento[4] < 48){
cout << endl;
msg = "Erro! Mes invalido. Digite novamente. \n";
return false;
}
if(nascimento[6] < 48 or nascimento[6] > 50 and nascimento[7] != 57 or nascimento[7] != 48 and nascimento[8] < 48 or nascimento[8] > 57 and nascimento[9] > 57 or nascimento[9] < 48){
cout << endl;
msg = "Erro! Ano invalido. Digite novamente. \n";
return false;
}
return true;
}

bool validarEmail(string email, string &msg){
string formatoPadrao = "x@y.z";

int posAt = -1;
int posDot = -1;

int amountAt = 0;
int amountDot = 0;

for (int index = 0; index < email.size(); index++) {
    if(email[index] == '@' and posAt == -1){
        posAt = index;
    }else if(email[index] == '.' and posDot == -1){
        posDot = index;
    }
    
    if(email[index] == '@')
        amountAt++;
    
    if(email[index] == '.')
        amountDot++;
}

if(amountAt > 1){
    cout << endl;
    msg = "Erro de formatação: muitos @";
    return false;
}

if(amountDot > 1){
    cout << endl;
    msg = "Erro de formatação: muitos .";
    return false;
}

if(posDot < posAt){
    cout << endl;
    msg = "Erro de formatação: posição incorreta do .";
    return false;
}

if(amountAt == 0 or amountDot == 0){
    cout << endl;
    msg = "Erro de formatação: sem @ ou sem .";
    return false;
}
return true;
}

bool sugestaoLogin(string login, string nome, string sobrenome, string email, string nascimento, string &msg){
string sugestao1 = sobrenome + nascimento[0] + nascimento[1];
string sugestao2 = sobrenome + nascimento[8] + nascimento[9];
string sugestao3 = nome + nascimento[6] + nascimento[7]; + nascimento[8] + nascimento[9];
string sugestao4 = sobrenome + '@' + nascimento[8] + nascimento[9];

if(login != sugestao1 and login != sugestao2 and login != sugestao3 and login != sugestao4){
    cout << endl;
    cout << "Login ja existente. O login deve ser unico." << endl;

    cout << "Sugestoes de login: " << endl;
    cout << sugestao1 << endl;
    cout << sugestao2 << endl;
    cout << sugestao3 << endl;
    cout << sugestao4 << endl;
    cout << endl;
    
    return false;
}
return true;
}

#endif

#include
#include "Login.h"

using namespace std;

int main(){
string nome, sobrenome, nascimento, email, login, msg = "";

do{
	cout << msg << endl;
	
	cout << "Digite seu primeiro e ultimo nome: ";
	cin >> nome >> sobrenome;

}while(!validarNome(nome, sobrenome, msg));

msg = "";

do{
	cout << msg << endl;
	
	cout << "Digite sua data de nascimento [dd/mm/aaaa]: ";
	cin >> nascimento;
	
}while(!validarNascimento(nascimento, msg));

msg = "";

do{
	cout << msg;
	
	cout << "Digite seu email [x@y.z]: ";
	cin >> email;

}while(!validarEmail(email, msg));

msg = "";

do{	
	cout << msg;

	cout << "Login desejado: ";
	cin >> login;

}while(!sugestaoLogin(login, nome, sobrenome, email, nascimento, msg));

cout << "cadastro realizado com sucesso!" << endl;

return 0;
}

// Telefone : https://dojopuzzles.com/problems/desbloqueando-seu-telefone/ by Lucas Tanaka

#ifndef TELEFONE_H
#define TELEFONE_H

#include

using namespace std;

bool desbloquearTelefone(string pin, string desbloquear, string &msg){
if(pin != desbloquear){
msg = "PIN incorreto! Digite o PIN novamente. \n";
return false;
}
msg = "Telefone desbloqueado com sucesso!";
return true;
}

bool validarPin(string pin, string padrao, string &msg){
if(pin.size() < 2 and pin.size() > 17){
msg = "Erro! O pin deve conter de 2 até 9 digitos conforme o formato " + padrao + ". Digite novamente o PIN.\n";
return false;
}
for(int index = 0; index <= pin.size(); index++){
if(index % 2 != 0 and pin[index] != '-' and index < pin.size() - 1){
msg = "Erro! Deve conter '-' entre os numeros conforme o formato " + padrao + ". Digite novamente o PIN.\n";
return false;
}else if(index % 2 == 0 or index == 0){
char umCaracter = pin[index];
int versaoInteiraCaracter = (int) umCaracter;

        if(versaoInteiraCaracter < 48 and versaoInteiraCaracter > 57){
            msg = "Erro! O numero do PIN não segue o formato " + padrao + " em que X representa um numero de 0 a 9. Digite novamente. \n";
            return false;
        }
        if(pin[index] == pin[index + 2] or pin[index] == pin[index + 4] or pin[index] == pin[index + 6] or pin[index] == pin[index + 8] or pin[0] == pin[10] == pin[12] == pin[14] == pin[16]){
            msg = "Erro! Os numeros contidos no PIN nao devem se repetir. Digite novamente. \n";
            return false;
        }
        if(pin[index] < 0){
            msg = "Erro! Os numeros do PIN nao deve conter numeros menores que zero. Digite novamente. \n";
            return false;
        }
    }else{}
}
msg = "O seu PIN foi guardado com sucesso!";
return true;
}

int padroesValidos(string pin){
int quantidadePadroesValidos = 9, quantidadeTracos = 0;

for(int index = 0; index <= (pin.size() - 1); index++){
    if(index % 2 != 0 or pin[index] == '-')
        quantidadeTracos ++;
}

int apenasNumeros = pin.size() - quantidadeTracos;

for(int i = 8; i >= apenasNumeros; i--){
    quantidadePadroesValidos = quantidadePadroesValidos * i;
}
return quantidadePadroesValidos;
}

#endif /* TELEFONE_H */

#include
#include "Telefone.h"

using namespace std;

int main(){
string padrao = "(X-X-X-X)";
string pin;
string desbloquear;
string msg = "";

do{
    cout << msg;
    
    cout << "Digite um novo PIN para o seu telefone no formato " + padrao + ": ";
    cin >> pin;
    
    cout << endl;

}while(!validarPin(pin, padrao, msg));

cout << msg << endl;

cout << "Havia pelo menos " << padroesValidos(pin) << " padroes validos contidos nesta quantidade de digitos." << endl;

msg = "";

do{
    cout << msg;

    cout << "\nDigite o PIN para desbloquear o telefone: ";
    cin >> desbloquear;
    
    cout << endl;

}while(!desbloquearTelefone(pin, desbloquear, msg));

cout << msg << endl;

return 0;
}

// Ladrilhando : https://dojopuzzles.com/problems/ladrilhando/ by Lucas Tanaka

#ifndef LADRILHOS_H
#define LADRILHOS_H

#include
#include <math.h>

using namespace std;

int calcularLadrilhos(int A, int B, int C, int D, int E, int altura, int largura){
int d1 = sqrt(pow((A - 0), 2) + pow((0 - 0), 2));
int d2 = sqrt(pow((D - 0), 2) + pow((E - 0), 2));
int d3 = sqrt(pow((B - D), 2) + pow((C - E), 2));
int d4 = sqrt(pow((B - A), 2) + pow((C - 0), 2));
int areaSala = 0;

if(d1 == d2 == d3 == d4)
    areaSala = pow(d1,2);
else 
    areaSala = d1 * d2;

int areaLadrilho = altura * largura;

return areaSala / areaLadrilho;
}

bool validarTamanho(int altura, int largura, string &msg){
if(altura <= 0 or largura <= 0){
msg = "Erro! O tamanho do ladrilho deve ser numeros inteiros maiores que zero. \n";
return false;
}
return true;
}

#endif

#ifndef COORDENADAS_H
#define COORDENADAS_H

#include
#include <math.h>
using namespace std;

bool validarPontos(int A,int B, int C, int D, int E, string &msg){
int d1 = sqrt(pow((A - 0), 2) + pow((0 - 0), 2));
int d2 = sqrt(pow((D - 0), 2) + pow((E - 0), 2));
int d3 = sqrt(pow((B - D), 2) + pow((C - E), 2));
int d4 = sqrt(pow((B - A), 2) + pow((C - 0), 2));

if(A < 0 or B < 0 or C < 0 or D < 0 or E < 0){
    msg = "As coordenadas devem conter números inteiros maiores que zero. Digite novamente. \n";
    return false;
}
if(B == D and C == E){
    msg = "Erro! Os vértices (B, C) e (D, E) não podem coincidir. Digite novamente.\n";
    return false;
}
if(d1 != d2 and d2 != d3 and d3 != d4 and d4 != d1){
    msg = "Erro! Os pontos citados não correspondem a uma sala quadrangular. Digite novamente. \n";
    return false;
}
return true;
}

#endif

#include
#include
#include "Coordenadas.h"
#include "Ladrilhos.h"

using namespace std;

int main(){
int coordenadaA = 0;
int coordenadaB = 0;
int coordenadaC = 0;
int coordenadaD = 0;
int coordenadaE = 0;
int larguraLadrilho;
int alturaLadrilho = 0;
int distancia = 0;
string msg = "";

do{
    cout << msg;
    cout << "Complete os quatro pontos de cada vértice da sala (0, 0), (A, 0), (B, C) e (D, E)" << endl;
    cout << "A: ";
    cin >> coordenadaA;
    cout << "B: ";
    cin >> coordenadaB;
    cout << "C: ";
    cin >> coordenadaC;
    cout << "D: ";
    cin >> coordenadaD;
    cout << "E: ";
    cin >> coordenadaE;
    cout << endl;

}while(!validarPontos(coordenadaA, coordenadaB, coordenadaC, coordenadaD, coordenadaE, msg));

do{
    msg = "";
    cout << "Informe o tamanho do ladrilho [Altura x Largura]: ";
    cin >> alturaLadrilho >> larguraLadrilho;
    cout << endl;

}while(!validarTamanho(alturaLadrilho, larguraLadrilho, msg));

cout << "Quantidade de ladrinhos para cobrir a sala atual: " << calcularLadrilhos(coordenadaA, coordenadaB, coordenadaC, coordenadaD, coordenadaE, alturaLadrilho, larguraLadrilho) << endl;

return 0;

}
