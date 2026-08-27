using System.Globalization;

internal class Program {
    private static void Main(string[] args) {
        /* Exercicio Realizado                 https://dojopuzzles.com/problems/calculando-estatisticas-simples/   */
        Console.Write("Digitar a quantidade de numeros que deseja inserir: ");
        int n = int.Parse(Console.ReadLine());
        int[] numeros = new int[n];
        int soma = 0;
        for (int i = 0; i < n; i++) {
            Console.Write("Favor digitar o "+(i+1)+"° numero da seqüência de "+n+" numeros: ");
            numeros[i] = int.Parse(Console.ReadLine());
            soma += numeros[i];
        }

        Array.Sort(numeros);
        double media = soma;

        Console.WriteLine("Valor minimo: " + numeros[0]);
        Console.WriteLine("Valor máximo: " + numeros[n-1]);
        Console.WriteLine("Número de elementos na seqüência: " + n);
        Console.WriteLine("Valor médio: " + (media/n).ToString("F7",CultureInfo.InvariantCulture));

    }
}