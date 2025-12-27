using Microsoft.Extensions.DependencyInjection; 
using System;
using System.Windows.Forms;
using TorinosERP.Application.Services;
using TorinosERP.Domain.Interfaces.Repositories;
using TorinosERP.Infra.Data.Context;
using TorinosERP.Infra.Data.Repositories;

namespace TorinosERP.WinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }
        
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();
            ConfigureServices(services);

            ServiceProvider = services.BuildServiceProvider();
            var formMenu = ServiceProvider.GetRequiredService<FrmMenu>();

            System.Windows.Forms.Application.Run(formMenu);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<DbSession>(provider => new DbSession());
            
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IVendaRepository, VendaRepository>();
            
            services.AddScoped<VendaService>();            

            services.AddTransient<FrmMenu>();
            
            services.AddTransient<FrmCadastroClientes>();
            services.AddTransient<FrmCadastroProdutos>();
            services.AddTransient<FrmVenda>();
            services.AddTransient<FrmPesquisarVendas>();
            services.AddTransient<FrmRelatorios>();
        }
    }
}