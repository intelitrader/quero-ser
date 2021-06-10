using System;

namespace Caixa_Eletrônico
{
    public class Calcular
    {
        public void CalculadorDeNotas (int valor)
        {
            var notasDe100 = 0;
            var notasDe50 = 0;
            var notasDe20 = 0;
            var notasDe10 = 0;

            if (valor >= 100)
            {
                while (valor >= 100)
                {
                    notasDe100 ++;
                    valor = valor - 100;
                }
            }

            if (valor >= 50 && valor <= 100)
            {
                while (valor >= 50 && valor <= 100)
                {
                    notasDe50++;
                    valor = valor - 50;
                }
            }

            if (valor >= 20 && valor <= 49)
            {
                while (valor >= 20 && valor <= 49)
                {
                    notasDe20++;
                    valor = valor - 20;
                }
            }

            if (valor >= 10)
            {
                while (valor >= 10 && valor <= 19)
                {
                    notasDe10++;
                    valor = valor - 10;
                }
            }

            Console.WriteLine(" Numero de notas de 100 : " + notasDe100);
            Console.WriteLine(" Numero de notas de 50 : " + notasDe50);
            Console.WriteLine(" Numero de notas de 20 : " + notasDe20);
            Console.WriteLine(" Numero de notas de 10 : " + notasDe10);

            if(valor != 0)
                Console.WriteLine("Houve uma sobra de : " + valor);

        }
    }
}
