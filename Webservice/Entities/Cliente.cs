using System;

namespace Webservice.Entities
{
    public class Cliente
    {

        public int ClienteId { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public string CPF { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }

        public Cliente (int clienteId, string nome, string sobrenome, string cPF, DateTime dataNascimento, string email)
        {
            ClienteId = clienteId;
            Nome = nome;
            Sobrenome = sobrenome;
            CPF = cPF;
            DataNascimento = dataNascimento;
            Email = email;
        }
    }
}
