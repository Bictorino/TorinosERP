using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.Enums;

namespace TorinosERP.Domain.Entities
{
    public class Venda
    {
        public int Id { get; private set; }
        public int ClienteId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime? DataVenda { get; private set; }
        public decimal ValorTotal { get; private set; }
        public VendaStatus Status { get; private set; }

        private readonly List<VendaItem> _itens = new List<VendaItem>();
        public IReadOnlyCollection<VendaItem> Itens => _itens.AsReadOnly();

        public Venda(int clienteId)
        {
            if (clienteId <= 0) throw new Exception("Cliente inválido.");

            ClienteId = clienteId;
            Status = VendaStatus.Aberta;
            ValorTotal = 0;
        }

        protected Venda() { }

        public void AdicionarItem(VendaItem item)
        {
            if (Status != VendaStatus.Aberta)
                throw new Exception("Não é possível adicionar itens a uma venda já finalizada.");

            _itens.Add(item);
            CalcularTotal();
        }
        public void RemoverItem(VendaItem item)
        {
            if (Status != VendaStatus.Aberta)
                throw new Exception("Não é possível remover itens de uma venda já finalizada.");

            _itens.Remove(item);
            CalcularTotal();
        }
        public void Efetivar()
        {
            if (Status != VendaStatus.Aberta)
                throw new Exception("Esta venda já foi processada.");

            if (!_itens.Any())
                throw new Exception("Não é possível efetivar uma venda sem itens.");

            Status = VendaStatus.Efetivada;
            DataVenda = DateTime.Now; 
        }

        public void Cancelar()
        {
            Status = VendaStatus.Cancelada;
        }

        private void CalcularTotal()
        {
            ValorTotal = _itens.Sum(i => i.Subtotal);
        }

        public void ConfirmarVenda(int id, DateTime dataCadastro, DateTime? dataVenda, VendaStatus status)
        {
            Id = id;
            DataCadastro = dataCadastro;
            DataVenda = dataVenda;
            Status = status;
        }

        public void Reabrir()
        {
            if (Status != VendaStatus.Efetivada)
                throw new Exception("Apenas vendas efetivadas podem ser reabertas.");

            Status = VendaStatus.Aberta;
            DataVenda = null; 
        }

        public void CarregarItens(IEnumerable<VendaItem> itensDoBanco)
        {
            _itens.AddRange(itensDoBanco);
            CalcularTotal();
        }        
    }
}
