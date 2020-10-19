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

namespace FatorPrimo
{
    public partial class frmFatores : Form
    {
        public frmFatores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int numero = Convert.ToInt32(textBox1.Text);

            int contador = Calculo.GetFatoresPrimos(numero, out int[] arrResultado);            

            for (int i = 0; i < contador; i++)
            {
                listBox1.Items.Add(arrResultado[i]);
                if (i != contador - 1)
                {
                    int teste1 = arrResultado[i];

                    listBox1.Items.Add("------");
                    //listBox1.Items.Add(teste1).ToString("{0}");
                    listBox1.Items.Add(string.Format("{0} {1}", arrResultado[i], "x"));
                }
            }
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
            pictureBox2.Location = new Point(63, 24);
            pictureBox2.Image = Properties.Resources.rubrica;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
