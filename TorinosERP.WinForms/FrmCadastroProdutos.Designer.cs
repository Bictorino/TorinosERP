namespace TorinosERP.WinForms
{
    partial class FrmCadastroProdutos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroProdutos));
            dgvProdutos = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnNome = new DataGridViewTextBoxColumn();
            clnDescricao = new DataGridViewTextBoxColumn();
            clnPreco = new DataGridViewTextBoxColumn();
            clnEstoque = new DataGridViewTextBoxColumn();
            txtNome = new TextBox();
            lblProduto = new Label();
            btnNovo = new Button();
            btnRemover = new Button();
            btnSalvar = new Button();
            lblDescricao = new Label();
            txtDescricao = new TextBox();
            nudPreco = new NumericUpDown();
            lblPreco = new Label();
            lblEstoque = new Label();
            nudEstoque = new NumericUpDown();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).BeginInit();
            SuspendLayout();
            // 
            // dgvProdutos
            // 
            dgvProdutos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProdutos.Columns.AddRange(new DataGridViewColumn[] { clnId, clnNome, clnDescricao, clnPreco, clnEstoque });
            dgvProdutos.Location = new Point(12, 205);
            dgvProdutos.Name = "dgvProdutos";
            dgvProdutos.Size = new Size(773, 341);
            dgvProdutos.TabIndex = 8;
            dgvProdutos.RowEnter += dgvProdutos_RowEnter;
            // 
            // clnId
            // 
            clnId.DataPropertyName = "Id";
            clnId.HeaderText = "Id";
            clnId.Name = "clnId";
            clnId.Visible = false;
            // 
            // clnNome
            // 
            clnNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clnNome.DataPropertyName = "Nome";
            clnNome.HeaderText = "Nome";
            clnNome.Name = "clnNome";
            // 
            // clnDescricao
            // 
            clnDescricao.DataPropertyName = "Descricao";
            clnDescricao.HeaderText = "Descrição";
            clnDescricao.Name = "clnDescricao";
            clnDescricao.Width = 200;
            // 
            // clnPreco
            // 
            clnPreco.DataPropertyName = "Preco";
            clnPreco.HeaderText = "Preço";
            clnPreco.Name = "clnPreco";
            clnPreco.Width = 120;
            // 
            // clnEstoque
            // 
            clnEstoque.DataPropertyName = "Estoque";
            clnEstoque.HeaderText = "Qtd. Estoque";
            clnEstoque.Name = "clnEstoque";
            clnEstoque.Width = 120;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 152);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(171, 23);
            txtNome.TabIndex = 1;
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Location = new Point(12, 134);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(50, 15);
            lblProduto.TabIndex = 2;
            lblProduto.Text = "Produto";
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovo.BackColor = SystemColors.Window;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Image = Properties.Resources.new_label_32dp_204058__1_;
            btnNovo.Location = new Point(581, 24);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(64, 62);
            btnNovo.TabIndex = 5;
            btnNovo.Text = "Novo";
            btnNovo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += BtnNovo_Click;
            // 
            // btnRemover
            // 
            btnRemover.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemover.BackColor = SystemColors.Window;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Image = Properties.Resources.clear_32dp_204058;
            btnRemover.Location = new Point(721, 24);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(64, 62);
            btnRemover.TabIndex = 7;
            btnRemover.Text = "Remover";
            btnRemover.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += BtnRemover_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvar.BackColor = SystemColors.Window;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Image = Properties.Resources.save_32dp_204058;
            btnSalvar.Location = new Point(651, 24);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(64, 62);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += BtnSalvar_Click;
            // 
            // lblDescricao
            // 
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(189, 134);
            lblDescricao.Name = "lblDescricao";
            lblDescricao.Size = new Size(58, 15);
            lblDescricao.TabIndex = 7;
            lblDescricao.Text = "Descrição";
            // 
            // txtDescricao
            // 
            txtDescricao.Location = new Point(189, 152);
            txtDescricao.Name = "txtDescricao";
            txtDescricao.Size = new Size(171, 23);
            txtDescricao.TabIndex = 2;
            // 
            // nudPreco
            // 
            nudPreco.DecimalPlaces = 2;
            nudPreco.Location = new Point(366, 152);
            nudPreco.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPreco.Name = "nudPreco";
            nudPreco.Size = new Size(120, 23);
            nudPreco.TabIndex = 3;
            // 
            // lblPreco
            // 
            lblPreco.AutoSize = true;
            lblPreco.Location = new Point(366, 134);
            lblPreco.Name = "lblPreco";
            lblPreco.Size = new Size(37, 15);
            lblPreco.TabIndex = 9;
            lblPreco.Text = "Preço";
            // 
            // lblEstoque
            // 
            lblEstoque.AutoSize = true;
            lblEstoque.Location = new Point(492, 134);
            lblEstoque.Name = "lblEstoque";
            lblEstoque.Size = new Size(75, 15);
            lblEstoque.TabIndex = 11;
            lblEstoque.Text = "Qtd. Estoque";
            // 
            // nudEstoque
            // 
            nudEstoque.Location = new Point(492, 152);
            nudEstoque.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudEstoque.Name = "nudEstoque";
            nudEstoque.Size = new Size(120, 23);
            nudEstoque.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Tahoma", 16F);
            lblStatus.Location = new Point(12, 49);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(474, 27);
            lblStatus.TabIndex = 12;
            lblStatus.Text = "Status";
            // 
            // FrmCadastroProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 558);
            Controls.Add(lblStatus);
            Controls.Add(lblEstoque);
            Controls.Add(nudEstoque);
            Controls.Add(lblPreco);
            Controls.Add(nudPreco);
            Controls.Add(lblDescricao);
            Controls.Add(txtDescricao);
            Controls.Add(btnSalvar);
            Controls.Add(btnRemover);
            Controls.Add(btnNovo);
            Controls.Add(lblProduto);
            Controls.Add(txtNome);
            Controls.Add(dgvProdutos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCadastroProdutos";
            Text = "Cadastro de Produtos";
            Load += FrmCadastroProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProdutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPreco).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudEstoque).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvProdutos;
        private TextBox txtNome;
        private Label lblProduto;
        private Button btnNovo;
        private Button btnRemover;
        private Button btnSalvar;
        private Label lblDescricao;
        private TextBox txtDescricao;
        private NumericUpDown nudPreco;
        private Label lblPreco;
        private Label lblEstoque;
        private NumericUpDown nudEstoque;
        private Label lblStatus;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnNome;
        private DataGridViewTextBoxColumn clnDescricao;
        private DataGridViewTextBoxColumn clnPreco;
        private DataGridViewTextBoxColumn clnEstoque;
    }
}