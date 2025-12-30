using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorinosERP.Application.Services;
using TorinosERP.Domain.Entities;
using TorinosERP.Domain.Enums;
using TorinosERP.Domain.Interfaces.Repositories;

namespace TorinosERP.WinForms
{
    public partial class FrmVenda : Form
    {
        private readonly VendaService _vendaService;
        private readonly IClienteRepository _clienteRepo;
        private readonly IProdutoRepository _produtoRepo;
        private readonly IVendaRepository _vendaRepo;

        private Venda? _vendaAtual;
        private BindingSource _bindingSourceItens = new BindingSource();
        
        private VendaItem? _itemEmEdicao = null;
        private bool _carregandoItem = false;

        public FrmVenda(
            VendaService vendaService,
            IClienteRepository clienteRepo,
            IProdutoRepository produtoRepo,
            IVendaRepository vendaRepo)
        {
            InitializeComponent();
            _vendaService = vendaService;
            _clienteRepo = clienteRepo;
            _produtoRepo = produtoRepo;
            _vendaRepo = vendaRepo;

            CarregarGrid();            
        }

        private async void FrmVenda_Load(object sender, EventArgs e)
        {
            await CarregarCombos();
            IniciarNovaVenda();
        }
        
        #region Manipulação de Itens (Em Memória)
        
        private void dgvVendaItens_RowEnter(object sender, DataGridViewCellEventArgs e)
        {            
            if (_vendaAtual == null || _vendaAtual.Status != VendaStatus.Aberta) return;

            if (e.RowIndex >= 0 && dgvVendaItens.Rows[e.RowIndex].DataBoundItem is VendaItem itemSelecionado)
            {
                _carregandoItem = true; 

                try
                {
                    _itemEmEdicao = itemSelecionado;
                    cmbProdutoVendaItem.SelectedValue = itemSelecionado.ProdutoId;
                    nudQuantidadeVendaItem.Value = itemSelecionado.Quantidade;
                    nudPrecoUnitarioVendaItem.Value = itemSelecionado.PrecoUnitario;                   
                }
                finally
                {
                    _carregandoItem = false; 
                }
            }
        }

        private void btnNovoVendaItem_Click(object sender, EventArgs e)
        {
            LimparCamposItemInput();
        }

        private void btnSalvarVendaItem_Click(object sender, EventArgs e)
        {
            try
            {                
                if (_vendaAtual != null && _vendaAtual.Status != VendaStatus.Aberta)
                {
                    MessageBox.Show("Não é possível alterar itens de uma venda fechada.");
                    return;
                }
                
                if (cmbProdutoVendaItem.SelectedItem is not Produto produtoSelecionado)
                {
                    MessageBox.Show("Selecione um produto.");
                    return;
                }

                if (cmbCliente.SelectedItem is not Cliente clienteSelecionado)
                {
                    MessageBox.Show("Selecione um cliente para iniciar a venda.");
                    cmbCliente.Focus();
                    return;
                }
                
                if (_vendaAtual == null)
                {
                    _vendaAtual = new Venda(clienteSelecionado.Id);
                }
                
                int qtd = (int)nudQuantidadeVendaItem.Value;
                decimal preco = nudPrecoUnitarioVendaItem.Value;
                
                if (_itemEmEdicao != null)
                {                    
                    _vendaAtual.RemoverItem(_itemEmEdicao);
                }
                
                var novoItem = new VendaItem(produtoSelecionado.Id, produtoSelecionado.Nome, qtd, preco);                
                _vendaAtual.AdicionarItem(novoItem);
                
                AtualizarInterfaceVenda();
                LimparCamposItemInput(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar item: {ex.Message}");
            }
        }

        private void btnRemoverVendaItem_Click(object sender, EventArgs e)
        {
            if (_vendaAtual == null || _vendaAtual.Status != VendaStatus.Aberta)
            {
                MessageBox.Show("Venda não permite remoção (Verifique se está Aberta).");
                return;
            }

            VendaItem? itemParaRemover = _itemEmEdicao;

            if (itemParaRemover == null && dgvVendaItens.CurrentRow?.DataBoundItem is VendaItem itemGrid)
            {
                itemParaRemover = itemGrid;
            }

            if (itemParaRemover != null)
            {
                _vendaAtual.RemoverItem(itemParaRemover);
                AtualizarInterfaceVenda();
                LimparCamposItemInput();
            }
            else
            {
                MessageBox.Show("Selecione um item para remover.");
            }
        }

        private void CmbProdutoVendaItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_carregandoItem) return;

            if (cmbProdutoVendaItem.SelectedItem is Produto produto)
            {
                nudPrecoUnitarioVendaItem.Value = produto.Preco;
                nudQuantidadeVendaItem.Value = 1;
                CalcularSubtotalItemInput(sender, e);
            }
        }

        private void CalcularSubtotalItemInput(object sender, EventArgs e)
        {
            nudSubtotalVendaItem.Value = nudQuantidadeVendaItem.Value * nudPrecoUnitarioVendaItem.Value;
        }

        private void LimparCamposItemInput()
        {
            _carregandoItem = true; 

            cmbProdutoVendaItem.SelectedIndex = -1;
            nudQuantidadeVendaItem.Value = 0;
            nudPrecoUnitarioVendaItem.Value = 0;
            nudSubtotalVendaItem.Value = 0;

            _itemEmEdicao = null; 
            btnSalvarVendaItem.Text = "Salvar"; 

            dgvVendaItens.ClearSelection(); 
            cmbProdutoVendaItem.Focus();

            _carregandoItem = false;
        }

        #endregion

        #region Ações Transacionais 

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (_vendaAtual == null || !_vendaAtual.Itens.Any())
            {
                MessageBox.Show("Adicione itens para salvar a venda.");
                return;
            }

