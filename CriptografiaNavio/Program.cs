using System;

namespace CriptografiaNavio {
    class Program {
        public static void Main(string[] args) {
            var mensagem = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

            string[] mensagemArray = mensagem.Split(" ");

            var novoArray = "";

            for (int i = 0; i < mensagemArray.Length; i++)
            {
                var primeiro = mensagemArray[i].Substring(0, 4);
                var segundo = mensagemArray[i].Substring(4, 4);
                var terceiro = segundo.Substring(0, 2);
                var quarto = segundo.Substring(2, 2);
                var quinto = terceiro.Substring(0, 1);
                if (quinto == "0")
                {
                    quinto = "1";
                } else
                {
                    quinto = "0";
                }
                var sexto = quarto.Substring(1, 1);
                if (sexto == "0") {
                    sexto = "1";
                } else {
                    sexto = "0";
                }
                var uniao = terceiro + quinto + sexto + primeiro + ' ' ;
                novoArray += uniao;
            }

            var mensagemFinal = novoArray.Split(' ');
            var mensagemFinalString = "";
            for (int i = 0; i < mensagemFinal.Length - 1; i++)
            {
                mensagemFinalString += Convert.ToChar(Convert.ToInt32(mensagemFinal[i], 2));
            }
            Console.WriteLine(mensagemFinalString);
        }
    }
}