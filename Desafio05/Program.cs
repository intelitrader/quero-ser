using System.Data;
using System.Reflection.PortableExecutable;
using System;
using System.IO;
using System.Text;
namespace Desafio05
{
    class Desafio05
    {
        [STAThread]
        static void Main(string[] args)
        {

            string pastaParaArmazerarArquivoNovo = Directory.GetCurrentDirectory() + @"\ArquivoDeSaida\";
            string pastaParaArmazerarArquivosDeEntrada = Directory.GetCurrentDirectory() + @"\ArquivosDeEntrada\";

            Console.Write("Digite o nome do primeiro arquivo de entrada: ");
            string nomeDoPrimeiroArquivoDeEntrada = Console.ReadLine();

            Console.WriteLine("");
            
            Console.Write("Digite o nome do segundo arquivo de entrada: ");
            string nomeDoSegundoArquivoDeEntrada = Console.ReadLine();

            Console.WriteLine("");

            Console.Write("Digite o nome que deseja dar ao arquivo de Saída: ");
            string nomeDoArquivoDeSaida = Console.ReadLine();

            Console.WriteLine("");



            try
            {
                StreamWriter arquivoNovo = new StreamWriter($"{pastaParaArmazerarArquivoNovo}{nomeDoArquivoDeSaida}.txt", true, Encoding.UTF8);
                var linhas = File.ReadAllLines($"{pastaParaArmazerarArquivosDeEntrada}{nomeDoPrimeiroArquivoDeEntrada}.txt");
                var linhas2 = File.ReadAllLines($"{pastaParaArmazerarArquivosDeEntrada}{nomeDoSegundoArquivoDeEntrada}.txt");
                
                foreach (var linha in linhas)
                {

                    arquivoNovo.WriteLine(linha);
                    //Console.WriteLine(linha);

                }


                foreach (var linha in linhas2)
                {

                    arquivoNovo.WriteLine(linha);
                    //Console.WriteLine(linha);

                }
                    
                
                
                arquivoNovo.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exceção: " + e.Message);
            }
            finally
            {
                Console.WriteLine($"Junção dos arquivos {nomeDoPrimeiroArquivoDeEntrada} e {nomeDoSegundoArquivoDeEntrada} feitas com sucesso!");
                Console.WriteLine($"O arquivo {nomeDoArquivoDeSaida}.txt que foi gerado está no seguinte diretorio:");
                Console.WriteLine($"-> {pastaParaArmazerarArquivoNovo}");

            }
        }
    }
}