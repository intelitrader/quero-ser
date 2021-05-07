using System;
using System.Collections.Generic;
using NumerosRomanos.Enums;

// Link do desafio no DojoPuzzles: https://dojopuzzles.com/problems/numeros-romanos/

namespace NumerosRomanos
{
    class Program
    {
        static void Main(string[] args)
        {
            string numString = "";
            int numInt = 0;
            bool numValido = true;
            string retorno = "";

            do
            {
                // Math.Ceiling retorna apenas um valor inteiro (int)
                // Trim() retira todos os espaços em branco da string
                Console.WriteLine("Digite um número em indo-arábico ou romano de 1 à 3000:");
                numString = Console.ReadLine();

                if (int.TryParse(numString, out numInt))
                {
                    numValido = numInt <= 3000 && numInt >= 1;

                    if (numValido)
                        retorno = ConverteParaRomano(numInt);
                }
                else
                {
                    int numVerifica = 0;

                    retorno = ConverteParaNumero(numString);

                    int.TryParse(numString, out numVerifica);

                    // Verifica se o número é maior que 3000 para retornar erro
                    numValido = !(numVerifica > 3000);
                }

                if (!numValido)
                    Console.WriteLine("O número é inválido, pois é menor que 1 ou maior que 3000.");

            } while (!numValido);

            Console.WriteLine($"Número convertido é: {retorno}");
        }

        static string ConverteParaNumero(string num)
        {
            int saida = 0;

            RomanosDefaultValues rdv;
            for (var i = 0; i < num.Length; i++)
            {
                // Converte numero romano em String para um tipo Romano Enum
                rdv = (RomanosDefaultValues)Enum.Parse(typeof(RomanosDefaultValues), num[i].ToString(), true);

                // Caso for I, X ou C
                if (rdv == RomanosDefaultValues.I || rdv == RomanosDefaultValues.X || rdv == RomanosDefaultValues.C)
                {
                    // Verifica se o próximo indice do array
                    if (i + 1 < num.Length)
                    {
                        // Conversão
                        RomanosDefaultValues rdv2 = (RomanosDefaultValues)Enum.Parse(typeof(RomanosDefaultValues), num[i + 1].ToString(), true);

                        // Caso o próximo número romano seja maior que o anterior (apenas nos casos de I, X ou C), subtrai este número anterior do total;
                        if ((int)rdv2 > (int)rdv)
                        {
                            saida -= (int)rdv;
                            // Pula para o próximo loop de repetição
                            continue;
                        }
                    }
                }

                saida += (int)rdv;
            }

            return saida.ToString();
        }

        static string ConverteParaRomano(int num)
        {
            Dictionary<string, int> romanos = new Dictionary<string, int>()
            {
                {"M" , 1000},
                {"D" , 500},
                {"C" , 100},
                {"L" , 50},
                {"X" , 10},
                {"V" , 5},
                {"I" , 1}
            };

            string saida = "";

            RomanosDefaultValues rdv;
            for (var i = 0; num > 0; i++)
            {
                // Loop para verificar qual o número atual em Romanos
                foreach (var rom in romanos.Values)
                {
                    if (num >= rom)
                    {
                        // Calculo para resultar a quantidade de numeros romanos que esta sendo iterado
                        decimal c = num / rom;
                        // Caso venha um valor decimal, converte para inteiro (Truncate) e consegue a quantidade exata de numeros romanos iterado
                        int result = Convert.ToInt32(Math.Truncate(c));

                        // Adquire o valor romano atual no Enum
                        rdv = (RomanosDefaultValues)rom;

                        // For para acrescentar todos os romanos à saída
                        for (var n = 0; n < result; n++)
                        {
                            saida += rdv.ToString();
                        }

                        // Retira a quantidade de romanos que existem no número
                        num = num - (result * rom);

                        // Sai do foreach para recomeçar a busca novamente no dicionário (necessário para a lógica funcionar)
                        break;
                    }
                    else
                    {
                        // Quanto falta de num para ser igual à rom?
                        int result = rom - num;
                        
                        // Resultado do calculo ácima é igual à C, X ou I (em números romanos) e num é diferente de zero?
                        if ((result == 100 || result == 10 || result == 1) && num != 0)
                        {
                            // Adquire o valor romano de num para ser igual à rom (valor que irá subtrair o valor de rom, ficará na esquerda de rom)
                            RomanosDefaultValues rdv2 = (RomanosDefaultValues) result;

                            // Adquire o valor romano atual (valor romano que será subtraído)
                            rdv = (RomanosDefaultValues)rom;

                            // Soma à saida final, o número romano que esta subtraindo (rdv2) o número romano maior (rdv) para dar o número exato
                            saida += $"{rdv2.ToString()}{rdv.ToString()}";

                            num -= num;
                        }
                    }
                }

            }
            return saida;
        }
    }
}
