using System;

namespace Webservice.Model
{
    public class Cliente
    {
        public Guid ClienteID { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string CPF { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
