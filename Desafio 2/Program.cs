using System;
using System.Threading;

namespace Desafio_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
             /*
            FEITO POR LUIS FERNANDO DE MESQUITA PEREIRA
            DESAFIO DOJO
            */
            string frase = "", fraseTraduzida = null;
            Console.WriteLine("=== ESCREVA A FRASE SEM CARACTERES ESPECIAIS OU ACENTOS, COM NO MÁXIMO 255 CARACTERES : ");
            frase = Console.ReadLine().ToUpper();
            Console.WriteLine("traduzindo...");
            Thread.Sleep(2000);
            if(frase.Length > 255){
                Console.WriteLine("Máximo de 255 caracteres");
            }else{
                Array palavras = frase.Split(" ");
                string palavra = null;
                if(palavras.Length < 2){
                    foreach (var item in palavras)
                    {
                        palavra = item.ToString();
                    }
                    for(int i = 0; i < palavra.Length; i++){
                        
                        switch (palavra[i])
                        {
                            case 'A' : fraseTraduzida = fraseTraduzida + string.Concat("2"); break;
                            case 'B' : fraseTraduzida = fraseTraduzida + string.Concat("22"); break;
                            case 'C' : fraseTraduzida = fraseTraduzida + string.Concat("222"); break;
                            case 'D' : fraseTraduzida = fraseTraduzida + string.Concat("3"); break;
                            case 'E' : fraseTraduzida = fraseTraduzida + string.Concat("33"); break;
                            case 'F' : fraseTraduzida = fraseTraduzida + string.Concat("333"); break;
                            case 'G' : fraseTraduzida = fraseTraduzida + string.Concat("4"); break;
                            case 'H' : fraseTraduzida = fraseTraduzida + string.Concat("44"); break;
                            case 'I' : fraseTraduzida = fraseTraduzida + string.Concat("444"); break;
                            case 'J' : fraseTraduzida = fraseTraduzida + string.Concat("5"); break;
                            case 'K' : fraseTraduzida = fraseTraduzida + string.Concat("55"); break;
                            case 'L' : fraseTraduzida = fraseTraduzida + string.Concat("555"); break;
                            case 'M' : fraseTraduzida = fraseTraduzida + string.Concat("6"); break;
                            case 'N' : fraseTraduzida = fraseTraduzida + string.Concat("66"); break;
                            case 'O' : fraseTraduzida = fraseTraduzida + string.Concat("666"); break;
                            case 'P' : fraseTraduzida = fraseTraduzida + string.Concat("7"); break;
                            case 'Q' : fraseTraduzida = fraseTraduzida + string.Concat("77"); break;
                            case 'R' : fraseTraduzida = fraseTraduzida + string.Concat("777"); break;
                            case 'S' : fraseTraduzida = fraseTraduzida + string.Concat("8"); break;
                            case 'T' : fraseTraduzida = fraseTraduzida + string.Concat("88"); break;
                            case 'U' : fraseTraduzida = fraseTraduzida + string.Concat("888"); break;
                            case 'V' : fraseTraduzida = fraseTraduzida + string.Concat("9"); break;
                            case 'W' : fraseTraduzida = fraseTraduzida + string.Concat("99"); break;
                            case 'X' : fraseTraduzida = fraseTraduzida + string.Concat("999"); break;
                            case 'Y' : fraseTraduzida = fraseTraduzida + string.Concat("9999"); break;
                            case 'Z' : fraseTraduzida = fraseTraduzida + string.Concat("99999"); break;
                            default: Console.WriteLine("Letra não identificada : " + palavra[i]); break;
                        }
                        int j = 0;
                        if(i != palavra.Length - 1){
                            j = i +1;
                            if(palavra[i].ToString() == palavra[j].ToString()){
                            fraseTraduzida = fraseTraduzida + string.Concat("_");
                            }
                        }
                    }
                    Console.WriteLine("Frase traduzida:  "+ fraseTraduzida); 
                }else{
                    int cont = 0;
                    foreach (var item in palavras)
                    {
                    palavra = item.ToString();
                    //Transformar palavra em números                                                                      
                    for(int i = 0; i < palavra.Length; i++){
                         switch (palavra[i])
                        {
                            case 'A' : fraseTraduzida = fraseTraduzida + string.Concat("2"); break;
                            case 'B' : fraseTraduzida = fraseTraduzida + string.Concat("22"); break;
                            case 'C' : fraseTraduzida = fraseTraduzida + string.Concat("222"); break;
                            case 'D' : fraseTraduzida = fraseTraduzida + string.Concat("3"); break;
                            case 'E' : fraseTraduzida = fraseTraduzida + string.Concat("33"); break;
                            case 'F' : fraseTraduzida = fraseTraduzida + string.Concat("333"); break;
                            case 'G' : fraseTraduzida = fraseTraduzida + string.Concat("4"); break;
                            case 'H' : fraseTraduzida = fraseTraduzida + string.Concat("44"); break;
                            case 'I' : fraseTraduzida = fraseTraduzida + string.Concat("444"); break;
                            case 'J' : fraseTraduzida = fraseTraduzida + string.Concat("5"); break;
                            case 'K' : fraseTraduzida = fraseTraduzida + string.Concat("55"); break;
                            case 'L' : fraseTraduzida = fraseTraduzida + string.Concat("555"); break;
                            case 'M' : fraseTraduzida = fraseTraduzida + string.Concat("6"); break;
                            case 'N' : fraseTraduzida = fraseTraduzida + string.Concat("66"); break;
                            case 'O' : fraseTraduzida = fraseTraduzida + string.Concat("666"); break;
                            case 'P' : fraseTraduzida = fraseTraduzida + string.Concat("7"); break;
                            case 'Q' : fraseTraduzida = fraseTraduzida + string.Concat("77"); break;
                            case 'R' : fraseTraduzida = fraseTraduzida + string.Concat("777"); break;
                            case 'S' : fraseTraduzida = fraseTraduzida + string.Concat("8"); break;
                            case 'T' : fraseTraduzida = fraseTraduzida + string.Concat("88"); break;
                            case 'U' : fraseTraduzida = fraseTraduzida + string.Concat("888"); break;
                            case 'V' : fraseTraduzida = fraseTraduzida + string.Concat("9"); break;
                            case 'W' : fraseTraduzida = fraseTraduzida + string.Concat("99"); break;
                            case 'X' : fraseTraduzida = fraseTraduzida + string.Concat("999"); break;
                            case 'Y' : fraseTraduzida = fraseTraduzida + string.Concat("9999"); break;
                            case 'Z' : fraseTraduzida = fraseTraduzida + string.Concat("99999"); break;
                            default: Console.WriteLine("Letra não identificada : " + palavra[i]); break;
                        }
                        int j = 0;
                        if(i != palavra.Length - 1){
                            j = i +1;
                            if(palavra[i].ToString() == palavra[j].ToString()){
                            fraseTraduzida = fraseTraduzida + string.Concat("_");
                            }
                        }
                        
                    }
                    cont = cont + 1;
                    if( cont != palavras.Length){
                        fraseTraduzida = fraseTraduzida + string.Concat("0");
                    }
                }
                Console.WriteLine("Frase traduzida:  "+ fraseTraduzida); 
                
            }
        }
        }
    }
}
