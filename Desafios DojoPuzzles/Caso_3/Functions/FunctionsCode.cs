namespace Functions
{
    public static class FunctionsCode
    {
        //Funcao que transforma a string em codigo
        public static string transformCode(string frase)
        {
            if (frase.Length > 255)
            {
                return "Error: Frase superior a 255 caracteres: ";
            }

            //variavel que iremos retornar caso tudo dê certo
            string cod = "";

            //variavel booleana, se tornara True quando o caracterer da frase for encontrado na chave do dicionario
            bool valid = false;

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


            //Percorre a frase recebida
            for (var i = 0; i < frase.Length; i++)
            {

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
    }
}