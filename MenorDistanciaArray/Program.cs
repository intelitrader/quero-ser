using System;

namespace MenorDistanciaArray {
    class Program {
        public static void Main(string[] args) {
            //int[] array1 = {-1, 5};
            //int[] array2 = {26, 6};

            //int[] array1 = {1, 2, 3, 5, 7,-1,-8,5,-4,-9};
            //int[] array2 = {10, 20, 30, 40, 26,6,-12,45,99,100};

            int[] array1 = {1, 2, 3, 5, 7,-1,-8,10,-4,-9};
            int[] array2 = {99, 100, 101, 102, 103,104,105,106,107,108};

            var resultAux = array1[0] - array2[0];

            if(resultAux < 0)
            {
                resultAux *= -1;
            }

            var menorDistancia = resultAux;

            for (var i = 0; i < array1.Length; i++) {
                for (var j = 0; j < array2.Length; j++) {
                    var result = array1[i] - array2[j];
                    if(result < 0){
                        result *= -1;
                    }
                    if(result < menorDistancia){
                        menorDistancia = result;
                    }
                }
            }

            Console.WriteLine(menorDistancia);
        }
    }
}