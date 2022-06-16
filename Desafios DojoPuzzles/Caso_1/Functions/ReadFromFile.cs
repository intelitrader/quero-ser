namespace Functions
{
    public static class ReadFromFile
    {   
        //Recebe a letra e retorna o valor numerico(em string) correspondente
        public static string transfomValues(string letter)
        {
            if (letter == "A" || letter == "B" || letter == "C")
            {
                return "2";
            }
            if (letter == "D" || letter == "E" || letter == "F")
            {
                return "3";
            }
            if (letter == "G" || letter == "H" || letter == "I")
            {
                return "4";
            }
            if (letter == "J" || letter == "K" || letter == "L")
            {
                return "5";
            }
            if (letter == "M" || letter == "N" || letter == "O")
            {
                return "6";
            }
            if (letter == "P" || letter == "Q" || letter == "R" || letter == "S")
            {
                return "7";
            }
            if (letter == "T" || letter == "U" || letter == "V")
            {
                return "8";
            }
            if (letter == "W" || letter == "X" || letter == "Y" || letter == "Z")
            {
                return "9";
            }
            if (letter == "1" || letter == "0" || letter == "-" || letter == " ")
            {
                return letter;
            }
            else
            {
                return "ERROR";
            }
        }

        /*
         * Recebe a expressao e verifica cada caracterer na funcao anterior
         * para transformar no codigo correspondente
         */
        public static string expression(string line)
        {
            //inicio a variavel que vai retornar como vazia
            string phrase = "";

            //percorre a string recebida pegando cada letra
            for (var i = 0; i < line.Length; i++)
            {
                /*
                 * passa o caracter da linha como string para o metodo de transformar valores
                 */
                string n = transfomValues(line[i].ToString());

                //Verifica o retorno do método anterior
                if (n == "ERROR")
                {
                    return "Expressão incorreta, uma expressão deve ser composta por letras maiúsculas (A-Z), hifens (-) e os números 1 e 0.";
                }
                else
                {
                    phrase += n;
                }

            }
            return phrase;
        }

        /*
         * Recebe as linhas do arquivo lido
         */
        public static void file(string[] lines)
        {
            foreach (string line in lines)
            {
                //Caso a linha nao esteja vazia
                if (line != "")
                {
                    Console.WriteLine("Expressão: " + line);

                    //Vefica o tamanho(Max 30 caracterer no desafio)
                    if (line.Length > 30)
                    {
                        Console.WriteLine("Saida: Expressão incorreta, cada expressão deve ter até 30 caracteres \n");
                    }
                    //Se tamanho <=30 chama o metodo anterior passando a linha como parametro
                    else
                    {
                        Console.WriteLine("Saida: " + expression(line) + '\n');
                    }
                }
            }
        }
    }
}