            try
            {
                _vendaAtual = await _vendaService.SalvarRascunhoAsync(_vendaAtual);

                AtualizarInterfaceVenda();
                MessageBox.Show("Venda salva com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}");
            }
        }

        private async void btnEfetivar_Click(object sender, EventArgs e)
        {
            if (_vendaAtual == null) return;

            try
            {
                if (_vendaAtual.Id == 0)
                {
                    MessageBox.Show("Salve a venda antes de efetivar.");
                    return;
                }

                if (MessageBox.Show("Confirma a efetivação? O estoque será baixado.", "Efetivar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await _vendaService.EfetivarVendaAsync(_vendaAtual);

                    AtualizarInterfaceVenda();
                    MessageBox.Show("Venda efetivada com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao efetivar: {ex.Message}");
            }
        }

        private async void btnEstornar_Click(object sender, EventArgs e)
        {
            if (_vendaAtual == null) return;

            if (MessageBox.Show("Deseja estornar esta venda? O estoque será devolvido.", "Estornar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _vendaService.EstornarVendaAsync(_vendaAtual);

                    AtualizarInterfaceVenda();
                    MessageBox.Show("Venda estornada com sucesso!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao estornar: {ex.Message}");
                }
            }
        }

        private async void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_vendaAtual == null) return;

            if (MessageBox.Show("Tem certeza que deseja cancelar esta venda?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    await _vendaService.CancelarVendaAsync(_vendaAtual);

                    AtualizarInterfaceVenda();
                    MessageBox.Show("Venda cancelada.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cancelar: {ex.Message}");
                }
            }
        }

        private async Task CarregarVendaDoBanco(int id)
        {
            try
            {                
                var vendaEncontrada = await _vendaRepo.ObterPorIdAsync(id);

                if (vendaEncontrada != null)
                {
                    _vendaAtual = vendaEncontrada;
                    cmbCliente.SelectedValue = _vendaAtual.ClienteId;

                    AtualizarInterfaceVenda();
                }
                else
                {
                    MessageBox.Show("Venda não encontrada ou excluída.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar venda: {ex.Message}");
            }
        }

        #endregion

        #region Outros
        private void btnNovo_Click(object sender, EventArgs e)
        {
            IniciarNovaVenda();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {

            using (var frm = new FrmPesquisarVendas(_vendaRepo, _clienteRepo))
            {
                frm.StartPosition = FormStartPosition.CenterParent;

                var result = frm.ShowDialog();

                if (result == DialogResult.OK)
                {
                    await CarregarVendaDoBanco(frm.IdSelecionado);
                }
            }
        }

        private void HabilitarControles(bool allowEdit)
        {
            grVendaItens.Enabled = allowEdit;

            btnSalvar.Enabled = allowEdit;
            btnEfetivar.Enabled = allowEdit;

            btnEstornar.Enabled = !allowEdit && _vendaAtual?.Status == VendaStatus.Efetivada;
            btnCancelar.Enabled = _vendaAtual?.Status != VendaStatus.Cancelada && _vendaAtual?.Id > 0;
        }

        private void CarregarGrid()
        {
            dgvVendaItens.AutoGenerateColumns = false;
            dgvVendaItens.DataSource = _bindingSourceItens;
        }

        private async Task CarregarCombos()
        {
            try
            {
                var clientes = await _clienteRepo.ObterTodosAsync();
                cmbCliente.DataSource = clientes.ToList();
                cmbCliente.DisplayMember = "Nome";
                cmbCliente.ValueMember = "Id";
                cmbCliente.SelectedIndex = -1;

                var produtos = await _produtoRepo.ObterTodosAsync();
                cmbProdutoVendaItem.DataSource = produtos.ToList();
                cmbProdutoVendaItem.DisplayMember = "Nome";
                cmbProdutoVendaItem.ValueMember = "Id";
                cmbProdutoVendaItem.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar listas: {ex.Message}");
            }
        }

        private void IniciarNovaVenda()
        {
            _vendaAtual = null;
            _bindingSourceItens.DataSource = null;

            cmbCliente.SelectedIndex = -1;
            cmbCliente.Enabled = true;
            txtTotalGeral.Text = "R$ 00,00";

            lblStatus.Text = "Nova Venda (Rascunho)";
            lblSituacaoVenda.Text = "Situação: Nova";
            //txtDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");

            LimparCamposItemInput();
            HabilitarControles(true);
        }

        private void AtualizarInterfaceVenda()
        {
            if (_vendaAtual == null) return;

            _bindingSourceItens.DataSource = null;
            _bindingSourceItens.DataSource = _vendaAtual.Itens.ToList();

            txtTotalGeral.Text = $"R$ {_vendaAtual.ValorTotal.ToString("0.00")}";

            lblStatus.Text = _vendaAtual.Id == 0 ? "Nova Venda (Não Salva)" : $"Venda #{_vendaAtual.Id}";
            lblSituacaoVenda.Text = $"Situação: {_vendaAtual.Status}";

            if(_vendaAtual.Status == VendaStatus.Efetivada)
                lblSituacaoVenda.Text += $" em {_vendaAtual.DataVenda?.ToString("dd/MM/yyyy HH:mm")}";

            if (_vendaAtual.DataCadastro != DateTime.MinValue)
                txtDataCadastro.Text = _vendaAtual.DataCadastro.ToString("dd/MM/yyyy HH:mm");

            bool podeEditar = _vendaAtual.Status == VendaStatus.Aberta;
            HabilitarControles(podeEditar);

            cmbCliente.Enabled = _vendaAtual.Itens.Count == 0 && podeEditar;
        }

        #endregion
    }
}