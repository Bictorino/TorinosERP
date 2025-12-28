namespace TorinosERP.WinForms
{
    partial class FrmVenda
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVenda));
            cmbCliente = new ComboBox();
            lblCliente = new Label();
            lblTotalGeral = new Label();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnEfetivar = new Button();
            lblStatus = new Label();
            lblSituacaoVenda = new Label();
            lblDataCadastro = new Label();
            btnEstornar = new Button();
            txtDataCadastro = new TextBox();
            grVendaItens = new GroupBox();
            panel1 = new Panel();
            btnNovoVendaItem = new Button();
            btnRemoverVendaItem = new Button();
            btnSalvarVendaItem = new Button();
            lblSubtotalItemVenda = new Label();
            nudSubtotalVendaItem = new NumericUpDown();
            lblPrecoUnitario = new Label();
            lblQtdProdutos = new Label();
            nudPrecoUnitarioVendaItem = new NumericUpDown();
            nudQuantidadeVendaItem = new NumericUpDown();
            cmbProdutoVendaItem = new ComboBox();
            lblProduto = new Label();
            dgvVendaItens = new DataGridView();
            clnIdVendaItem = new DataGridViewTextBoxColumn();
            clnVenda_Id = new DataGridViewTextBoxColumn();
            clnProduto_Id = new DataGridViewTextBoxColumn();
            clnProduto = new DataGridViewTextBoxColumn();
            clnQtd = new DataGridViewTextBoxColumn();
            clnPrecoUnitario = new DataGridViewTextBoxColumn();
            clnSubTotal = new DataGridViewTextBoxColumn();
            btnPesquisar = new Button();
            txtTotalGeral = new TextBox();
            grVendaItens.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSubtotalVendaItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecoUnitarioVendaItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidadeVendaItem).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVendaItens).BeginInit();
            SuspendLayout();
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(12, 177);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(305, 23);
            cmbCliente.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 159);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 1;
            lblCliente.Text = "Cliente";
            // 
            // lblTotalGeral
            // 
            lblTotalGeral.AutoSize = true;
            lblTotalGeral.Location = new Point(142, 209);
            lblTotalGeral.Name = "lblTotalGeral";
            lblTotalGeral.Size = new Size(62, 15);
            lblTotalGeral.TabIndex = 3;
            lblTotalGeral.Text = "Total Geral";
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvar.BackColor = SystemColors.Window;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Image = Properties.Resources.save_32dp_204058;
            btnSalvar.Location = new Point(721, 12);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(64, 62);
            btnSalvar.TabIndex = 17;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCancelar.BackColor = SystemColors.Window;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Image = Properties.Resources.cancel_32dp_204058;
            btnCancelar.Location = new Point(441, 12);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(64, 62);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovo.BackColor = SystemColors.Window;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Image = Properties.Resources.new_label_32dp_204058__1_;
            btnNovo.Location = new Point(651, 12);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(64, 62);
            btnNovo.TabIndex = 16;
            btnNovo.Text = "Novo";
            btnNovo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnEfetivar
            // 
            btnEfetivar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEfetivar.BackColor = SystemColors.Window;
            btnEfetivar.FlatStyle = FlatStyle.Flat;
            btnEfetivar.Image = Properties.Resources.check_32dp_204058;
            btnEfetivar.Location = new Point(581, 12);
            btnEfetivar.Name = "btnEfetivar";
            btnEfetivar.Size = new Size(64, 62);
            btnEfetivar.TabIndex = 19;
            btnEfetivar.Text = "Efetivar";
            btnEfetivar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEfetivar.UseVisualStyleBackColor = false;
            btnEfetivar.Click += btnEfetivar_Click;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 27);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(348, 27);
            lblStatus.TabIndex = 20;
            lblStatus.Text = "Status";
            // 
            // lblSituacaoVenda
            // 
            lblSituacaoVenda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSituacaoVenda.Font = new Font("Tahoma", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSituacaoVenda.Location = new Point(366, 228);
            lblSituacaoVenda.Name = "lblSituacaoVenda";
            lblSituacaoVenda.Size = new Size(416, 27);
            lblSituacaoVenda.TabIndex = 21;
            lblSituacaoVenda.Text = "Situação: ";
            // 
            // lblDataCadastro
            // 
            lblDataCadastro.AutoSize = true;
            lblDataCadastro.Location = new Point(12, 210);
            lblDataCadastro.Name = "lblDataCadastro";
            lblDataCadastro.Size = new Size(81, 15);
            lblDataCadastro.TabIndex = 23;
            lblDataCadastro.Text = "Data Cadastro";
            // 
            // btnEstornar
            // 
            btnEstornar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEstornar.BackColor = SystemColors.Window;
            btnEstornar.FlatStyle = FlatStyle.Flat;
            btnEstornar.Image = Properties.Resources.restore_32dp_204058;
            btnEstornar.Location = new Point(511, 12);
            btnEstornar.Name = "btnEstornar";
            btnEstornar.Size = new Size(64, 62);
            btnEstornar.TabIndex = 24;
            btnEstornar.Text = "Estornar";
            btnEstornar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEstornar.UseVisualStyleBackColor = false;
            btnEstornar.Click += btnEstornar_Click;
            // 
            // txtDataCadastro
            // 
            txtDataCadastro.Location = new Point(12, 227);
            txtDataCadastro.Name = "txtDataCadastro";
            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Size = new Size(124, 23);
            txtDataCadastro.TabIndex = 25;
            // 
            // grVendaItens
            // 
            grVendaItens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grVendaItens.Controls.Add(panel1);
            grVendaItens.Controls.Add(dgvVendaItens);
            grVendaItens.Location = new Point(12, 258);
            grVendaItens.Name = "grVendaItens";
            grVendaItens.Size = new Size(773, 288);
            grVendaItens.TabIndex = 26;
            grVendaItens.TabStop = false;
            grVendaItens.Text = "Itens da Venda";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(btnNovoVendaItem);
            panel1.Controls.Add(btnRemoverVendaItem);
            panel1.Controls.Add(btnSalvarVendaItem);
            panel1.Controls.Add(lblSubtotalItemVenda);
            panel1.Controls.Add(nudSubtotalVendaItem);
            panel1.Controls.Add(lblPrecoUnitario);
            panel1.Controls.Add(lblQtdProdutos);
            panel1.Controls.Add(nudPrecoUnitarioVendaItem);
            panel1.Controls.Add(nudQuantidadeVendaItem);
            panel1.Controls.Add(cmbProdutoVendaItem);
            panel1.Controls.Add(lblProduto);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(466, 19);
            panel1.Name = "panel1";
            panel1.Size = new Size(304, 266);
            panel1.TabIndex = 30;
            // 
            // btnNovoVendaItem
            // 
            btnNovoVendaItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovoVendaItem.BackColor = SystemColors.Window;
            btnNovoVendaItem.FlatStyle = FlatStyle.Flat;
            btnNovoVendaItem.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNovoVendaItem.Image = Properties.Resources.new_label_16dp_204058;
            btnNovoVendaItem.Location = new Point(93, 15);
            btnNovoVendaItem.Name = "btnNovoVendaItem";
            btnNovoVendaItem.Size = new Size(61, 41);
            btnNovoVendaItem.TabIndex = 35;
            btnNovoVendaItem.Text = "Novo";
            btnNovoVendaItem.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNovoVendaItem.UseVisualStyleBackColor = false;
            btnNovoVendaItem.Click += btnNovoVendaItem_Click;
            // 
            // btnRemoverVendaItem
            // 
            btnRemoverVendaItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemoverVendaItem.BackColor = SystemColors.Window;
            btnRemoverVendaItem.FlatStyle = FlatStyle.Flat;
            btnRemoverVendaItem.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoverVendaItem.Image = Properties.Resources.close_16dp_204058;
            btnRemoverVendaItem.Location = new Point(227, 15);
            btnRemoverVendaItem.Name = "btnRemoverVendaItem";
            btnRemoverVendaItem.Size = new Size(61, 41);
            btnRemoverVendaItem.TabIndex = 34;
            btnRemoverVendaItem.Text = "Remover";
            btnRemoverVendaItem.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRemoverVendaItem.UseVisualStyleBackColor = false;
            btnRemoverVendaItem.Click += btnRemoverVendaItem_Click;
            // 
            // btnSalvarVendaItem
            // 
            btnSalvarVendaItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvarVendaItem.BackColor = SystemColors.Window;
            btnSalvarVendaItem.FlatStyle = FlatStyle.Flat;
            btnSalvarVendaItem.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalvarVendaItem.Image = Properties.Resources.save_16dp_204058;
            btnSalvarVendaItem.Location = new Point(160, 15);
            btnSalvarVendaItem.Name = "btnSalvarVendaItem";
            btnSalvarVendaItem.Size = new Size(61, 41);
            btnSalvarVendaItem.TabIndex = 29;
            btnSalvarVendaItem.Text = "Salvar";
            btnSalvarVendaItem.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvarVendaItem.UseVisualStyleBackColor = false;
            btnSalvarVendaItem.Click += btnSalvarVendaItem_Click;
            // 
            // lblSubtotalItemVenda
            // 
            lblSubtotalItemVenda.AutoSize = true;
            lblSubtotalItemVenda.Location = new Point(14, 206);
            lblSubtotalItemVenda.Name = "lblSubtotalItemVenda";
            lblSubtotalItemVenda.Size = new Size(51, 15);
            lblSubtotalItemVenda.TabIndex = 33;
            lblSubtotalItemVenda.Text = "Subtotal";
            // 
            // nudSubtotalVendaItem
            // 
            nudSubtotalVendaItem.DecimalPlaces = 2;
            nudSubtotalVendaItem.Location = new Point(14, 224);
            nudSubtotalVendaItem.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudSubtotalVendaItem.Name = "nudSubtotalVendaItem";
            nudSubtotalVendaItem.Size = new Size(120, 23);
            nudSubtotalVendaItem.TabIndex = 5;
            // 
            // lblPrecoUnitario
            // 
            lblPrecoUnitario.AutoSize = true;
            lblPrecoUnitario.Location = new Point(160, 157);
            lblPrecoUnitario.Name = "lblPrecoUnitario";
            lblPrecoUnitario.Size = new Size(82, 15);
            lblPrecoUnitario.TabIndex = 30;
            lblPrecoUnitario.Text = "Preço Unitário";
            // 
            // lblQtdProdutos
            // 
            lblQtdProdutos.AutoSize = true;
            lblQtdProdutos.Location = new Point(14, 157);
            lblQtdProdutos.Name = "lblQtdProdutos";
            lblQtdProdutos.Size = new Size(69, 15);
            lblQtdProdutos.TabIndex = 31;
            lblQtdProdutos.Text = "Quantidade";
            // 
            // nudPrecoUnitarioVendaItem
            // 
            nudPrecoUnitarioVendaItem.DecimalPlaces = 2;
            nudPrecoUnitarioVendaItem.Location = new Point(160, 175);
            nudPrecoUnitarioVendaItem.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudPrecoUnitarioVendaItem.Name = "nudPrecoUnitarioVendaItem";
            nudPrecoUnitarioVendaItem.Size = new Size(120, 23);
            nudPrecoUnitarioVendaItem.TabIndex = 4;
            nudPrecoUnitarioVendaItem.ValueChanged += CalcularSubtotalItemInput;
            // 
            // nudQuantidadeVendaItem
            // 
            nudQuantidadeVendaItem.Location = new Point(14, 175);
            nudQuantidadeVendaItem.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudQuantidadeVendaItem.Name = "nudQuantidadeVendaItem";
            nudQuantidadeVendaItem.Size = new Size(120, 23);
            nudQuantidadeVendaItem.TabIndex = 3;
            nudQuantidadeVendaItem.ValueChanged += CalcularSubtotalItemInput;
            // 
            // cmbProdutoVendaItem
            // 
            cmbProdutoVendaItem.FormattingEnabled = true;
            cmbProdutoVendaItem.Location = new Point(14, 123);
            cmbProdutoVendaItem.Name = "cmbProdutoVendaItem";
            cmbProdutoVendaItem.Size = new Size(274, 23);
            cmbProdutoVendaItem.TabIndex = 2;
            cmbProdutoVendaItem.SelectedIndexChanged += CmbProdutoVendaItem_SelectedIndexChanged;
            // 
            // lblProduto
            // 
            lblProduto.AutoSize = true;
            lblProduto.Location = new Point(14, 105);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(50, 15);
            lblProduto.TabIndex = 29;
            lblProduto.Text = "Produto";
            // 
            // dgvVendaItens
            // 
            dgvVendaItens.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvVendaItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVendaItens.Columns.AddRange(new DataGridViewColumn[] { clnIdVendaItem, clnVenda_Id, clnProduto_Id, clnProduto, clnQtd, clnPrecoUnitario, clnSubTotal });
            dgvVendaItens.Location = new Point(16, 35);
            dgvVendaItens.Name = "dgvVendaItens";
            dgvVendaItens.Size = new Size(434, 234);
            dgvVendaItens.TabIndex = 0;
            dgvVendaItens.RowEnter += dgvVendaItens_RowEnter;
            // 
            // clnIdVendaItem
            // 
            clnIdVendaItem.DataPropertyName = "Id";
            clnIdVendaItem.HeaderText = "IdVendaItem";
            clnIdVendaItem.Name = "clnIdVendaItem";
            clnIdVendaItem.Visible = false;
            // 
            // clnVenda_Id
            // 
            clnVenda_Id.HeaderText = "Venda_id";
            clnVenda_Id.Name = "clnVenda_Id";
            clnVenda_Id.Visible = false;
            // 
            // clnProduto_Id
            // 
            clnProduto_Id.HeaderText = "Produto_Id";
            clnProduto_Id.Name = "clnProduto_Id";
            clnProduto_Id.Visible = false;
            // 
            // clnProduto
            // 
            clnProduto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clnProduto.DataPropertyName = "produtonome";
            clnProduto.HeaderText = "Produto";
            clnProduto.Name = "clnProduto";
            // 
            // clnQtd
            // 
            clnQtd.DataPropertyName = "quantidade";
            clnQtd.HeaderText = "Qtd.";
            clnQtd.Name = "clnQtd";
            clnQtd.Width = 50;
            // 
            // clnPrecoUnitario
            // 
            clnPrecoUnitario.DataPropertyName = "PrecoUnitario";
            clnPrecoUnitario.HeaderText = "Preço unit.";
            clnPrecoUnitario.Name = "clnPrecoUnitario";
            // 
            // clnSubTotal
            // 
            clnSubTotal.DataPropertyName = "subtotal";
            clnSubTotal.HeaderText = "Subtotal";
            clnSubTotal.Name = "clnSubTotal";
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPesquisar.BackColor = SystemColors.Window;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Image = Properties.Resources.search_32dp_204058;
            btnPesquisar.Location = new Point(366, 12);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(69, 62);
            btnPesquisar.TabIndex = 28;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // txtTotalGeral
            // 
            txtTotalGeral.Location = new Point(142, 227);
            txtTotalGeral.Name = "txtTotalGeral";
            txtTotalGeral.ReadOnly = true;
            txtTotalGeral.Size = new Size(175, 23);
            txtTotalGeral.TabIndex = 29;
            // 
            // FrmVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 558);
            Controls.Add(txtTotalGeral);
            Controls.Add(btnPesquisar);
            Controls.Add(grVendaItens);
            Controls.Add(txtDataCadastro);
            Controls.Add(btnEstornar);
            Controls.Add(lblDataCadastro);
            Controls.Add(lblSituacaoVenda);
            Controls.Add(lblStatus);
            Controls.Add(btnEfetivar);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(lblTotalGeral);
            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmVenda";
            Text = "Venda";
            Load += FrmVenda_Load;
            grVendaItens.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSubtotalVendaItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecoUnitarioVendaItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudQuantidadeVendaItem).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVendaItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbCliente;
        private Label lblCliente;
        private Label lblTotalGeral;
        private Button btnSalvar;
        private Button btnCancelar;
        private Button btnNovo;
        private Button btnEfetivar;
        private Label lblStatus;
        private Label lblSituacaoVenda;
        private Label lblDataCadastro;
        private Button btnEstornar;
        private TextBox txtDataCadastro;
        private GroupBox grVendaItens;
        private DataGridView dgvVendaItens;
        private Label lblProduto;
        private ComboBox cmbProdutoVendaItem;
        private Panel panel1;
        private Button btnPesquisar;
        private Label lblQtdProdutos;
        private NumericUpDown nudQuantidadeVendaItem;
        private Label lblPrecoUnitario;
        private NumericUpDown nudPrecoUnitarioVendaItem;
        private Label lblSubtotalItemVenda;
        private NumericUpDown nudSubtotalVendaItem;
        private Button btnRemoverVendaItem;
        private Button btnSalvarVendaItem;
        private Button btnNovoVendaItem;
        private DataGridViewTextBoxColumn clnIdVendaItem;
        private DataGridViewTextBoxColumn clnVenda_Id;
        private DataGridViewTextBoxColumn clnProduto_Id;
        private DataGridViewTextBoxColumn clnProduto;
        private DataGridViewTextBoxColumn clnQtd;
        private DataGridViewTextBoxColumn clnPrecoUnitario;
        private DataGridViewTextBoxColumn clnSubTotal;
        private TextBox txtTotalGeral;
    }
}