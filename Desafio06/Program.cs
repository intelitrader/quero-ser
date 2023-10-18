using System.Reflection.Metadata.Ecma335;
using System;


Console.Write("Realize o Input com o Primeiro Valor: ");
double numero1 = Convert.ToDouble(Console.ReadLine()); 
Console.WriteLine("");
Console.Write("Realize o Input com o Segundo Valor: ");
double numero2 = Convert.ToDouble(Console.ReadLine()); 
Console.WriteLine("");
string trataNumero1 = numero1.ToString();
string trataNumero2 = numero2.ToString();


numero1 = Convert.ToDouble(trataNumero1);
numero2 = Convert.ToDouble(trataNumero1);

double resultado = numero1 * numero2;

string novoresultado = Convert.ToString(resultado);

Console.WriteLine($" O Resultado foi {novoresultado}");
