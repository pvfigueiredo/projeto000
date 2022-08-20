using System;

namespace Webservice.Entities
{
    public class Cliente
    {

        public Guid ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }

        public Cliente (Guid clienteId, string nome, string sobrenome, string CPF, DateTime dataNascimento, string email)
        {
            this.ClienteId = clienteId;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CPF = CPF;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }
    }
}
