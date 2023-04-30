using DesafioIntelitrader;
using System.Linq;

//Instanciando as classes referentes a cada arquivo que será criado
TransferenciaTxt transferenciaTxt = new TransferenciaTxt();
DivergenciaTxt divergenciaTxt = new DivergenciaTxt();
VendaCanalTxt vendaCanalTxt = new VendaCanalTxt();

//Chamando os metódos de criação de cada arquivo
transferenciaTxt.CriarTxt();
divergenciaTxt.CriarTxt();
vendaCanalTxt.CriarTxt();