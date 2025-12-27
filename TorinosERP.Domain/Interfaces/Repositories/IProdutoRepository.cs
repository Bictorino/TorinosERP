using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.Entities;

namespace TorinosERP.Domain.Interfaces.Repositories
{
    public interface IProdutoRepository
    {
        Task<int> AdicionarAsync(Produto produto);
        Task<IEnumerable<Produto>> ObterTodosAsync();
        Task<Produto> ObterPorIdAsync(int id);
        Task AtualizarAsync(Produto produto);
        Task RemoverAsync(int id);
        Task BaixarEstoqueAsync(int produtoId, int quantidade);
    }
}
