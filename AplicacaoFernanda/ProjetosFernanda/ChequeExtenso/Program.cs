// See https://aka.ms/new-console-template for more information
//Cheque por extenso
public class ChequeExtenso
{
    static void Main(string[] args) { }

    public void TransformarPorExtenso()
    {

        Console.WriteLine("Digite o valor monetário do cheque:");
        double valor = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine(ValorExtenso(valor));
    }

    static string ValorExtenso(double valor)
    {
        string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        string[] dezenas = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        string[] centenas = { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        int parteInt = (int)Math.Floor(valor);
        int parteDec = (int)Math.Round((valor - parteInt) * 100);

        string porExtenso = "";

        if (parteInt == 0)
        {
            porExtenso = "zero";
        }
        else if (parteInt == 1)
        {
            porExtenso = "um real";
        }
        else
        {
            porExtenso = PorExtenso(parteInt) + " reais";
        }

        if (parteDec > 0)
        {
            if (parteInt > 0)
            {
                porExtenso += " e ";
            }
            if (parteDec == 1)
            {
                porExtenso += "um centavo";
            }
            else
            {
                porExtenso += PorExtenso(parteDec) + " centavos";
            }
        }

        return porExtenso;
    }

    private static string PorExtenso(int valor)
    {
        string[] unidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        string[] dezenas = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
        string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

        string porExtenso = "";

        if (valor >= 1000)
        {
            porExtenso += PorExtenso(valor / 1000) + " mil ";
            valor %= 1000;
        }

        if (valor >= 100)
        {
            porExtenso += centenas[valor / 100] + " ";
            valor %= 100;
        }
        if (valor >= 20)
        {
            porExtenso += dezenas[valor / 10] + " ";
            valor %= 10;
        }

        if (valor >= 10)
        {
            porExtenso += unidades[valor] + " ";
        }
        else if (valor >= 1)
        {
            porExtenso += dezenas[valor / 10] + " ";
            valor %= 10;
            if (valor > 0)
            {
                porExtenso += "e " + unidades[valor] + " ";
            }
        }

        return porExtenso;
    }
}



















