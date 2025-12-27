using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Interfaces.Repositories;

namespace TorinosERP.WinForms
{
    public partial class FrmCadastroClientes : Form
    {
        private readonly IClienteRepository _clienteRepo;
        private Cliente? _Cliente = null;

        public FrmCadastroClientes(IClienteRepository clienteRepo)
        {
            InitializeComponent();
            _clienteRepo = clienteRepo;
            this.AcceptButton = btnSalvar;            
        }

        private async void FrmCadastroClientes_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
            lblStatus.Text = "Novo Cadastro.";
        }

        private async Task CarregarGrid()
        {
            try
            {
                var clientes = await _clienteRepo.ObterTodosAsync();
                dgvClientes.DataSource = clientes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}");
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_Cliente == null)
                {
                    Cliente novoCliente = new Cliente(txtNome.Text, txtEmail.Text, txtTelefone.Text);
                    await _clienteRepo.AdicionarAsync(novoCliente);
                    lblStatus.Text = $"Cliente {novoCliente.Nome} cadastrado com sucesso!";
                }
                else
                {
                    _Cliente.AtualizarDados(txtNome.Text, txtEmail.Text, txtTelefone.Text);
                    await _clienteRepo.AtualizarAsync(_Cliente);
                    lblStatus.Text = $"Cliente {_Cliente.Nome} atualizado.";
                }
                
                await CarregarGrid();
                dgvClientes.ClearSelection();
                LimparCampos();
            }
            catch (Exception ex)
            {
                await CarregarGrid();
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private async void btnRemover_Click(object sender, EventArgs e)
        {
            if (_Cliente == null)
            {
                MessageBox.Show("Selecione um cliente na lista para remover.");
                return;
            }

            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir este cliente?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    await _clienteRepo.RemoverAsync(_Cliente.Id);
                    LimparCampos();
                    await CarregarGrid();
                    lblStatus.Text = "Cliente removido.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover: {ex.Message}");
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvClientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];
                _Cliente = (Cliente)row.DataBoundItem;

                txtNome.Text = _Cliente.Nome;
                txtEmail.Text = _Cliente.Email;
                txtTelefone.Text = _Cliente.Telefone;

                lblStatus.Text = $"Editando: {_Cliente.Nome}.";
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
            _Cliente = null;
            txtNome.Focus();
            lblStatus.Text = "Novo Cadastro.";
        }
    }
}
