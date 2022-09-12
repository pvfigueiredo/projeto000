using WebService.Data;
using WebService.Entities;

namespace WebService.Repositories
{
    public class ClienteRepository: IRepository
    {
        public ClienteRepository(SmartContext context)
        {
            if (context is null) { throw new ArgumentNullException("context"); }
            if (context.Clientes is null) { throw new ArgumentNullException("Cliente é null"); }
            Context = context;
        }

        public SmartContext Context { get; }

        public void Add(IEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }
        public void Delete(IEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(IEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        public IEntity Get(Guid id)
        {
            var cliente = Context.Clientes.FirstOrDefault(c => c.Id == id);
            return cliente;
        }

        public IEnumerable<IEntity> GetAll() => Context.Clientes.ToList();

    }
}

