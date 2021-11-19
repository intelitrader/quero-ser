

//Exemplo input
using System;
using Functions;

Console.WriteLine("\nDigite uma frase com no maximo 255 Caracteres");
Console.WriteLine("sem virgulas, acentos, numeros ou qualquer caracterer especial: \n");

//recebe a frase do usuario
string frase = Console.ReadLine().ToUpper();

if (frase.Length > 255)
{
    Console.WriteLine("\nFrase superior a 255 caracteres. ");
}
else
{
    //chama a funcao que vai transformar frase em codigo
    string codigo = FunctionsCode.transformCode(frase);

    if (codigo != "False")
    {
        Console.WriteLine("\nCodigo numerico: " + codigo + "\n");
    }
    else
    {
        Console.WriteLine("Caracter invalido na frase");
    }
}

Console.WriteLine("\n Aperte qualquer tecla para encerrar \n");
Console.ReadLine();