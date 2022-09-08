using WebService.Data;
using WebService.Entities;

namespace WebService.Repositories
{
    public class Repository: IRepository
    {
        public Repository(SmartContext context)
        {
            if (context is null) { throw new ArgumentNullException("context"); }
            if (context.Clientes is null) { throw new ArgumentNullException("Cliente é null"); }
            Context = context;
        }

        public SmartContext Context { get; }

        public void DeleteCliente(Guid id)
        {
            var cliente = Context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            if (cliente is null)
            {
                throw new Exception("Cliente não encontrado");
            }
            Context.Clientes.Remove(cliente);
            Context.SaveChanges();
        }

        public Cliente? GetCliente(Guid id)
        {
            var cliente = Context.Clientes.FirstOrDefault(c => c.ClienteId == id);
            return cliente;
        }

        public List<Cliente>? GetClientes() => Context.Clientes.ToList();

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
            Context.Clientes.Add(cliente);
            Context.SaveChanges();
            return cliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            if (Context.Clientes.FirstOrDefault(c => c.ClienteId == cliente.ClienteId) is null)
            {
                throw new Exception("Cliente não existe!");
            }
            Context.Clientes.Update(cliente);
            Context.SaveChanges();
        }
    }
}

