using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.Entities;

namespace TorinosERP.Domain.Interfaces.Repositories
{
    public interface IClienteRepository
    {        
        Task<int> AdicionarAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodosAsync();
        Task<Cliente?> ObterPorIdAsync(int id);     
        Task AtualizarAsync(Cliente cliente);
        Task RemoverAsync(int id);
    }
}
