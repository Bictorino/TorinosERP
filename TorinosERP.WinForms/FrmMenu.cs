using TorinosERP.Application.Services;
using Microsoft.Extensions.DependencyInjection; 
using System;
using System.Windows.Forms;

namespace TorinosERP.WinForms
{
    public partial class FrmMenu : Form
    {
        private readonly IServiceProvider _serviceProvider;

        public FrmMenu(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void toolstripVenda_Click(object sender, EventArgs e)
        {
            FrmVenda form = _serviceProvider.GetRequiredService<FrmVenda>();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void toolStripCadastroClientes_Click(object sender, EventArgs e)
        {
            FrmCadastroClientes form = _serviceProvider.GetRequiredService<FrmCadastroClientes>();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void toolStripCadastroProdutos_Click(object sender, EventArgs e)
        {
            FrmCadastroProdutos form = _serviceProvider.GetRequiredService<FrmCadastroProdutos>();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        private void toolStripRelatorios_Click(object sender, EventArgs e)
        {
            FrmRelatorios form = _serviceProvider.GetRequiredService<FrmRelatorios>();
            form.StartPosition = FormStartPosition.CenterParent;
            form.ShowDialog();
        }

        // Exemplo de uso num botão futuro:
        // private void btnTeste_Click(object sender, EventArgs e)
        // {
        //      _vendaService.FazerAlgo();
        // }
    }
}
