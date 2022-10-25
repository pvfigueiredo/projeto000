using Microsoft.EntityFrameworkCore;
using WebService.Entities;

namespace WebService.Data
{
    public class SmartContext: DbContext
    {
        public SmartContext(DbContextOptions<SmartContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
    }
}
