using WebService.Entities;

namespace WebService.Repositories
{
    public interface IRepository
    {
        void Add(IEntity entity);
        void Delete(IEntity entity);
        void Update(IEntity entity);
        IEntity Get(Guid id);
        IEnumerable<IEntity> GetAll();
    }
}