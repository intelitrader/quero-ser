
using System;
using System.Collections.Generic;
using System.Linq;

namespace Caso3
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Dictionary<string, string> dic1 = new Dictionary<string, string>()
            {
                { "ABC",  "2" },
                { "DEF", "3" },
                { "GHI", "4" },
                { "JKL", "5" },
                { "MNO", "6" },
                { "PQRS", "7" },
                { "TUV", "8" },
                { "WXYZ", "9" },
                { " ", "0" }
            };

            string frase = "SEMPRE ACESSO O DOJOPUZZLES";
            string cod = "";

            for (var i = 0; i < frase.Length; i++)
            {
                foreach (var item in dic1)
                {
                    if ((item.Key).Contains(frase[i]))
                    {
                        int ind = (item.Key).IndexOf(frase[i]);

                        if (cod != "")
                        {

                            if(cod[cod.Length - 1].ToString() == item.Value)
                            {
                                cod = cod + "_" + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                            }
                            else
                            {
                                cod = cod + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                            }
                        }
                        else
                        {
                            cod = cod + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                        }
                    }
                }
            }

            Console.WriteLine(cod);
        }
    }
}
