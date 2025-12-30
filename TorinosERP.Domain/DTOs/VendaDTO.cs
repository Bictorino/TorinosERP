using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TorinosERP.Domain.Enums;

namespace TorinosERP.Domain.DTOs
{
    public class VendaDTO
    {
        public class VendaFiltro
        {
            public int? ClienteId { get; set; } 
            public DateTime? DataCadastroInicio { get; set; }
            public DateTime? DataCadastroFim { get; set; }
            public DateTime? DataEfetivacaoInicio { get; set; }
            public DateTime? DataEfetivacaoFim { get; set; }
            public VendaStatus? Status { get; set; } 
        }

        public class VendaResultado
        {
            public int Id { get; set; }
            public string ClienteNome { get; set; }
            public DateTime DataCadastro { get; set; }
            public DateTime? DataVenda { get; set; } 
            public decimal ValorTotal { get; set; }
            public VendaStatus Status { get; set; }           
            public string StatusDescricao => Status.ToString();
        }             
    }

    public class VendaRelatorioGeral
    {
        public VendaRelatorioGeral() { }
        public string ClienteNome { get; set; }
        public string Status { get; set; }
        public int VendaId { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataCadastro { get; set; }
        public decimal TotalVenda { get; set; }
        public string ProdutoNome { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal SubtotalItem { get; set; }
    }
}
