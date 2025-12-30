namespace TorinosERP.WinForms
{
    partial class FrmRelatorios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRelatorios));
            lblStatusVenda = new Label();
            cmbStatusVenda = new ComboBox();
            grTipoData = new GroupBox();
            rdbDataCadastro = new RadioButton();
            rdbDataVenda = new RadioButton();
            label1 = new Label();
            lblDtInicial = new Label();
            dtFinal = new DateTimePicker();
            dtInicial = new DateTimePicker();
            lblCliente = new Label();
            cmbCliente = new ComboBox();
            btnPesquisar = new Button();
            pnlReportViewer = new Panel();
            grTipoRelatorio = new GroupBox();
            rdbAnalitico = new RadioButton();
            rdbResumido = new RadioButton();
            grTipoData.SuspendLayout();
            grTipoRelatorio.SuspendLayout();
            SuspendLayout();
            // 
            // lblStatusVenda
            // 
            lblStatusVenda.AutoSize = true;
            lblStatusVenda.Location = new Point(20, 79);
            lblStatusVenda.Name = "lblStatusVenda";
            lblStatusVenda.Size = new Size(39, 15);
            lblStatusVenda.TabIndex = 46;
            lblStatusVenda.Text = "Status";
            // 
            // cmbStatusVenda
            // 
            cmbStatusVenda.FormattingEnabled = true;
            cmbStatusVenda.Location = new Point(20, 97);
            cmbStatusVenda.Name = "cmbStatusVenda";
            cmbStatusVenda.Size = new Size(221, 23);
            cmbStatusVenda.TabIndex = 42;
            // 
            // grTipoData
            // 
            grTipoData.Controls.Add(rdbDataCadastro);
            grTipoData.Controls.Add(rdbDataVenda);
            grTipoData.Location = new Point(470, 33);
            grTipoData.Name = "grTipoData";
            grTipoData.Size = new Size(109, 87);
            grTipoData.TabIndex = 45;
            grTipoData.TabStop = false;
            grTipoData.Text = "Filtro Data";
            // 
            // rdbDataCadastro
            // 
            rdbDataCadastro.AutoSize = true;
            rdbDataCadastro.Enabled = false;
            rdbDataCadastro.Location = new Point(6, 52);
            rdbDataCadastro.Name = "rdbDataCadastro";
            rdbDataCadastro.Size = new Size(99, 19);
            rdbDataCadastro.TabIndex = 34;
            rdbDataCadastro.Text = "Data Cadastro";
            rdbDataCadastro.UseVisualStyleBackColor = true;
            // 
            // rdbDataVenda
            // 
            rdbDataVenda.AutoSize = true;
            rdbDataVenda.Checked = true;
            rdbDataVenda.Location = new Point(6, 27);
            rdbDataVenda.Name = "rdbDataVenda";
            rdbDataVenda.Size = new Size(84, 19);
            rdbDataVenda.TabIndex = 35;
            rdbDataVenda.TabStop = true;
            rdbDataVenda.Text = "Data Venda";
            rdbDataVenda.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 33);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 44;
            label1.Text = "Data Final";
            // 
            // lblDtInicial
            // 
            lblDtInicial.AutoSize = true;
            lblDtInicial.Location = new Point(258, 33);
            lblDtInicial.Name = "lblDtInicial";
            lblDtInicial.Size = new Size(65, 15);
            lblDtInicial.TabIndex = 43;
            lblDtInicial.Text = "Data Inicial";
            // 
            // dtFinal
            // 
            dtFinal.Format = DateTimePickerFormat.Custom;
            dtFinal.Location = new Point(362, 51);
            dtFinal.Name = "dtFinal";
            dtFinal.Size = new Size(98, 23);
            dtFinal.TabIndex = 41;
            // 
            // dtInicial
            // 
            dtInicial.Format = DateTimePickerFormat.Custom;
            dtInicial.Location = new Point(258, 51);
            dtInicial.Name = "dtInicial";
            dtInicial.Size = new Size(98, 23);
            dtInicial.TabIndex = 39;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(20, 33);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(44, 15);
            lblCliente.TabIndex = 40;
            lblCliente.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.FormattingEnabled = true;
            cmbCliente.Location = new Point(20, 51);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(221, 23);
            cmbCliente.TabIndex = 38;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPesquisar.BackColor = SystemColors.Window;
            btnPesquisar.FlatStyle = FlatStyle.Flat;
            btnPesquisar.Image = Properties.Resources.search_32dp_204058;
            btnPesquisar.Location = new Point(704, 30);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(69, 62);
            btnPesquisar.TabIndex = 47;
            btnPesquisar.Text = "Pesquisar";
            btnPesquisar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPesquisar.UseVisualStyleBackColor = false;
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // pnlReportViewer
            // 
            pnlReportViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlReportViewer.Location = new Point(20, 142);
            pnlReportViewer.Name = "pnlReportViewer";
            pnlReportViewer.Size = new Size(753, 394);
            pnlReportViewer.TabIndex = 48;
            // 
            // grTipoRelatorio
            // 
            grTipoRelatorio.Controls.Add(rdbAnalitico);
            grTipoRelatorio.Controls.Add(rdbResumido);
            grTipoRelatorio.Location = new Point(258, 85);
            grTipoRelatorio.Name = "grTipoRelatorio";
            grTipoRelatorio.Size = new Size(202, 51);
            grTipoRelatorio.TabIndex = 49;
            grTipoRelatorio.TabStop = false;
            grTipoRelatorio.Text = "Tipo";
            // 
            // rdbAnalitico
            // 
            rdbAnalitico.AutoSize = true;
            rdbAnalitico.Checked = true;
            rdbAnalitico.Location = new Point(98, 22);
            rdbAnalitico.Name = "rdbAnalitico";
            rdbAnalitico.Size = new Size(72, 19);
            rdbAnalitico.TabIndex = 37;
            rdbAnalitico.TabStop = true;
            rdbAnalitico.Text = "Analítico";
            rdbAnalitico.UseVisualStyleBackColor = true;
            // 
            // rdbResumido
            // 
            rdbResumido.AutoSize = true;
            rdbResumido.Checked = true;
            rdbResumido.Location = new Point(12, 22);
            rdbResumido.Name = "rdbResumido";
            rdbResumido.Size = new Size(78, 19);
            rdbResumido.TabIndex = 36;
            rdbResumido.TabStop = true;
            rdbResumido.Text = "Resumido";
            rdbResumido.UseVisualStyleBackColor = true;
            // 
            // FrmRelatorios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 558);
            Controls.Add(grTipoRelatorio);
            Controls.Add(pnlReportViewer);
            Controls.Add(btnPesquisar);
            Controls.Add(lblStatusVenda);
            Controls.Add(cmbStatusVenda);
            Controls.Add(grTipoData);
            Controls.Add(label1);
            Controls.Add(lblDtInicial);
            Controls.Add(dtFinal);
            Controls.Add(dtInicial);
            Controls.Add(lblCliente);
            Controls.Add(cmbCliente);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(813, 597);
            Name = "FrmRelatorios";
            Text = "Relatórios";
            Load += FrmRelatorios_Load;
            grTipoData.ResumeLayout(false);
            grTipoData.PerformLayout();
            grTipoRelatorio.ResumeLayout(false);
            grTipoRelatorio.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatusVenda;
        private ComboBox cmbStatusVenda;
        private GroupBox grTipoData;
        private RadioButton rdbDataCadastro;
        private RadioButton rdbDataVenda;
        private Label label1;
        private Label lblDtInicial;
        private DateTimePicker dtFinal;
        private DateTimePicker dtInicial;
        private Label lblCliente;
        private ComboBox cmbCliente;
        private Button btnPesquisar;
        private Panel pnlReportViewer;
        private GroupBox grTipoRelatorio;
        private RadioButton rdbAnalitico;
        private RadioButton rdbResumido;
    }
}