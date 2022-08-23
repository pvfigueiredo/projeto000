using System;

namespace Webservice.Entities
{
    public class Cliente
    {

        public Guid ClienteId { get; init; }
        public string? Nome { get; init; }
        public string? Sobrenome { get; init; }
        public string? CPF { get; init; }
        public DateTime DataNascimento { get; init; }
        public string? Email { get; init; }

        public Cliente() { }
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
