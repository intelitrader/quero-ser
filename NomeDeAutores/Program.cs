using System;
using System.Collections.Generic;

//https://dojopuzzles.com/problems/nomes-de-autores-de-obras-bibliograficas/
namespace NomeDeAutores
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;
            string nome, meioNome, sobrenome;
            Autores autor;
            try // tratamento de erros gerais
            {
                Console.Write("Digite o numero de nomes que sera fornecido: ");
                num = int.Parse(Console.ReadLine()); // pegando o numero de nomes que vai ser digitado

                for (int i = 0; i < num; i++) //for para digitar os nomes
                {
                    Console.Write("Digite o nome do autor: ");
                    string[] vet = Console.ReadLine().Split(' '); //criando um vetor para pegar cada nome

                    while (vet.Length >= 4) // verifica se a pessoa tem mais de 3 nomes
                    {
                        Console.Write("nome não deve ter mais de 2 sobrenomes: ");
                        vet = Console.ReadLine().Split(' ');
                    }

                    if (vet.Length == 1) // para verificar se a pessoa so tem 1 nome
                    {
                        sobrenome = vet[0]; // pegando o nome que tem 
                        autor = new Autores(sobrenome); //criando o obj autor para guardar o nome
                        autor.FormatarNome(); // formatando o nome
                    }
                    else if (vet[1] == "da" || vet[1] == "de" || vet[1] == "do" || vet[1] == "das" || vet[1] == "dos" || vet[1] == "DA" || vet[1] == "DE" || vet[1] == "DO" || vet[1] == "DAS" || vet[1] == "DOS")
                    {
                        nome = vet[0]; // guardando o nome
                        meioNome = vet[1]; // pegando o "da", "de", "do", "das", "dos" 
                        sobrenome = vet[2]; // guardando o sobrenome
                        autor = new Autores(nome, meioNome, sobrenome); //criando um obj autor para guardar os nomes
                        autor.FormatarNome(); //formatando os nomes
                    }
                    else if ((vet.Length == 3) && (vet[2] == "filho" || vet[2] == "filha" || vet[2] == "neto" || vet[2] == "neta" || vet[2] == "sobrinho" || vet[2] == "sobrinha" || vet[2] == "junior")) //"FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA" ou "JUNIOR"
                    {
                        nome = vet[0]; //pegando o nome
                        sobrenome = vet[1] + " " + vet[2]; // pegando o sobrenome junto com FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA" ou "JUNIOR"
                        autor = new Autores(nome, sobrenome); //criando um obj autor para guardar os nomes
                        autor.FormatarNome(); // formatando os nomes
                    }
                    else if (vet.Length == 3)
                    {
                        nome = vet[0]; //pegando o nome
                        sobrenome = vet[2]; // pegando  o sobrenome
                        autor = new Autores(nome, sobrenome); // criando um obj autor para guardar os nome
                        autor.FormatarNome(); // formatando os nomes
                    }
                    else
                    {
                        nome = vet[0]; //pegando o nome
                        sobrenome = vet[vet.Length - 1]; //pegando o ultimo nome da pessoa e colocando como sobrenome
                        autor = new Autores(nome, sobrenome); //criando um obj autor para guardar os nomes
                        autor.FormatarNome(); // formatando os nomes
                    }
                    Console.WriteLine(autor + "\n"); // imprimindo na tela o nome do autor
                }
            }
            catch // caso de erros
            {
                Console.WriteLine("Dados Informados Invalido");
            }
        }
    }
}
