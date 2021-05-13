using System;
using System.Collections.Generic;

namespace Exercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> nums = new List<double>();

            for (var i = 0; i < 3; i++)
            {
                Console.WriteLine($"Digite qualquer numero {i + 1}/3:");
                double num = Convert.ToDouble(Console.ReadLine());

                nums.Add(num);
            }

            FunctionMaiorMenorMedia(nums);
        }

        // Função feita sob pressão o resultado é uma decepção
        public static void MenorMaiorMedia(double num1, double num2, double num3)
        {
            double maior = 0;
            double menor = 0;

            // Verificando qual o maior número
            if (num1 > num2 && num1 > num3)
                maior = num1;
            else if (num2 > num1 && num2 > num3)
                maior = num2;
            else if (num3 > num1 && num3 > num2)
                maior = num3;

            // Verificando qual o menor número
            if (num1 < num2 && num1 < num3)
                menor = num1;
            else if (num2 < num1 && num2 < num3)
                menor = num2;
            else if (num3 < num1 && num3 < num2)
                menor = num3;

            // Verificando se os numeros são iguais

            double media = (num1 + num2 + num3) / 3;

            Console.WriteLine($"Média: {media} | Maior: {maior} | Menor: {menor}.");
        }

        public static void FunctionMaiorMenorMedia(List<double> nums)
        {
            double maior = 0;
            double menor = 0;

            for (var i = 0; i < nums.Count; i++)
            {
                if(i == 0){
                    maior = nums[i];
                    menor = nums[i];
                }

                if(nums[i] < menor){
                    menor = nums[i];
                }
                else if(nums[i] > maior){
                    maior = nums[i];
                }
            }

            double media = (nums[0] + nums[1] + nums[2]) / 3;

            Console.WriteLine($"Média: {media} | Maior: {maior} | Menor: {menor}.");
        }
    }
}
