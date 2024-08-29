using System;

namespace LivroOfertas {
    class Program {
        public static void Main(string[] args) {
            var list = "12\n" +
                       "1,0,15.4,50\n" +
                       "2,0,15.5,50\n" +
                       "2,2,0,0\n" +
                       "2,0,15.4,10\n" +
                       "3,0,15.9,30\n" +
                       "3,1,0,20\n" +
                       "4,0,16.50,200\n" +
                       "5,0,17.00,100\n" +
                       "5,0,16.59,20\n" +
                       "6,2,0,0\n" +
                       "1,2,0,0\n" +
                       "2,1,15.6,0\n";

            var listArray = list.Split('\n');

            var finalResult = "";

            var indice = 0;

            for (int i = 1; i < Convert.ToInt32(listArray[0]); i++)
            {
                var arrayAuxList = listArray[i].Split(",");
                if (arrayAuxList[1] == "0")
                {
                    finalResult += (indice + 1 ) + " " + arrayAuxList[2] + " " + arrayAuxList[3] + "\n";
                    indice++;
                }

                if (arrayAuxList[1] == "1" && Convert.ToInt32(arrayAuxList[0]) <= indice)
                {
                    indice = 0;
                    var arrayModificar = finalResult.Split("\n");
                    finalResult = "";
                    for (int j = 0; j < Convert.ToInt32(arrayModificar.Length - 1); j++)
                    {
                        var splitArray = arrayModificar[j].Split(" ");
                        if (splitArray[0] != arrayAuxList[0])
                        {
                            finalResult += indice + 1 + " " + splitArray[1] + " " + splitArray[2] + "\n";
                            indice++;
                        }

                        if (splitArray[0] == arrayAuxList[0])
                        {
                            finalResult += indice + 1 + " "  + arrayAuxList[2] + " " + arrayAuxList[3] + "\n";
                            indice++;

                        }
                    }
                }


                if (arrayAuxList[1] == "2" && Convert.ToInt32(arrayAuxList[0]) <= indice)
                {
                    indice = 0;
                    var arrayDeletar = finalResult.Split("\n");
                    finalResult = "";
                    for(int j = 0; j < Convert.ToInt32(arrayDeletar.Length - 1); j++)
                    {
                        var splitArray = arrayDeletar[j].Split(" ");
                        if(splitArray[0] != arrayAuxList[0])
                        {
                            finalResult += indice + 1 + " " + splitArray[1] + " " + splitArray[2] + "\n";
                            indice ++;
                        }
                    }
                }

            }

            Console.WriteLine(finalResult);
        }
    }
}