using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Desafio01
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            LogoProj detalhesProjeto = new LogoProj();

            detalhesProjeto.InvocarLogo();
            detalhesProjeto.InvocarNomeApp();
            detalhesProjeto.InvocarNomeAutor();

            Console.ForegroundColor = ConsoleColor.Green;

            string diretorioDoArquivoDeEntrada = $"{Directory.GetCurrentDirectory()}\\Entrada\\";
            string diretorioDoArquivoDeSaida = $"{Directory.GetCurrentDirectory()}\\Saida\\";
            
            Console.WriteLine("Digite o nome do arquivo juntamente com a extensão:");

            string nomeDoArquivo = Console.ReadLine();


            
            ManipulaArquivo mp = new ManipulaArquivo();
            Dictionary<char, int> caracteres = mp.LerArquivo($"{diretorioDoArquivoDeEntrada}{nomeDoArquivo}");
            String frase = mp.Texto;
            Console.WriteLine("### characters! ###");
            foreach (var item in caracteres)
            {
                if (item.Value.Equals(' '))
                {
                    Console.Write("espaço");
                }
                //Console.WriteLine ("caracter", item, "freq: ", caracteres[item])/;
                Console.WriteLine("caracter = {0}, freq = {1}", item.Key, item.Value);
			
            }

            caracteres = mp.SortDictionary(caracteres);
            Console.WriteLine("\n### sorted characters! ###\n");
  
            Arvore tree = new Arvore();

            Node root = tree.BuildTree(caracteres);
            tree.InOrder(root);

            Dictionary<char, String> hash = tree.HashCaminhos;
            tree.CriaTabela(root, "");
  
            Data data = new Data(tree, frase);
            Serializa s = new Serializa();
            s.Serializar(data);

             string numeroDeSerieDoArquivoDeSaida = Convert.ToString(s.NumeroDeSerie());
            

            Data newdata = s.Desserializar();

            String newFrase = newdata.Descompacta();
            Serializa s1 = new Serializa($"{diretorioDoArquivoDeSaida}{numeroDeSerieDoArquivoDeSaida}_{nomeDoArquivo}");
            s1.SerializarString(newFrase);


            Console.Clear();

            Console.WriteLine("Obrigado por usar o meu compactador!");
            Console.WriteLine("Espero que tenha gostado :)");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pressione Enter para encerrar a aplicação.......");
            Console.ReadLine();
            

            Console.Clear();


        }
    }
}