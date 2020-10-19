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

namespace JokenPow
{
    public partial class frmJoken : Form
    {
        public frmJoken()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int jogar = comboBox1.SelectedIndex;

            Random r = new Random();
            int joke = r.Next(0, 3);



            comboBox2.SelectedIndex = joke;

            if (jogar == joke)
            {

                label2.Text = "EMPATE!";

            }

            else

            {

                switch (jogar)

                {
                    case 0:

                        if (joke == 1)
                        {
                            label2.Text = " Perdeu!";
                        }
                        if (joke == 2)
                        {
                            label2.Text = "Ganhou!";
                        }
                        break;

                    case 1:

                        if (joke == 0)
                        {
                            label2.Text = "Ganhou!";
                        }
                        if (joke == 2)
                        {
                            label2.Text = "Perdeu!";
                        }
                        break;

                    case 2:

                        if (joke == 0)
                        {
                            label2.Text = "Perdeu!";
                        }
                        if (joke == 2)
                        {
                            label2.Text = "Ganhou!";
                        }
                        break;
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
    }
}
