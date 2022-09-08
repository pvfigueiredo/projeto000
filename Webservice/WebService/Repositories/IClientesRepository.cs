using Webservice.Entities;

namespace Webservice.Repositories
{
    public interface IClientesRepository
    {
        bool DeleteCliente(Guid id);
        Cliente GetCliente(Guid id);
        List<Cliente> GetClientes();
        Cliente SaveCliente(Cliente request);
        void UpdateCliente(Cliente cliente);
    }
}