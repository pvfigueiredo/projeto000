using System.Collections.Generic;
using System.Linq.Expressions;
using Webservice.Entities;

namespace Webservice.Repositories
{
    public class ClientesRepository
    {
        private List<Cliente> _clientes;

        public ClientesRepository()
        {
            _clientes = new()
            {
                new Cliente(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0452af8"), "Paulo", "Figueiredo", "12345678901",DateTime.UtcNow, "paulo@email.com"),
                new Cliente(Guid.Parse("5370e311-7db2-454f-ace0-ae1257666288"), "Arthur", "Lima", "12345678901",DateTime.UtcNow, "arthur@email.com"),
                new Cliente(Guid.Parse("7889733a-b93a-4809-97ef-321d38acf4b9"), "Amanda", "Lima", "12345678901",DateTime.UtcNow, "amanda@email.com"),
                new Cliente(Guid.Parse("8171be86-ac02-46c5-b964-ba1e46a4d189"), "Steffania", "Lima", "12345678901",DateTime.UtcNow, "steffania@email.com")
            };
        }

        public List<Cliente> GetClientes()
        {
            return _clientes;
        }
        public Cliente? GetCliente(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new Cliente();
            }
            var cliente = _clientes.Where(c => id == c.ClienteId).FirstOrDefault();

            return cliente;
        }

        public Cliente SaveCliente(Cliente request)
        {
            var cliente = new Cliente() 
            {
                ClienteId = Guid.NewGuid(), 
                CPF = request.CPF, 
                DataNascimento = request.DataNascimento, 
                Email = request.Email, 
                Nome = request.Nome, 
                Sobrenome = request.Sobrenome
            };
            _clientes.Add(cliente);
            return cliente;
        }
        // criar update / chamar o get e chamar o save
        //outra opcao
    }
}
