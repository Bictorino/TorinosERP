using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorinosERP.Domain.Entities
{
    public class VendaItem
    {
        public int Id { get; private set; }
        public int VendaId { get; private set; }
        public int ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; } 
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }        
        public decimal Subtotal => Quantidade * PrecoUnitario;

        public VendaItem(int produtoId, string produtoNome, int quantidade, decimal precoUnitario)
        {
            if (quantidade <= 0) throw new Exception("Quantidade deve ser maior que zero.");
            if (precoUnitario < 0) throw new Exception("Preço não pode ser negativo.");

            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
        
        public void AssociarVenda(int vendaId)
        {
            VendaId = vendaId;
        }
    }
}
