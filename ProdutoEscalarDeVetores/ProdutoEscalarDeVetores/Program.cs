internal class Program {
    private static void Main(string[] args) {
        /* https://dojopuzzles.com/problems/produto-escalar-de-vetores/ */
        Console.Write("Defina o numero de termos de componentes dos vetores A e B: ");
        int n = int.Parse(Console.ReadLine());
        int[] A = new int[n];
        int[] B = new int[n];
        Random r = new Random();
        int resposta = 0;


        Console.Write("A . B = ");
        for (int i = 0; i < n; i++) {
            if (i == n - 1) {
                Console.Write("A"+(i+1) + "*B" + (i+1));
            }
            else {
                Console.Write("A" + (i+1) + "*B" + (i+1) + " + ");
            }
        }
        
        Console.Write("\n\nA . B = ");
        for (int i = 0; i < n; i++) {
            A[i] = r.Next(30);
            B[i] = r.Next(30);
            resposta += A[i] * B[i];
            if (i == n-1) {
                Console.Write(A[i] + "*" + B[i]);
                Console.WriteLine("\nA . B = "+resposta);
            }
            else {
                Console.Write(A[i] + "*" + B[i] + " + ");
            }
        }
    }
}