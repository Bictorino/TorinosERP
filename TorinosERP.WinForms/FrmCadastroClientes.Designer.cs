namespace TorinosERP.WinForms
{
    partial class FrmCadastroClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastroClientes));
            lblStatus = new Label();
            btnSalvar = new Button();
            btnRemover = new Button();
            btnNovo = new Button();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            txtTelefone = new MaskedTextBox();
            lblTelefone = new Label();
            dgvClientes = new DataGridView();
            clnId = new DataGridViewTextBoxColumn();
            clnNome = new DataGridViewTextBoxColumn();
            clnEmail = new DataGridViewTextBoxColumn();
            clnTelefone = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Tahoma", 16F);
            lblStatus.Location = new Point(12, 51);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(474, 27);
            lblStatus.TabIndex = 16;
            lblStatus.Text = "Status";
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSalvar.BackColor = SystemColors.Window;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.Image = Properties.Resources.save_32dp_204058;
            btnSalvar.Location = new Point(651, 26);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(64, 62);
            btnSalvar.TabIndex = 14;
            btnSalvar.Text = "Salvar";
            btnSalvar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnRemover
            // 
            btnRemover.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemover.BackColor = SystemColors.Window;
            btnRemover.FlatStyle = FlatStyle.Flat;
            btnRemover.Image = Properties.Resources.clear_32dp_204058;
            btnRemover.Location = new Point(721, 26);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(64, 62);
            btnRemover.TabIndex = 15;
            btnRemover.Text = "Remover";
            btnRemover.TextImageRelation = TextImageRelation.ImageAboveText;
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.Click += btnRemover_Click;
            // 
            // btnNovo
            // 
            btnNovo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNovo.BackColor = SystemColors.Window;
            btnNovo.FlatStyle = FlatStyle.Flat;
            btnNovo.Image = Properties.Resources.new_label_32dp_204058__1_;
            btnNovo.Location = new Point(581, 26);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(64, 62);
            btnNovo.TabIndex = 13;
            btnNovo.Text = "Novo";
            btnNovo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(189, 114);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 20;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(189, 132);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(171, 23);
            txtEmail.TabIndex = 18;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(12, 114);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 19;
            lblNome.Text = "Nome";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 132);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(171, 23);
            txtNome.TabIndex = 17;
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(366, 132);
            txtTelefone.Mask = "(00)00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(129, 23);
            txtTelefone.TabIndex = 21;
            // 
            // lblTelefone
            // 
            lblTelefone.AutoSize = true;
            lblTelefone.Location = new Point(366, 114);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(51, 15);
            lblTelefone.TabIndex = 22;
            lblTelefone.Text = "Telefone";
            // 
            // dgvClientes
            // 
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { clnId, clnNome, clnEmail, clnTelefone });
            dgvClientes.Location = new Point(12, 205);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(773, 341);
            dgvClientes.TabIndex = 23;
            dgvClientes.RowEnter += dgvClientes_RowEnter;
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
            // clnEmail
            // 
            clnEmail.DataPropertyName = "Email";
            clnEmail.HeaderText = "Email";
            clnEmail.Name = "clnEmail";
            clnEmail.Width = 200;
            // 
            // clnTelefone
            // 
            clnTelefone.DataPropertyName = "Telefone";
            clnTelefone.HeaderText = "Telefone";
            clnTelefone.Name = "clnTelefone";
            clnTelefone.Width = 120;
            // 
            // FrmCadastroClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 558);
            Controls.Add(dgvClientes);
            Controls.Add(lblTelefone);
            Controls.Add(txtTelefone);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblNome);
            Controls.Add(txtNome);
            Controls.Add(lblStatus);
            Controls.Add(btnSalvar);
            Controls.Add(btnRemover);
            Controls.Add(btnNovo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCadastroClientes";
            Text = "Cadastro de Clientes";
            Load += FrmCadastroClientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnSalvar;
        private Button btnRemover;
        private Button btnNovo;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblNome;
        private TextBox txtNome;
        private MaskedTextBox txtTelefone;
        private Label lblTelefone;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn clnId;
        private DataGridViewTextBoxColumn clnNome;
        private DataGridViewTextBoxColumn clnEmail;
        private DataGridViewTextBoxColumn clnTelefone;
    }
}