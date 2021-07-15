using System;

namespace empresaSolucao
{
    class Produto
    {
        public Produto(string fonte)
        {
            // Quebramos cada linha em partes, pegado
            string[] dados = fonte.Split(";");
            // Converter as propriedade do Produto para inteiro em formato de array [0,1,2]
            Codigo = Convert.ToInt32(dados[0]);
            QtdEstoque = Convert.ToInt32(dados[1]);
            QtdMinima = Convert.ToInt32(dados[2]);

        }
     
        public int Codigo { get; }// Código do Produto
        public int QtdEstoque { get; set; }// Quantidade em estoque no inicio do período
        public int QtdMinima { get; set; }// Quantidade mínima em estoque que deve ser mantida no Centro Operacional
        
    }
    
    
}
