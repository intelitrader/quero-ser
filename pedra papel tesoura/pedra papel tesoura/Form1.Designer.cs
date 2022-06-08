namespace pedra_papel_tesoura
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Placar = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ImgCPU = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ImgJogador = new System.Windows.Forms.PictureBox();
            this.BotaoTesoura = new System.Windows.Forms.Button();
            this.BotaoPapel = new System.Windows.Forms.Button();
            this.BotaoPedra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PlacarJogador = new System.Windows.Forms.Label();
            this.PlacarCPU = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Placar.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCPU)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgJogador)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Placar);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.BotaoTesoura);
            this.splitContainer1.Panel2.Controls.Add(this.BotaoPapel);
            this.splitContainer1.Panel2.Controls.Add(this.BotaoPedra);
            this.splitContainer1.Size = new System.Drawing.Size(936, 678);
            this.splitContainer1.SplitterDistance = 399;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // Placar
            // 
            this.Placar.Controls.Add(this.PlacarCPU);
            this.Placar.Controls.Add(this.PlacarJogador);
            this.Placar.Controls.Add(this.label2);
            this.Placar.Controls.Add(this.label1);
            this.Placar.Location = new System.Drawing.Point(321, 18);
            this.Placar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Placar.Name = "Placar";
            this.Placar.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Placar.Size = new System.Drawing.Size(292, 295);
            this.Placar.TabIndex = 2;
            this.Placar.TabStop = false;
            this.Placar.Text = "Placar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ImgCPU);
            this.groupBox2.Location = new System.Drawing.Point(621, 18);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(292, 295);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CPU";
            // 
            // ImgCPU
            // 
            this.ImgCPU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgCPU.Location = new System.Drawing.Point(0, 29);
            this.ImgCPU.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImgCPU.Name = "ImgCPU";
            this.ImgCPU.Size = new System.Drawing.Size(292, 266);
            this.ImgCPU.TabIndex = 1;
            this.ImgCPU.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ImgJogador);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(292, 295);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jogador";
            // 
            // ImgJogador
            // 
            this.ImgJogador.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImgJogador.Location = new System.Drawing.Point(0, 29);
            this.ImgJogador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImgJogador.Name = "ImgJogador";
            this.ImgJogador.Size = new System.Drawing.Size(292, 266);
            this.ImgJogador.TabIndex = 0;
            this.ImgJogador.TabStop = false;
            // 
            // BotaoTesoura
            // 
            this.BotaoTesoura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotaoTesoura.BackgroundImage")));
            this.BotaoTesoura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotaoTesoura.Dock = System.Windows.Forms.DockStyle.Left;
            this.BotaoTesoura.Location = new System.Drawing.Point(620, 0);
            this.BotaoTesoura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotaoTesoura.Name = "BotaoTesoura";
            this.BotaoTesoura.Size = new System.Drawing.Size(310, 273);
            this.BotaoTesoura.TabIndex = 2;
            this.BotaoTesoura.Text = "Tesoura";
            this.BotaoTesoura.UseVisualStyleBackColor = true;
            this.BotaoTesoura.Click += new System.EventHandler(this.BotaoTesoura_Click);
            // 
            // BotaoPapel
            // 
            this.BotaoPapel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotaoPapel.BackgroundImage")));
            this.BotaoPapel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotaoPapel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BotaoPapel.Location = new System.Drawing.Point(310, 0);
            this.BotaoPapel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotaoPapel.Name = "BotaoPapel";
            this.BotaoPapel.Size = new System.Drawing.Size(310, 273);
            this.BotaoPapel.TabIndex = 1;
            this.BotaoPapel.Text = "Papel";
            this.BotaoPapel.UseVisualStyleBackColor = true;
            this.BotaoPapel.Click += new System.EventHandler(this.BotaoPapel_Click);
            // 
            // BotaoPedra
            // 
            this.BotaoPedra.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BotaoPedra.BackgroundImage")));
            this.BotaoPedra.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BotaoPedra.Dock = System.Windows.Forms.DockStyle.Left;
            this.BotaoPedra.Location = new System.Drawing.Point(0, 0);
            this.BotaoPedra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BotaoPedra.Name = "BotaoPedra";
            this.BotaoPedra.Size = new System.Drawing.Size(310, 273);
            this.BotaoPedra.TabIndex = 0;
            this.BotaoPedra.Text = "Pedra";
            this.BotaoPedra.UseVisualStyleBackColor = true;
            this.BotaoPedra.Click += new System.EventHandler(this.BotaoPedra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jogador";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(207, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "CPU";
            // 
            // PlacarJogador
            // 
            this.PlacarJogador.AutoSize = true;
            this.PlacarJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlacarJogador.Location = new System.Drawing.Point(21, 178);
            this.PlacarJogador.Name = "PlacarJogador";
            this.PlacarJogador.Size = new System.Drawing.Size(63, 69);
            this.PlacarJogador.TabIndex = 2;
            this.PlacarJogador.Text = "0";
            // 
            // PlacarCPU
            // 
            this.PlacarCPU.AutoSize = true;
            this.PlacarCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlacarCPU.Location = new System.Drawing.Point(191, 178);
            this.PlacarCPU.Name = "PlacarCPU";
            this.PlacarCPU.Size = new System.Drawing.Size(63, 69);
            this.PlacarCPU.TabIndex = 3;
            this.PlacarCPU.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 678);
            this.Controls.Add(this.splitContainer1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Pedra Papel Tesoura";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Placar.ResumeLayout(false);
            this.Placar.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgCPU)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgJogador)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox ImgCPU;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox ImgJogador;
        private System.Windows.Forms.Button BotaoTesoura;
        private System.Windows.Forms.Button BotaoPapel;
        private System.Windows.Forms.Button BotaoPedra;
        private System.Windows.Forms.GroupBox Placar;
        private System.Windows.Forms.Label PlacarCPU;
        private System.Windows.Forms.Label PlacarJogador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

