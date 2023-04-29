//Caixa eletronico
public class CaixaEletronico
{
    static void Main(string[] args)
    {
        
    }
    public void CalcularTroco()
    {
        int[] notas = { 100, 50, 20, 10 };


        Console.Write("Digite o valor do saque: R$ ");
        int valorSaque = int.Parse(Console.ReadLine());

        Console.WriteLine("Entregar troco:");

        for (int i = 0; i < notas.Length; i++)
        {
            int quantidadeNotas = valorSaque / notas[i];
            if (quantidadeNotas > 0)
            {
                Console.WriteLine("{0} nota(s) de R$ {1},00", quantidadeNotas, notas[i]);
                valorSaque %= notas[i];
            }
        }
    }
}

