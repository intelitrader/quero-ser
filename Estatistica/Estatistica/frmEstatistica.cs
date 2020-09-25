using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estatistica
{
    public partial class frmEstatistica : Form
    {
        public frmEstatistica()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/Apocryphoon");
            Process.Start(sInfo);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox2.ClientSize = new Size(163, 90);
            pictureBox2.Location = new Point(63,24);
            pictureBox2.Image = Properties.Resources.rubrica;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                //Cria um array, pega os valores do campo, tira o espaço e quebra linha na "," e adiciona ao array
                string[] numerosString = textBox1.Text.Replace(" ", "").Split(',');
                //Cria uma lista "numeros"
                List<double> numeros = new List<double>();

                //Roda os valores que estão no array para dentro da variavel "numero"
                foreach (var numero in numerosString)
                {
                    //Adiciona a lista os valores que estão dentro de numero
                    numeros.Add(Convert.ToDouble(numero));
                }

                //Adiciono a cada variavel seu respectivo valor
                int ArrayValor = numerosString.Length;
                double maior = numeros.Max();
                double menor = numeros.Min();
                double media = numeros.Average();

                //Mostro na tela
                textBox2.Text = menor.ToString();
                textBox3.Text = maior.ToString();
                textBox4.Text = media.ToString("#.##");
                textBox5.Text = Convert.ToString(ArrayValor);
            } catch {
                MessageBox.Show("Algo inesperado aconteceu! Forma correta: 1, 2, 3, 4, 5");
            }            

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ("");
            textBox2.Text = ("");
            textBox3.Text = ("");
            textBox4.Text = ("");
            textBox5.Text = ("");
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
