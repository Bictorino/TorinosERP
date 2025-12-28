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
        public class FiltroVendaDto
        {
            public int? ClienteId { get; set; } 
            public DateTime? DataCadastroInicio { get; set; }
            public DateTime? DataCadastroFim { get; set; }
            public DateTime? DataEfetivacaoInicio { get; set; }
            public DateTime? DataEfetivacaoFim { get; set; }
            public VendaStatus? Status { get; set; } 
        }

        public class VendaResultadoDto
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
}
