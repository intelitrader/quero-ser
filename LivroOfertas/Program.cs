using System;

namespace LivroOfertas
{
    class Program
    {
        public static void Main(string[] args)
        {
            string list = @"12
                        1,0,15.4,50
                        2,0,15.5,50
                        2,2,0,0
                        2,0,15.4,10
                        3,0,15.9,30
                        3,1,0,20
                        4,0,16.50,200
                        5,0,17.00,100
                        5,0,16.59,20
                        6,2,0,0
                        1,2,0,0
                        2,1,15.6,20";

        //    string list = @"12
        //                 1,0,15.4,50
        //                 2,0,15.5,50
        //                 2,2,0,0
        //                 2,0,15.4,10
        //                 3,0,15.9,30
        //                 3,1,0,20
        //                 4,0,16.50,200
        //                 5,0,17.00,100
        //                 5,0,16.59,20
        //                 6,2,0,0
        //                 1,2,0,0
        //                 2,1,15.6,0";  // essa linha for alterada para 2,1,15.6,20 conforme
        //                 // o exemplo que não esta comentado, pois a quantidade final é 20 e não zero.                

        string[] listMod = list.Split(new[] { "\n" }, StringSplitOptions.None);
        string finalResult = string.Empty;
        int indice = 1;

        for (int i = 1; i <= int.Parse(listMod[0]); i++)
        {
            string[] arrayAuxList = listMod[i].Split(",");

            if (arrayAuxList[1] == "0")
            {
                if (int.Parse(arrayAuxList[0]) < indice)
                {
                    indice = 1;
                    string[] arrayModificar = finalResult.Split(new[] { "\n" }, StringSplitOptions.None);
                    finalResult = string.Empty;

                    for (int j = 0; j < arrayModificar.Length - 1; j++)
                    {
                        string[] splitArray = arrayModificar[j].Split(",");
                        if (int.Parse(splitArray[0]) != int.Parse(arrayAuxList[0]))
                        {
                            finalResult += $"{indice},{splitArray[1]},{splitArray[2]}\n";
                            indice++;
                        }
                        if (int.Parse(splitArray[0]) == int.Parse(arrayAuxList[0]))
                        {
                            finalResult += $"{indice},{arrayAuxList[2]},{arrayAuxList[3]}\n";
                            indice++;
                            finalResult += $"{indice},{splitArray[1]},{splitArray[2]}\n";
                            indice++;
                        }
                    }
                }
                else
                {
                    finalResult += $"{indice},{arrayAuxList[2]},{arrayAuxList[3]}\n";
                    indice++;
                }
            }

            if (arrayAuxList[1] == "1")
            {
                indice = 1;
                string[] arrayModificar = finalResult.Split(new[] { "\n" }, StringSplitOptions.None);
                finalResult = string.Empty;

                for (int j = 0; j < arrayModificar.Length - 1; j++)
                {
                    string[] splitArray = arrayModificar[j].Split(",");
                    if (int.Parse(splitArray[0]) != int.Parse(arrayAuxList[0]))
                    {
                        finalResult += $"{indice},{splitArray[1]},{splitArray[2]}\n";
                        indice++;
                    }
                    if (int.Parse(splitArray[0]) == int.Parse(arrayAuxList[0]))
                    {
                        finalResult += $"{indice},{arrayAuxList[2]},{arrayAuxList[3]}\n";
                        indice++;
                    }
                }
            }

            if (arrayAuxList[1] == "2")
            {
                indice = 1;
                string[] arrayDeletar = finalResult.Split(new[] { "\n" }, StringSplitOptions.None);
                finalResult = string.Empty;

                for (int j = 0; j < arrayDeletar.Length - 1; j++)
                {
                    string[] splitArray = arrayDeletar[j].Split(",");
                    if (int.Parse(splitArray[0]) != int.Parse(arrayAuxList[0]))
                    {
                        finalResult += $"{indice},{splitArray[1]},{splitArray[2]}\n";
                        indice++;
                    }
                }
            }
        }
        Console.WriteLine(finalResult);
        }

    }
}
