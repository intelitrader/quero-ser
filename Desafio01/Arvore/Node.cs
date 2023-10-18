using System;

namespace Desafio01
{
    [Serializable]
    public class Node
    {

        //Atributos
        [NonSerialized]private int peso;
        private char caracter;

        private Node noEsquerda;
        private Node noDireita;

        public Node()
        {
        }

        //Métodos gets e sets
        public int Peso
        {
            get
            {
                return this.peso;
            }
            set
            {
                peso = value;
            }
        }

        public char Caracter
        {
            get
            {
                return this.caracter;
            }
            set
            {
                caracter = value;
            }
        }

        public Node NoEsquerda
        {
            get
            {
                return this.noEsquerda;
            }
            set
            {
                noEsquerda = value;
            }
        }

        public Node NoDireita
        {
            get
            {
                return this.noDireita;
            }
            set
            {
                noDireita = value;
            }
        }
    }
}