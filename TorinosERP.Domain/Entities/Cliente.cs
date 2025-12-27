using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorinosERP.Domain.Entities
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }

        public Cliente(string nome, string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome é obrigatório.");
            if (string.IsNullOrWhiteSpace(email))
                throw new Exception("E-mail é obrigatório.");

            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        protected Cliente() { }

        public void AtualizarDados(string nome, string email, string telefone)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome é obrigatório.");

            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }
}
