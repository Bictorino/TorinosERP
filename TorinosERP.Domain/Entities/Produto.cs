using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorinosERP.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int Estoque { get; private set; }

        public Produto(string nome, decimal preco, int estoque, string descricao = "")
        {
            Validar(nome, preco, estoque);
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Descricao = descricao;
        }

        protected Produto() { }

        public void Atualizar(string nome, decimal preco, int estoque ,string descricao)
        {
            Validar(nome, preco, this.Estoque);
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Descricao = descricao;
        }

        private void Validar(string nome, decimal preco, int estoque)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new Exception("Nome do produto é obrigatório.");
            if (preco <= 0) throw new Exception("Preço deve ser maior que zero.");
            if (estoque < 0) throw new Exception("Estoque não pode ser negativo.");
        }
    }
}
