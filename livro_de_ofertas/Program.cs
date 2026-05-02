using System;
namespace livro_de_ofertas;

class Program
{
    static void Main(string[] args)
    {
        string[] dados = new string[]
        {
            "12",
            "1,0,15.4,50",
            "2,0,15.5,50",
            "2,2,0,0",
            "2,0,15.4,10",
            "3,0,15.9,30",
            "3,1,0,20",
            "4,0,16.50,200",
            "5,0,17.00,100",
            "6,0,16.59,20",
            "6,2,0,0",
            "1,2,0,0",
            "2,1,15.6,0"
        };

        int totalNotificacoes = int.Parse(dados[0]);
        double[][] notificacoes = ConverterNotificacoes(dados, totalNotificacoes);
        double[][] novo_livro_ofertas = ProcessarNotificacoes(notificacoes);
        PrintLivroOfertas(novo_livro_ofertas);
    }
    static double[][] ConverterNotificacoes(string[] dados, int totalNotificacoes)
    {
        double[][] notificacoes = new double[totalNotificacoes][];
        for (int i = 0; i < totalNotificacoes; i++)
        {
            string[] partes = dados[i + 1].Split(',');
            int posicao = int.Parse(partes[0]);
            int acao = int.Parse(partes[1]);
            double valor = double.Parse(partes[2].Replace('.', ','));
            int quantidade = int.Parse(partes[3]);
            notificacoes[i] = new double[] { posicao, acao, valor, quantidade };
        }
        return notificacoes;
    }
    static double[][] ProcessarNotificacoes(double[][] notificacoes)
    {
        double[][] livro_ofertas = new double[notificacoes.Length][];
        int quantidade_de_ofertas = 0;

        foreach (var notificacao in notificacoes)
        {
            int posicao = (int)notificacao[0];
            int acao = (int)notificacao[1];
            double valor = notificacao[2];
            int quantidade = (int)notificacao[3];

            if (acao == 0)
            {
                livro_ofertas[quantidade_de_ofertas++] = new double[] { posicao, valor, quantidade };
            }
            else if (acao == 1)
            {
                for (int i = 0; i < quantidade_de_ofertas; i++)
                {
                    if (livro_ofertas[i][0] == posicao)
                    {
                        livro_ofertas[i][1] = valor;
                        livro_ofertas[i][2] = quantidade;
                    }
                }
            }
            else if (acao == 2)
            {
                int posicao_delete = -1;
                for (int i = 0; i < quantidade_de_ofertas; i++)
                {
                    if (livro_ofertas[i][0] == posicao)
                    {
                        posicao_delete = i;
                        break;
                    }
                }
                if (posicao_delete != -1)
                {
                    for (int i = posicao_delete; i < quantidade_de_ofertas - 1; i++)
                    {
                        livro_ofertas[i] = livro_ofertas[i + 1];
                    }
                    quantidade_de_ofertas--;
                }
            }
        }

        double[][] resultado_final = new double[quantidade_de_ofertas][];

        for (int i = 0; i < quantidade_de_ofertas; i++)
        {
            resultado_final[i] = livro_ofertas[i];
        }

        return resultado_final;
    }
    static void PrintLivroOfertas(double[][] livro_ofertas)
    {
        foreach (var i in livro_ofertas)
        {
            string valor_string = i[1].ToString();
            string valor_ponto = valor_string.Replace(',', '.');
            Console.WriteLine($"{i[0]},{valor_ponto},{i[2]}");
        }
    }
}