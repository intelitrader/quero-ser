using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace Desafio01
{
    [Serializable]
    public class Data
    {
        private Arvore arvore;
        private List<byte> listBytes;
        private int qtdBits;

        public Data(Arvore a, String dado)
        {
            listBytes = new List<byte>();
            arvore = a;
            qtdBits = 0;
            String dadosEmBits = LetrasParaBits(dado);
            Compacta(dadosEmBits);
        }

        //Transforma uma String de letras em uma String de bits baseado na tabela
        public String LetrasParaBits(String dado)
        {
            String dadosBits = "";
            foreach (char c in dado)
            {
                dadosBits += this.arvore.HashCaminhos[c];
            }
            return dadosBits;
        }

        //Transforma cada 8 caracteresyt(bits) em um numero de 1 byte
        public void Compacta(String s)
        {
            String aux;
            byte b;
            int tamanho = s.Length;
            if (tamanho < 8)
            {
                qtdBits--;
                Compacta(s + '0');
            }
            else
            {
                qtdBits += 8;
                aux = s.Substring(0, 8);
                int inteiro = ToInt(aux);
                b = (byte)inteiro;
                listBytes.Add(b);
                if (tamanho == 8)
                {
                    return;
                }
                aux = s.Substring(8, tamanho - 8);
                Compacta(aux);
            }
        }

        //Pega o atributo listaBytes(Dado compactato) e descompacta ele utilizando a arvore
        //retorna uma String com o texto equivalente ao compactado
        public String Descompacta()
        {
            String bits = "";
            String frase = "";
            foreach (byte b in listBytes)
            {
                bits += ToStr((int)b);
            }
            Node root = this.arvore.Nodes[0];
            Node node;
            int i = 0;
            while (i < qtdBits)
            {
                node = root;
                while (node.NoDireita != null && node.NoEsquerda != null)
                {
                    if (bits.Substring(i, 1) == "1")
                    {
                        node = node.NoDireita;
                    }
                    else
                    {
                        node = node.NoEsquerda;
                    }
                    i++;
                }
                frase += node.Caracter;
            }
            return frase;
        }

        //Retorna o valor de uma sequencia de 8 bits em um int
        public int ToInt(String s)
        {
            int p1, p2, p3, p4, p5, p6, p7, p8, total;
            p1 = Convert.ToInt32(s.Substring(0, 1));
            p2 = Convert.ToInt32(s.Substring(1, 1));
            p3 = Convert.ToInt32(s.Substring(2, 1));
            p4 = Convert.ToInt32(s.Substring(3, 1));
            p5 = Convert.ToInt32(s.Substring(4, 1));
            p6 = Convert.ToInt32(s.Substring(5, 1));
            p7 = Convert.ToInt32(s.Substring(6, 1));	
            p8 = Convert.ToInt32(s.Substring(7, 1));

            total = p8 * 1 + p7 * 2 + p6 * 4 + p5 * 8 + p4 * 16 + p3 * 32 + p2 * 64 + p1 * 128;

            return total;
        }
        //Retorna o valor de um int em uma sequencia de 8 bits
        public String ToStr(int n)
        {
            String s;
            if (n >= 128)
            {
                n -= 128;
                s = "1";
            }
            else
            {
                s = "0";
            }
            if (n >= 64)
            {
                n -= 64;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 32)
            {
                n -= 32;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 16)
            {
                n -= 16;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 8)
            {
                n -= 8;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 4)
            {
                n -= 4;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 2)
            {
                n -= 2;
                s += "1";
            }
            else
            {
                s += "0";
            }
            if (n >= 1)
            {
                n -= 1;
                s += "1";
            }
            else
            {
                s += "0";
            }
            return s;
        }
    }
}