using System.Collections.Generic;
using System.Linq.Expressions;
using WebService.Entities;

namespace WebService.Repositories
{
    public class MockClienteRepository : IRepository
    {
        private List<IEntity> repository;
        public MockClienteRepository()
        {            
            repository = new List<IEntity>();
            repository.Add(new Cliente(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0452af8"), "Paulo", "Figueiredo", "12345678901", DateTime.Parse("04/06/1986"), "paulo@email.com")); 
            repository.Add(new Cliente(Guid.Parse("5370e311-7db2-454f-ace0-ae1257666288"), "Arthur", "Lima", "12345678901", DateTime.UtcNow, "arthur@email.com")); 
            repository.Add(new Cliente(Guid.Parse("7889733a-b93a-4809-97ef-321d38acf4b9"), "Amanda", "Lima", "12345678901", DateTime.Parse("24/03/1994"), "amanda@email.com")); 
            repository.Add(new Cliente(Guid.Parse("8171be86-ac02-46c5-b964-ba1e46a4d189"), "Steffania", "Lima", "12345678901", DateTime.UtcNow, "steffania@email.com"));
        }

        public void Add(IEntity entity)
        {          
            repository.Add(entity);
        }

        public void Delete(IEntity entity)
        {
            repository.Remove(entity);
        }

        public IEntity Get(Guid id)
        {
            var result = repository.FirstOrDefault(c => c.Id == id);
            return result;
        }

        public IEnumerable<IEntity> GetAll()
        {
            return repository;
        }

        public void Update(IEntity entity)
        {
            var index = repository.IndexOf(entity);
            repository[index] = entity;
        }
    }
}
