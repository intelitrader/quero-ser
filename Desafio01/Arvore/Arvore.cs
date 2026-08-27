using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace Desafio01
{
    [Serializable]
    public class Arvore
    {

        private List<Node> nodes;
        [NonSerialized] private Dictionary<char, String> hashCaminhos;

        public Arvore()
        {
            hashCaminhos = new Dictionary<char, String>();
        }

        //Métodos gets e sets
        public List<Node> Nodes
        {
            get
            {
                return this.nodes;
            }
            set
            {
                nodes = value;
            }
        }

        public Dictionary<char, String> HashCaminhos
        {
            get
            {
                return this.hashCaminhos;
            }
            set
            {
                hashCaminhos = value;
            }
        }

        //Este método faz a contrução da arvore binária, seus nós intermediários armazenam
        //a soma peso dos nós filhos, os nós folhas armazenam um caracter.
        public Node BuildTree(Dictionary<char, int> dict)
        {
            this.nodes = CreateNodes(dict);

            int j = 0;
            for (int i = this.nodes.Count; i > 1; i--)
            {
                Node newNode = JoinNodes(this.nodes[j], nodes[j + 1]);
                this.nodes.Remove(this.nodes[j]);
                this.nodes.Remove(this.nodes[j]);
                this.nodes.Add(newNode);
                this.nodes = SortNodes();
                j = 0;
            }

//			tree.tree = nodes;
            return nodes[0];
        }

        //Pega o dicionário de char e int e cria uma lista de nós
        public List<Node> CreateNodes(Dictionary<char, int> dict)
        {
            List<Node> nodes = new List<Node>();
            foreach (var item in dict)
            {
                Node n = new Node();
                n.Caracter = item.Key;
                n.Peso = item.Value;
                nodes.Add(n);
            }
            return nodes;
        }
        //Junta dois nós, método deve ser chamado pelo método
        public Node JoinNodes(Node nodeEsq, Node nodeDir)
        {
            //Cria um nó raiz para os dois nós
            Node newNode = new Node();

            newNode.Caracter = '\0';

            //calcula o peso para o nó raiz
            int newPeso = nodeEsq.Peso + nodeDir.Peso;

            //atribui o peso
            newNode.Peso = newPeso;

            //atribui os nós respectivamente esquerda e direita;
            newNode.NoEsquerda = nodeEsq;
            newNode.NoDireita = nodeDir;

            return newNode;
        }
        //Ordena os nós
        public List<Node> SortNodes()
        {
            return this.nodes.OrderBy(o => o.Peso).ToList();
        }
        //Imprime inOrder a arvore
        public void InOrder(Node root)
        {
            if (root != null)
            {
                InOrder(root.NoEsquerda);
                if (root.Caracter != '\0')
                {
                    if (root.Caracter == 32)
                    {
                        Console.Write("{space} ");
                    }
                    else
                    {
                        Console.Write("{0} ", root.Caracter);
                    }
                }
                InOrder(root.NoDireita);
            }
        }

        //Cria tabela que armazana a relação entre caracter e o seu caminho na arvore
        public void CriaTabela(Node n, String caminho)
        {
            if (n.NoDireita == null && n.NoEsquerda == null)
            {
                hashCaminhos.Add(n.Caracter, caminho);
                return;
            }
            else
            {
                CriaTabela(n.NoEsquerda, caminho + "0");
                CriaTabela(n.NoDireita, caminho + "1");

            }
        }
    }
}