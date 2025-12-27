namespace TorinosERP.WinForms
{
    partial class FrmMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            toolstripMenu = new ToolStrip();
            toolstripVenda = new ToolStripButton();
            toolStripCadastroClientes = new ToolStripButton();
            toolStripCadastroProdutos = new ToolStripButton();
            toolStripRelatorios = new ToolStripButton();
            pictureFundo = new PictureBox();
            toolstripMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFundo).BeginInit();
            SuspendLayout();
            // 
            // toolstripMenu
            // 
            toolstripMenu.AutoSize = false;
            toolstripMenu.Items.AddRange(new ToolStripItem[] { toolstripVenda, toolStripCadastroClientes, toolStripCadastroProdutos, toolStripRelatorios });
            toolstripMenu.Location = new Point(0, 0);
            toolstripMenu.Name = "toolstripMenu";
            toolstripMenu.Size = new Size(1008, 68);
            toolstripMenu.TabIndex = 0;
            toolstripMenu.Text = "toolStrip1";
            // 
            // toolstripVenda
            // 
            toolstripVenda.Image = (Image)resources.GetObject("toolstripVenda.Image");
            toolstripVenda.ImageScaling = ToolStripItemImageScaling.None;
            toolstripVenda.ImageTransparentColor = Color.Magenta;
            toolstripVenda.Name = "toolstripVenda";
            toolstripVenda.Size = new Size(48, 65);
            toolstripVenda.Text = "Vendas";
            toolstripVenda.TextImageRelation = TextImageRelation.ImageAboveText;
            toolstripVenda.Click += toolstripVenda_Click;
            // 
            // toolStripCadastroClientes
            // 
            toolStripCadastroClientes.Image = (Image)resources.GetObject("toolStripCadastroClientes.Image");
            toolStripCadastroClientes.ImageScaling = ToolStripItemImageScaling.None;
            toolStripCadastroClientes.ImageTransparentColor = Color.Magenta;
            toolStripCadastroClientes.Name = "toolStripCadastroClientes";
            toolStripCadastroClientes.Size = new Size(53, 65);
            toolStripCadastroClientes.Text = "Clientes";
            toolStripCadastroClientes.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripCadastroClientes.Click += toolStripCadastroClientes_Click;
            // 
            // toolStripCadastroProdutos
            // 
            toolStripCadastroProdutos.Image = (Image)resources.GetObject("toolStripCadastroProdutos.Image");
            toolStripCadastroProdutos.ImageScaling = ToolStripItemImageScaling.None;
            toolStripCadastroProdutos.ImageTransparentColor = Color.Magenta;
            toolStripCadastroProdutos.Name = "toolStripCadastroProdutos";
            toolStripCadastroProdutos.Size = new Size(59, 65);
            toolStripCadastroProdutos.Text = "Produtos";
            toolStripCadastroProdutos.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripCadastroProdutos.Click += toolStripCadastroProdutos_Click;
            // 
            // toolStripRelatorios
            // 
            toolStripRelatorios.Image = (Image)resources.GetObject("toolStripRelatorios.Image");
            toolStripRelatorios.ImageScaling = ToolStripItemImageScaling.None;
            toolStripRelatorios.ImageTransparentColor = Color.Magenta;
            toolStripRelatorios.Name = "toolStripRelatorios";
            toolStripRelatorios.Size = new Size(63, 65);
            toolStripRelatorios.Text = "Relatórios";
            toolStripRelatorios.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripRelatorios.Click += toolStripRelatorios_Click;
            // 
            // pictureFundo
            // 
            pictureFundo.Dock = DockStyle.Fill;
            pictureFundo.Image = Properties.Resources.ImagemFundo;
            pictureFundo.Location = new Point(0, 68);
            pictureFundo.MaximumSize = new Size(1008, 661);
            pictureFundo.Name = "pictureFundo";
            pictureFundo.Size = new Size(1008, 661);
            pictureFundo.TabIndex = 1;
            pictureFundo.TabStop = false;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1008, 729);
            Controls.Add(pictureFundo);
            Controls.Add(toolstripMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmMenu";
            Text = "Torinos ERP";
            toolstripMenu.ResumeLayout(false);
            toolstripMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureFundo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ToolStrip toolstripMenu;
        private ToolStripButton toolStripCadastroClientes;
        private PictureBox pictureFundo;
        private ToolStripButton toolstripVenda;
        private ToolStripButton toolStripCadastroProdutos;
        private ToolStripButton toolStripRelatorios;
    }
}
