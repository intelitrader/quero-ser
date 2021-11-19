namespace Functions
{
    public static class ReadFromFile
    {
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


        public static string expression(string line)
        {
            //string frase = new Frase();
            string phrase = "";

            for (var i = 0; i < line.Length; i++)
            {
                string n = transfomValues(line[i].ToString());
        
                if (n == "ERROR")
                {
                    return "Expressão incorreta, uma expressão deve ser composta por letras maiúsculas (A-Z), hifens (-) e os números 1 e 0.";
                }
                else
                {
                    //frase.fraseCompleta(n)
                    phrase += n;
                }

            }

            //return frase.frase
            return phrase;
        }

        public static void file(string[] lines)
        {
            foreach (string line in lines)
            {
                if (line != "")
                {
                    Console.WriteLine("Expressão: " + line);
                    if (line.Length > 30)
                    {
                        Console.WriteLine("Saida: Expressão incorreta, cada expressão deve ter até 30 caracteres \n");
                    }
                    else
                    {
                        Console.WriteLine("Saida: " + expression(line) + '\n');
                    }
                }
            }
        }
    }
}