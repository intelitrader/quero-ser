
using Functions;
using System;

/*
 * No arquivo teste é possivel testar diferentes frases
 * Caso a leitura seja feita por arquivo
 * Entrar com caminho de arquivo txt com frases
*/
string[] fileLines = System.IO.File.ReadAllLines(@"C:\Users\user\Desktop\quero-ser\Desafios DojoPuzzles\Caso_1\Expressoes.txt");
ReadFromFile.file(fileLines);


    