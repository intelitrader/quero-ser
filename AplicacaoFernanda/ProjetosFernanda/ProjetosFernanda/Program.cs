// See https://aka.ms/new-console-template for more information


class Program
{
    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("=== Menu ===");
            Console.WriteLine("1. Caixa Eletronico");
            Console.WriteLine("2. Cheque Extenso");
            Console.WriteLine("3. FizzBuzz");
            Console.WriteLine("4. Sair");

            Console.Write("Digite a opção desejada: ");
            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    CaixaEletronico caixaEletronico = new CaixaEletronico();
                    caixaEletronico.CalcularTroco();
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    ChequeExtenso chequeExtenso = new ChequeExtenso();
                    chequeExtenso.TransformarPorExtenso();

                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 3:
                    FizzBuzz fizzBuzz = new FizzBuzz();
                    fizzBuzz.Classificacao();

                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 4:
                    Console.WriteLine("Programa encerrado.");

                    break;
                default:
                    Console.WriteLine("Opção inválida.");

                    Console.ReadKey();
                    Console.Clear();
                    break;
            }

            Console.WriteLine();
        } while (opcao != 4);
    }
}
