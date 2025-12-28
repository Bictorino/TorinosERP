namespace TorinosERP.WinForms
{
    partial class FrmPesquisarVendas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPesquisarVendas));
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnPesquisar = new Button();
            dtInicial = new DateTimePicker();
            dtFinal = new DateTimePicker();
            lblDtInicial = new Label();
            label1 = new Label();
            rdbDataCadastro = new RadioButton();
            rdbDataVenda = new RadioButton();
            grTipoData = new GroupBox();
            lblStatusVenda = new Label();
            cmbStatusVenda = new ComboBox();
            dgvPesquisa = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnClientNome = new DataGridViewTextBoxColumn();
            clnDataCadastro = new DataGridViewTextBoxColumn();
            clnDataVenda = new DataGridViewTextBoxColumn();
            clnValorTotal = new DataGridViewTextBoxColumn();
            clnStatus = new DataGridViewTextBoxColumn();
            lblStatus = new Label();
            lblGuiaUsuario = new Label();
            lblTotalRegistros = new Label();
            grTipoData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPesquisa).BeginInit();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(12, 107);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 2;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(12, 125);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(221, 23);
            cmbCliente.TabIndex = 1;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPesquisar.BackColor = SystemColors.Window;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Image = Properties.Resources.search_32dp_204058;
            btnPesquisar.Location = new Point(716, 12);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(69, 62);
            btnPesquisar.TabIndex = 29;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // dtInicial
            // 
            dtInicial.Format = DateTimePickerFormat.Custom;
            dtInicial.Location = new Point(250, 125);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(98, 23);
            dtInicial.TabIndex = 2;
            // 
            // dtFinal
            // 
            dtFinal.Format = DateTimePickerFormat.Custom;
            dtFinal.Location = new Point(354, 125);
            dtFinal.Name = "dtFinal";
            dtFinal.Size = new Size(98, 23);
            dtFinal.TabIndex = 3;
            // 
            // lblDtInicial
            // 
            lblDtInicial.AutoSize = true;
            lblDtInicial.Location = new Point(250, 107);
            lblDtInicial.Name = "lblDtInicial";
            lblDtInicial.Size = new Size(65, 15);
            lblDtInicial.TabIndex = 32;
            lblDtInicial.Text = "Data Inicial";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(354, 107);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 33;
            label1.Text = "Data Final";
            // 
            // rdbDataCadastro
            // 
            rdbDataCadastro.AutoSize = true;
            rdbDataCadastro.Location = new Point(6, 52);
            rdbDataCadastro.Name = "rdbDataCadastro";
            rdbDataCadastro.Size = new Size(99, 19);
            rdbDataCadastro.TabIndex = 34;
            rdbDataCadastro.TabStop = true;
            rdbDataCadastro.Text = "Data Cadastro";
            rdbDataCadastro.UseVisualStyleBackColor = true;
            // 
            // rdbDataVenda
            // 
            rdbDataVenda.AutoSize = true;
            rdbDataVenda.Location = new Point(6, 27);
            rdbDataVenda.Name = "rdbDataVenda";
            rdbDataVenda.Size = new Size(84, 19);
            rdbDataVenda.TabIndex = 35;
            rdbDataVenda.TabStop = true;
            rdbDataVenda.Text = "Data Venda";
            rdbDataVenda.UseVisualStyleBackColor = true;
            // 
            // grTipoData
            // 
            grTipoData.Controls.Add(rdbDataCadastro);
            grTipoData.Controls.Add(rdbDataVenda);
            grTipoData.Location = new Point(458, 107);
            grTipoData.Name = "grTipoData";
            grTipoData.Size = new Size(105, 87);
            grTipoData.TabIndex = 36;
            grTipoData.TabStop = false;
            grTipoData.Text = "Filtro Data";
            // 
            // lblStatusVenda
            // 
            lblStatusVenda.AutoSize = true;
            lblStatusVenda.Location = new Point(12, 153);
            lblStatusVenda.Name = "lblStatusVenda";
            lblStatusVenda.Size = new Size(39, 15);
            lblStatusVenda.TabIndex = 37;
            lblStatusVenda.Text = "Status";
            // 
            // cmbStatusVenda
            // 
            cmbStatusVenda.FormattingEnabled = true;
            cmbStatusVenda.Location = new Point(12, 171);
            cmbStatusVenda.Name = "cmbStatusVenda";
            cmbStatusVenda.Size = new Size(221, 23);
            cmbStatusVenda.TabIndex = 4;
            // 
            // dgvPesquisa
            // 
            dgvPesquisa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesquisa.Columns.AddRange(new DataGridViewColumn[] { clnId, clnClientNome, clnDataCadastro, clnDataVenda, clnValorTotal, clnStatus });
            dgvPesquisa.Location = new Point(12, 227);
            dgvPesquisa.MultiSelect = false;
            dgvPesquisa.Name = "dgvPesquisa";
            dgvPesquisa.ReadOnly = true;
            dgvPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPesquisa.Size = new Size(773, 319);
            dgvPesquisa.TabIndex = 39;
            // 
            // clnId
            // 
            clnId.DataPropertyName = "Id";
            clnId.HeaderText = "Id";
            clnId.Name = "clnId";
            clnId.ReadOnly = true;
            clnId.Visible = false;
            // 
            // clnClientNome
            // 
            clnClientNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clnClientNome.DataPropertyName = "ClienteNome";
            clnClientNome.HeaderText = "Cliente";
            clnClientNome.Name = "clnClientNome";
            clnClientNome.ReadOnly = true;
            // 
            // clnDataCadastro
            // 
            clnDataCadastro.DataPropertyName = "DataCadastro";
            clnDataCadastro.HeaderText = "Data Cadastro";
            clnDataCadastro.Name = "clnDataCadastro";
            clnDataCadastro.ReadOnly = true;
            clnDataCadastro.Width = 130;
            // 
            // clnDataVenda
            // 
            clnDataVenda.DataPropertyName = "DataVenda";
            clnDataVenda.HeaderText = "Data Venda";
            clnDataVenda.Name = "clnDataVenda";
            clnDataVenda.ReadOnly = true;
            clnDataVenda.Width = 120;
            // 
            // clnValorTotal
            // 
            clnValorTotal.DataPropertyName = "ValorTotal";
            clnValorTotal.HeaderText = "Valor Total";
            clnValorTotal.Name = "clnValorTotal";
            clnValorTotal.ReadOnly = true;
            // 
            // clnStatus
            // 
            clnStatus.DataPropertyName = "StatusDescricao";
            clnStatus.HeaderText = "Status";
            clnStatus.Name = "clnStatus";
            clnStatus.ReadOnly = true;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 29);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(536, 27);
            lblStatus.TabIndex = 40;
            // 
            // lblGuiaUsuario
            // 
            lblGuiaUsuario.Font = new Font("Tahoma", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblGuiaUsuario.Location = new Point(12, 56);
            lblGuiaUsuario.Name = "lblGuiaUsuario";
            lblGuiaUsuario.Size = new Size(536, 27);
            lblGuiaUsuario.TabIndex = 41;
            lblGuiaUsuario.Text = "Duplo clique para selecionar a Venda";
            // 
            // lblTotalRegistros
            // 
            lblTotalRegistros.AutoSize = true;
            lblTotalRegistros.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalRegistros.Location = new Point(625, 207);
            lblTotalRegistros.Name = "lblTotalRegistros";
            lblTotalRegistros.Size = new Size(134, 17);
            lblTotalRegistros.TabIndex = 42;
            lblTotalRegistros.Text = "Total de Registros: 0";
            // 
            // FrmPesquisarVendas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 558);
            Controls.Add(lblTotalRegistros);
            Controls.Add(lblGuiaUsuario);
            Controls.Add(lblStatus);
            Controls.Add(dgvPesquisa);
            Controls.Add(lblStatusVenda);
            Controls.Add(cmbStatusVenda);
            Controls.Add(grTipoData);
            Controls.Add(label1);
            Controls.Add(lblDtInicial);
            Controls.Add(dtFinal);
            Controls.Add(dtInicial);
            Controls.Add(btnPesquisar);
            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(813, 597);
            Name = "FrmPesquisarVendas";
            Text = "Pesquisa de Vendas";
            Load += FrmPesquisarVendas_Load;
            grTipoData.ResumeLayout(false);
            grTipoData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPesquisa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnPesquisar;
        private DateTimePicker dtInicial;
        private DateTimePicker dtFinal;
        private Label lblDtInicial;
        private Label label1;
        private RadioButton rdbDataCadastro;
        private RadioButton rdbDataVenda;
        private GroupBox grTipoData;
        private Label lblStatusVenda;
        private ComboBox cmbStatusVenda;
        private DataGridView dgvPesquisa;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnClientNome;
        private DataGridViewTextBoxColumn clnDataCadastro;
        private DataGridViewTextBoxColumn clnDataVenda;
        private DataGridViewTextBoxColumn clnValorTotal;
        private DataGridViewTextBoxColumn clnStatus;
        private Label lblStatus;
        private Label lblGuiaUsuario;
        private Label lblTotalRegistros;
    }
}