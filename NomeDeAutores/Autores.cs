using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NomeDeAutores
{
    class Autores
    {
        public string Nome { get; set; }
        public string MeioNome { get; set; } // "da", "de", "do", "das", "dos" 
        public string Sobrenome { get; set; }
 
        public Autores(string nome, string sobrenome) //Contrutor para o autores 
        {
            Nome = nome;
            Sobrenome = sobrenome;
        }

        public Autores(string nome, string meioNome, string sobrenome) //Construtor para os autores com "da", "de", "do", "das", "dos" 
        {
            Nome = nome;
            MeioNome = meioNome;
            Sobrenome = sobrenome;
        }

        public Autores(string sobrenome) // construtor para os autores com apenas 1 nome
        {
            Sobrenome = sobrenome;
        }


        public void FormatarNome() // Formata o sobrenome para letra maiuscula
        {
            Sobrenome = Sobrenome.ToUpper();
            if (Nome != null) // verificando o autor tem apenas 1 nome 
            {
                Nome = Nome.ToLower(); // colocando o nome da pessoa em minusculo
                Nome = char.ToUpper(Nome[0]) + Nome.Substring(1); // transformando apenas a 1 letra do nome em maisculo
            }
            if (MeioNome != null) // verificando se o autor tem "da", "de", "do", "das", "dos" no nome
                MeioNome = MeioNome.ToLower();
        }

        public override string ToString() //para imprimir na tela de um jeito mais simples
        {
            if (MeioNome == null && Nome == null) // caso so tenha um nome
            {
                return Sobrenome;
            } 
            else if  (MeioNome == null) // caso nao tenha "da", "de", "do", "das", "dos" no nome
            {
                return Sobrenome
                + ", "
                + Nome;
            }
            else // tem "da", "de", "do", "das", "dos" no nome
            {
                return Sobrenome
                + ", "
                + Nome
                + " "
                + MeioNome;
            }
        }

    }
}
