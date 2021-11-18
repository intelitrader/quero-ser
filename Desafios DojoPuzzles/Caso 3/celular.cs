

namespace Caso3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dicionario com chave(Caracteres que devem ser procurados) e valor(Sera inputado caso a string seja encontrada)
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

            //Funcao que transforma a string em codigo
            static string transformCode(string frase, string cod, Dictionary<string, string> dic1, bool valid)
            {
                //Percorre a frase recebida
                for (var i = 0; i < frase.Length; i++)
                {
                    //variavel booleana, se tornara True quando o caracterer da frase for encontrado na chave do dicionario
                    valid = false;

                    //Percorre o dicionario
                    foreach (var item in dic1)
                    {
                        //Se a chave do dicionario, contem a string da frase
                        if ((item.Key).Contains(frase[i]))
                        {
                            //valido que encontrou o caracterer dentro da chave do dicionario
                            valid = true;

                            //pega o indice da chave a qual o caracterer foi encontrado
                            int ind = (item.Key).IndexOf(frase[i]);
                            
                            //variavel que iremos retornar caso tudo dê certo
                            //verifica se é o primeiro codigo que estamos inserindo
                            if (cod != "")
                            {

                                //verifica se a ultima posicao da variavel cod
                                //é igual ao valor da chave do diciario que percorremos
                                if (cod[cod.Length - 1].ToString() == item.Value)
                                {
                                    //se sim, acrescenta a ele mesmo 
                                    //underline + o valor da chave encontrado
                                    //Enurable.Repeat(valor, quantidade de vezes)
                                    cod = cod + "_" + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                                }
                                else
                                {
                                    //se nao, nao precisa adicionar o underline
                                    cod = cod + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                                }
                            }
                            else
                            {
                                //se está verificando a primeira string da frase
                                //código como o anterior
                                cod = cod + string.Concat(Enumerable.Repeat(item.Value, ind + 1));
                            }
                        }
                    }
                    //se o caracterer da frase é encontrado no passo anterior
                    //aqui deveria ser True
                    //caso seja falso, foi digitado um caracterer invalido
                    //dessa forma pode-se implementar alguma logica diferente para outros caracteres, caso necessario.
                    if (!valid)
                    {
                        return false.ToString();
                    }

                }
                //retorno da variavel com o codigo correspondente
                return cod;
            }

            //string frase = "SEMPRE ACESSO O DOJOPUZZLES";
            Console.WriteLine("\nDigite uma frase com no maximo 255 Caracteres");
            Console.WriteLine("sem virgulas, acentos, numeros ou qualquer caracterer especial: \n");

            //recebe a frase do usuario
            string frase = Console.ReadLine().ToUpper();

            //chama a funcao que vai transformar frase em codigo
            string codigo = transformCode(frase, "", dic1, false);

            if(codigo != "False")
            {
                Console.WriteLine("\nCodigo numerico: " + codigo + "\n");
            }
            else
            {
                Console.WriteLine("Caracter invalido na frase");
            }
            
            Console.WriteLine("\n Aperte qualquer tecla para encerrar \n");
            Console.ReadLine();
        }
    }
}

