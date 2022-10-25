using System.Linq;
using WebService.Entities;
using WebService.Data;
using WebService.Repositories;

namespace WebService.DTO
{
    public class ClienteDTO 
    {
        public Guid Id { get; init; }
        public string? NomeCompleto { get; init; }
        public string? CPF { get; init; }
        public int Idade { get; init; }
        public string? Email { get; init; }
    }
}
