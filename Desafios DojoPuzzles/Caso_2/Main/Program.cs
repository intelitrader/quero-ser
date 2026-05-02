
using System;
using System.Collections.Generic;
using Functions;

//string frase = "Um pequeno jabuti xereta viu dez cegonhas felizes.";
int colunas = 0;

Console.WriteLine("DIGITE A FRASE: ");
string frase = Console.ReadLine();

Console.WriteLine("\nDIGITE O TAMANHO DE COLUNAS: ");

try
{
    colunas = Int32.Parse(Console.ReadLine());

    bool valida = FunctionQL.valida(frase, colunas);

    if (valida)
    {
        Console.WriteLine("\n");
        string[] linhas = FunctionQL.quebraLinha(frase, colunas);

        foreach (string element in linhas)
        {
            Console.Write($"{element}\n");
        }
    }
    else
    {
        Console.WriteLine("Tamanho de coluna invalido! \n\nO tamanho da coluna deve ser maior \nque a quantidade de caracteres da maior palavra na frase\n");
    }

    Console.WriteLine("\nAPERTA QUALQUER TECLA PARA ENCERRAR ");
    Console.ReadLine();
}

catch (FormatException)
{
    Console.WriteLine("\nTAMANHO DAS COLUNAS DEVE CONTER SOMENTE NUMEROS.");
}