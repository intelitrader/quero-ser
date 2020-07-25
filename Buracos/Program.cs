using System;

namespace Buracos
{
    class Program
    {
        static void Buracos()
        {
            Console.WriteLine("Informe o texto");
            string texto = Console.ReadLine();

            //atribui valor as letras
            int contaBuracos = 0;

            foreach (var i in texto.ToCharArray())
            {
                string letra = i.ToString();

                //letras com valor = a 1
                if (
                    letra == "A" ||
                    letra == "a" ||
                    letra == "Á" ||
                    letra == "á" ||
                    letra == "Â" ||
                    letra == "â" ||
                    letra == "À" ||
                    letra == "à" ||
                    letra == "Ã" ||
                    letra == "ã" ||
                    letra == "e" ||
                    letra == "é" ||
                    letra == "è" ||
                    letra == "ê" ||
                    letra == "O" ||
                    letra == "o" ||
                    letra == "Ó" ||
                    letra == "ó" ||
                    letra == "Ò" ||
                    letra == "ò" ||
                    letra == "Õ" ||
                    letra == "õ" ||
                    letra == "b" ||
                    letra == "D" ||
                    letra == "d" ||
                    letra == "P" ||
                    letra == "p" ||
                    letra == "Q" ||
                    letra == "q" ||
                    letra == "R"
                )
                {
                    //adicionando valor 1
                    contaBuracos += 1;
                }
                //letras com valor = a 2
                else if (
                    letra == "B" ||
                    letra == "g"

                )
                {
                    //adicionando valor 2
                    contaBuracos += 2;
                }
            }
            //exibi o valor do contador
            Console.WriteLine(contaBuracos);
            Buracos();
        }
        static void Main(string[] args)
        {
            Program.Buracos();
        }
    }
}
