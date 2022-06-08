using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pedra_papel_tesoura
{
    public partial class Form1 : Form
    {
        enum Opcoes { pedra, papel, tesoura};
        enum Resultado { venceu, perdeu, empatou};
        Opcoes jogador = new Opcoes();
        Opcoes cpu = new Opcoes();
        Random random = new Random();
        Resultado ganhador = new Resultado();
        public Form1()
        {
            InitializeComponent();
        }

        // criacao dos metodos para interacao com os botoes
        private void BotaoPedra_Click(object sender, EventArgs e)
        {
            jogador = Opcoes.pedra;
            VezJogador();
            VezCPU();
            VerificarGanhador();
        }

        private void BotaoPapel_Click(object sender, EventArgs e)
        {
            jogador = Opcoes.papel;
            VezJogador();
            VezCPU();
            VerificarGanhador();
        }

        private void BotaoTesoura_Click(object sender, EventArgs e)
        {
            jogador = Opcoes.tesoura;
            VezJogador();
            VezCPU();
            VerificarGanhador();
        }

        // criada a interaçao da escolha tanto do jogador quanto da cpu
        void VezJogador()
        {
            switch (jogador)
            {
                case Opcoes.pedra:
                    ImgJogador.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Pedra.jpg");
                    break;
                case Opcoes.papel:
                    ImgJogador.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Papel.gif");
                    break;
                case Opcoes.tesoura:
                    ImgJogador.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Tesoura.jpg");
                    break;
            } 
        }

        void VezCPU()
        {
            int numero = random.Next(1, 4);

            if (numero == 1)
            {
                cpu = Opcoes.pedra;
                ImgCPU.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Pedra.jpg");
            }
            else if (numero == 2)
            {
                cpu = Opcoes.papel;
                ImgCPU.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Papel.gif");
            }
            else if (numero == 3)
            {
                cpu = Opcoes.tesoura;
                ImgCPU.BackgroundImage = Image.FromFile("C:/Users/Jhonathan/Desktop/Projetos C#/imagens/Tesoura.jpg");
            }
        }

        //realizada a logica do jogo
        void VerificarGanhador()
        {
            switch (jogador)
            {
                case Opcoes.pedra:
                    if (cpu == Opcoes.pedra)
                        ganhador = Resultado.empatou;
                    else if (cpu == Opcoes.papel)
                        ganhador = Resultado.perdeu;
                    else if (cpu == Opcoes.tesoura)
                        ganhador = Resultado.venceu;
                    break;

                case Opcoes.papel:
                    if (cpu == Opcoes.pedra)
                        ganhador = Resultado.venceu;
                    else if (cpu == Opcoes.papel)
                        ganhador = Resultado.empatou;
                    else if (cpu == Opcoes.tesoura)
                        ganhador = Resultado.perdeu;
                    break;

                case Opcoes.tesoura:
                    if (cpu == Opcoes.pedra)
                        ganhador = Resultado.perdeu;
                    else if (cpu == Opcoes.papel)
                        ganhador = Resultado.venceu;
                    else if (cpu == Opcoes.tesoura)
                        ganhador = Resultado.empatou;
                    break;
            }

            if (ganhador == Resultado.venceu)
            {
                Placar.BackColor = Color.Green;
                PlacarJogador.Text = (int.Parse(PlacarJogador.Text) + 1).ToString();
            }
            else if (ganhador == Resultado.perdeu)
            {
                Placar.BackColor = Color.Red;
                PlacarCPU.Text = (int.Parse(PlacarCPU.Text) + 1).ToString();
            }
            else
            {
                Placar.BackColor = Color.White;
            }
        }
    }
}
