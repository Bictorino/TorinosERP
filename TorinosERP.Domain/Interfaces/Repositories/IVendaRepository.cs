using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.DTOs;
using TorinosERP.Domain.Entities;

namespace TorinosERP.Domain.Interfaces.Repositories
{
    public interface IVendaRepository
    {

        Task<int> AdicionarAsync(Venda venda);
        Task AtualizarAsync(Venda venda); 
        Task AdicionarItemAsync(VendaItem item);
        Task RemoverItensDaVendaAsync(int vendaId); 
        Task<Venda?> ObterPorIdAsync(int id);
        Task RemoverItemAsync(int idItem);
        Task<IEnumerable<VendaItem>> ObterItensDaVendaAsync(int vendaId);
        Task<IEnumerable<VendaDTO.VendaResultado>> PesquisarAsync(VendaDTO.VendaFiltro filtro);
        Task<IEnumerable<VendaRelatorioGeral>> ObterDadosRelatorioAsync(
            int? clienteId,
            int? statusId,
            DateTime dataInicial,
            DateTime dataFinal,
            bool filtrarPorDataVenda
        );

    }
}
