using System;

namespace caixaeletronico
{
    public class Program
    {
        ///Menu Caixa Eletronico
        public static void Main(string[] args)
        {
            {
                Console.WriteLine(@"
     Caixa Eletronico!!
=============================   
| Menu:                     |
-----------------------------
| 1- Saque                  |
| 2- Limpar                 |
| 3- Sair                   |
|===========================|");
/// Definimos a função de cada número através do switch
                int OpçãoMenu = int.Parse(Console.ReadLine());
                switch (OpçãoMenu)
                {
                    case 1:
                        {
                            Console.WriteLine("Digite o valor desejado:");
                            DigiteValorDesejado();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        break;
                    case 3:
                        Console.WriteLine("Obrigado por utilizar o nosso caixa eletronico ");
                        break;
                    default:
                        break;
                }

            }
        }
        /// Função solicitar valor de saque
        public static string DigiteValorDesejado()
        {
            string valor = TelaSolicitarValor();
            if (int.TryParse(valor, out int valorInt))
            {
                var CaixaEletronico = new CaixaEletronico();
                CaixaEletronico.Exibir(CaixaEletronico.SepararNotas(valorInt));
            }
            return valor;
        }
        public static string TelaSolicitarValor()
        {
            string valor = Console.ReadLine();
            Console.WriteLine("");
            
            return valor;
        }
        public class Item
        {
            public int Nota { get; set; }
            public int Valor { get; set; }
            public int ValorTotal { get { return this.Nota * this.Valor; } }

            public Item(int nota, int valor)
            {
                this.Nota = nota;
                this.Valor = valor;
            }
            public Item() { }
            public override string ToString()
            {
                if (this.Nota == 0)
                    return "Valor do saque = " + this.Valor;
                else
                    return String.Format("{0:c}", this.Nota) + " = " + this.Valor + String.Format(" ==> {0:c}", this.ValorTotal);
            }
        }
        /// Listagem de notas disponiveis
        public class CaixaEletronico
        {
            private readonly List<int> NotasDisponiveis = new List<int>() { 10, 20, 50, 100 };

            public List<Item> SepararNotas(int valor)
            {
                this.Validar(valor);

                return this.Separar(valor);
            }

            /// Validagem onde a primeira diz que não pode sacar aquele valor pois não há notas disponiveis
            //Validagem onde a segunda diz que não tem nenhuma nota disponivel abaixo de 10 reais
            private void Validar(int valor)
            {
                if (this.NotasDisponiveis == null || this.NotasDisponiveis.Count() == 0)
                    throw new Exception("Nenhuma nota disponível para realizar o Saque");
                if (valor <= 10)
                    throw new Exception("O valor não pode ser menor ou igual a R$ 10,00 Reais");
            }

            private List<Item> Separar(int valor)
            {
                var notas = new List<Item>
            {
                new Item(0, valor)
            };

                foreach (var nota in this.NotasDisponiveis.OrderByDescending(x => x))
                {
                    valor = this.Add(notas, valor, nota);
                }

                if (valor > 0)
                    throw new Exception("Valor Inválido, Notas Disponíveis " + this.StrNotasDisponiveis());

                return notas;
            }

            private int Add(List<Item> notas, int valor, int nota)
            {
                int valorAdd = 0;

                if (valor >= nota)
                {
                    int divRem = valor / nota;
                    valor %= nota;
                    if (valor == 1 || valor == 3)
                    {
                        valor += nota;
                        if (divRem > 1)
                            valorAdd = divRem - 1;
                    }
                    else
                        valorAdd = divRem;
                }

                notas.Add(new Item(nota, valorAdd));
                return valor;
            }
            /// Exibi o valor sacado + a quantidade de notas

            public void Exibir(List<Item> lista)
            {
                foreach (var item in lista)
                {
                    Console.WriteLine(item.ToString() + " ");
                }

                Console.WriteLine("");
                Console.WriteLine("Quantidade de Notas = " + lista.Where(x => x.Nota != 0).Sum(p => p.Valor));
                Console.WriteLine("");
            }

            private string StrNotasDisponiveis()
            {
                string textoNotas = "";
                foreach (var item in this.NotasDisponiveis)
                {
                    textoNotas += string.Format("{0:c}", item) + ", ";
                }
                return textoNotas;
            }
        }
    }

}