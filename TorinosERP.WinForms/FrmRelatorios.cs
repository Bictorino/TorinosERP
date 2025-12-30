using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TorinosERP.Domain.Enums;
using TorinosERP.Domain.Interfaces.Repositories;

namespace TorinosERP.WinForms
{
    public partial class FrmRelatorios : Form
    {        
        private ReportViewer reportViewer1;
        
        private readonly IVendaRepository _vendaRepo;
        private readonly IClienteRepository _clienteRepo;
        
        public FrmRelatorios(IVendaRepository vendaRepo, IClienteRepository clienteRepo)
        {
            InitializeComponent();
            _vendaRepo = vendaRepo;
            _clienteRepo = clienteRepo;
            
            this.AcceptButton = btnPesquisar;
        }
       
        private void FrmRelatorios_Load(object sender, EventArgs e)
        {
            ConfigurarReportViewer();
            CarregarCombos();
            
            dtInicial.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtFinal.Value = DateTime.Now;
            
            rdbDataVenda.Checked = true;
        }

        private void ConfigurarReportViewer()
        {
            this.reportViewer1 = new ReportViewer();            
            this.reportViewer1.Dock = DockStyle.Fill;
            this.reportViewer1.ShowToolBar = true;
            this.reportViewer1.ShowPageNavigationControls = true;
            this.reportViewer1.ShowZoomControl = true;
            
            this.reportViewer1.ProcessingMode = ProcessingMode.Local;            
            this.pnlReportViewer.Controls.Add(this.reportViewer1);

            this.reportViewer1.RefreshReport();
        }

        private async void CarregarCombos()
        {
            try
            {
                var clientes = await _clienteRepo.ObterTodosAsync();
                var listaClientes = new List<dynamic>
                {
                    new { Id = -1, Nome = "Todos" }
                };

                foreach (var c in clientes)
                {
                    listaClientes.Add(new { Id = c.Id, Nome = c.Nome });
                }

                cmbCliente.DataSource = listaClientes;
                cmbCliente.DisplayMember = "Nome";
                cmbCliente.ValueMember = "Id";

                var listaStatus = new List<dynamic>
                {
                    new { Id = -1, Nome = "Todos" }
                };

                foreach (VendaStatus status in Enum.GetValues(typeof(VendaStatus)))
                {
                    listaStatus.Add(new { Id = (int)status, Nome = status.ToString() });
                }

                cmbStatusVenda.DataSource = listaStatus;
                cmbStatusVenda.DisplayMember = "Nome";
                cmbStatusVenda.ValueMember = "Id";
                cmbStatusVenda.SelectedValue = (int)VendaStatus.Efetivada;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar filtros: {ex.Message}");
            }
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                int? clienteId = null;
                if (cmbCliente.SelectedValue != null && (int)cmbCliente.SelectedValue > 0)
                {
                    clienteId = (int)cmbCliente.SelectedValue;
                }

                int? statusId = null;
                if (cmbStatusVenda.SelectedValue != null && (int)cmbStatusVenda.SelectedValue >= 0)
                {
                    statusId = (int)cmbStatusVenda.SelectedValue;
                }

                bool filtrarPorVenda = rdbDataVenda.Checked;

                var dados = await _vendaRepo.ObterDadosRelatorioAsync(
                    clienteId,
                    statusId,
                    dtInicial.Value, 
                    dtFinal.Value,   
                    filtrarPorVenda
                );

                if (!dados.Any())
                {
                    MessageBox.Show("Nenhum registro encontrado para os filtros selecionados.");
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.RefreshReport();
                    return;
                }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportPath = "Relatorios\\VendaResumido.rdlc";

                var rds = new ReportDataSource("dsVendasGeral", dados);

                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}