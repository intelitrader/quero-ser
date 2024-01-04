using System.Globalization;

internal class Program {
    private static void Main(string[] args) {

        /* Exercicio realizado: https://dojopuzzles.com/problems/troco/ */
        Console.Write("Digite o valor para saber as moedas necessarias: R$ ");
        double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
        bool validacao = true;
        int notas = 0;
        double[] notas_cadastradas = { 100, 50, 10, 5, 1, 0.50, 0.10, 0.05, 0.01 };

        while (validacao == true) {
            for (int i = 0; i < notas_cadastradas.Length; i++) {
                while (valor >= notas_cadastradas[i]) {
                    if (valor >= notas_cadastradas[i]) {
                        valor -= notas_cadastradas[i];
                        notas++;
                    }
                }
                if (notas != 0) {
                    Console.WriteLine("Valor de R$ " + notas_cadastradas[i].ToString("F2", CultureInfo.InvariantCulture) + ": " + notas + " unidade(s)");
                    notas = 0;
                }
            }
            validacao = false;
        }
    }
}