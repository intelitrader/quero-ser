using System.ComponentModel.Design;

internal class Program {
    private static void Main(string[] args) {

        /* https://dojopuzzles.com/problems/intervalos/ */
        Console.Write("Digite uma seqüência e varios numeros: ");
        string temp = Console.ReadLine();
        string[] sequencia = temp.Split(", ");
        int[] numeros = sequencia.Select(int.Parse).ToArray();
        Array.Sort(numeros);
        Console.Write("[" + numeros[0]);
        int comparar = numeros[0] + 1 ;
        bool acumulo = false;
        for (int i = 1; i < (numeros.Length); i++) {
            if (comparar == numeros[i]) {
                comparar++;
                acumulo = true;
            }
            else {
                if (acumulo == false)
                    Console.Write("], [" + numeros[i]);
                else {
                    Console.Write("-" + (comparar - 1) + "], [" + numeros[i]);
                    comparar = numeros[i] + 1;
                    acumulo = false;

                }
            }
        }
        Console.Write("]");

    }


    
}