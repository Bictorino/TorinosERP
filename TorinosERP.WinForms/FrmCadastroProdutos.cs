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
    public partial class FrmCadastroProdutos : Form
    {
        private readonly IProdutoRepository _produtoRepo;
        private Produto? _Produto = null;

        public FrmCadastroProdutos(IProdutoRepository produtoRepo)
        {
            InitializeComponent();
            _produtoRepo = produtoRepo;
            this.AcceptButton = btnSalvar;
        }

        private async void FrmCadastroProdutos_Load(object sender, EventArgs e)
        {
            await CarregarGrid();
            lblStatus.Text = "Novo Cadastro.";
        }

        private async Task CarregarGrid()
        {
            try
            {
                var produtos = await _produtoRepo.ObterTodosAsync();
                dgvProdutos.DataSource = produtos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}");
            }
        }    

        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_Produto == null)
                {
                    Produto produto = new Produto(txtNome.Text, nudPreco.Value, (int)nudEstoque.Value, txtDescricao.Text);
                    await _produtoRepo.AdicionarAsync(produto);
                    lblStatus.Text = $"Produto {produto.Nome} cadastrado com sucesso!";
                }
                else
                {
                    _Produto.Atualizar(txtNome.Text, nudPreco.Value, (int)nudEstoque.Value, txtDescricao.Text);
                    await _produtoRepo.AtualizarAsync(_Produto);
                    lblStatus.Text = $"Produto {_Produto.Nome} atualizado.";
                }

                LimparCampos();
                await CarregarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private async void BtnRemover_Click(object sender, EventArgs e)
        {
            if (_Produto == null)
            {
                MessageBox.Show("Selecione um produto na lista para remover.");
                return;
            }

            var confirmacao = MessageBox.Show(
                "Tem certeza que deseja excluir este produto?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacao == DialogResult.Yes)
            {
                try
                {
                    await _produtoRepo.RemoverAsync(_Produto.Id);
                    LimparCampos();
                    await CarregarGrid();
                    lblStatus.Text = "Produto removido.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover: {ex.Message}");
                }
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void dgvProdutos_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProdutos.Rows[e.RowIndex];

                _Produto = (Produto)row.DataBoundItem;
                txtNome.Text = _Produto.Nome;
                txtDescricao.Text = _Produto.Descricao;
                nudPreco.Value = _Produto.Preco;
                nudEstoque.Value = _Produto.Estoque;

                lblStatus.Text = $"Editando: {_Produto.Nome}.";
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            nudPreco.Value = 0;
            nudEstoque.Value = 0;
            _Produto = null;
            txtNome.Focus();
            lblStatus.Text = "Novo Cadastro.";
        }
    }
}
