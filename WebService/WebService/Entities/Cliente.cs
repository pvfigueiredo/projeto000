using System;

namespace WebService.Entities
{
    public class Cliente : IEntity
    {
        public Guid Id { get; init; }
        public string? Nome { get; init; }
        public string? Sobrenome { get; init; }
        public string? CPF { get; init; }
        public DateTime DataNascimento { get; init; }
        public string? Email { get; init; }

        public Cliente() { }
        public Cliente (Guid clienteId, string nome, string sobrenome, string CPF, DateTime dataNascimento, string email)
        {
            this.Id = clienteId;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.CPF = CPF;
            this.DataNascimento = dataNascimento;
            this.Email = email;
        }
    }
}
