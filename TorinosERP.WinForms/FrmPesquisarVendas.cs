using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorinosERP.Domain.DTOs;
using TorinosERP.Domain.Enums;
using TorinosERP.Domain.Interfaces.Repositories;

namespace TorinosERP.WinForms
{
    public partial class FrmPesquisarVendas : Form
    {
        private readonly IVendaRepository _vendaRepo;
        private readonly IClienteRepository _clienteRepo;

        public int IdSelecionado { get; private set; }

        public FrmPesquisarVendas(IVendaRepository vendaRepo, IClienteRepository clienteRepo)
        {
            InitializeComponent();
            _vendaRepo = vendaRepo;
            _clienteRepo = clienteRepo;

            ConfigurarGrid();
        }

        private async void FrmPesquisarVendas_Load(object sender, EventArgs e)
        {
            await CarregarCombos();
            LimparFiltros();
        }

        private void ConfigurarGrid()
        {
            dgvPesquisa.AutoGenerateColumns = false;
            dgvPesquisa.CellDoubleClick += (s, e) => SelecionarVenda();
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

                cmbStatusVenda.DataSource = Enum.GetValues(typeof(VendaStatus));
                cmbStatusVenda.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar filtros: {ex.Message}");
            }
        }

        private void LimparFiltros()
        {
            cmbCliente.SelectedIndex = -1;
            cmbStatusVenda.SelectedIndex = -1;

            dtInicial.Value = DateTime.Today.AddDays(-30);
            dtFinal.Value = DateTime.Today;


            rdbDataCadastro.Checked = true;
            dgvPesquisa.DataSource = null;
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                btnPesquisar.Enabled = false;

                #pragma warning disable CS8605
                var filtro = new VendaDTO.FiltroVendaDto
                {
                    ClienteId = cmbCliente.SelectedIndex != -1 ? (int)cmbCliente.SelectedValue : null,
                    Status = cmbStatusVenda.SelectedIndex != -1 ? (VendaStatus)cmbStatusVenda.SelectedItem : null
                };
                #pragma warning restore CS8605

                if (rdbDataCadastro.Checked)
                {
                    filtro.DataCadastroInicio = dtInicial.Value;
                    filtro.DataCadastroFim = dtFinal.Value;
                }
                else if (rdbDataVenda.Checked)
                {
                    filtro.DataEfetivacaoInicio = dtInicial.Value;
                    filtro.DataEfetivacaoFim = dtFinal.Value;
                }

                var resultados = await _vendaRepo.PesquisarAsync(filtro);

                dgvPesquisa.DataSource = resultados.ToList();

                if (!resultados.Any())
                {                    
                    lblStatus.Text = "Nenhum registro encontrado.";
                    lblTotalRegistros.Text = "Total Registros: 0";
                }
                else
                {
                    lblStatus.Text = "";
                    lblTotalRegistros.Text = $"Total Registros: {dgvPesquisa.Rows.Count}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na pesquisa: {ex.Message}");
            }
            finally
            {
                btnPesquisar.Enabled = true;                
            }
        }

        private void SelecionarVenda()
        {
            if (dgvPesquisa.CurrentRow?.DataBoundItem is VendaDTO.VendaResultadoDto vendaSelecionada)
            {
                IdSelecionado = vendaSelecionada.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}