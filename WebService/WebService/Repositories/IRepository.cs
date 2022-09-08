using WebService.Entities;

namespace WebService.Repositories
{
    public interface IRepository
    {
        void DeleteCliente(Guid id);
        Cliente? GetCliente(Guid id);
        List<Cliente>? GetClientes();
        Cliente? SaveCliente(Cliente request);
        void UpdateCliente(Cliente cliente);
    }
}