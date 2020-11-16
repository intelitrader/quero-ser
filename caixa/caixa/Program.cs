using System;

namespace caixa
{
    public class Caixa
    {
        public static string saque(int v)
        {
            int[] notas = { 100, 50, 20, 10 };
            int[] aux = new int[4];
            string resultado = "";

            if (v <= 0)
            {
                resultado = "Valor inválido";
            }
            for (int i = 0; i < notas.Length; i++)
            {
                if (v >= notas[i])
                {
                    aux[i] = v / notas[i];
                    v = v % notas[i];
                }
            }
            for(int i = 0; i<aux.Length;i++)
            {
                if (aux[i] !=0 && aux[i] >= 1)
                {
                    resultado += "nota de " + notas[i].ToString() + ": " + aux[i].ToString() + "\n";
                }
            }
            if (v <= 0)
                return resultado;
            else
                return "Valor indisponível";
                
        }
        static void Main(string[] args)
        {
            int valor = 0;
            Console.WriteLine("Digite o valor a ser sacado: ");
            if( int.TryParse(Console.ReadLine(), out valor) )
            {
                Console.WriteLine(Caixa.saque(valor));
            }
            else
            {
                Console.WriteLine("Valor digitado inválido");
            }
        }


    }
}
