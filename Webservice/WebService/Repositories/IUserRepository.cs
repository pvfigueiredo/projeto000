using Webservice.Entities;
using WebService.Entities;

namespace Webservice.Repositories
{
    public interface IUserRepository
    {
        bool DeleteUser(Guid id);
        User GetUser(Guid id);
        List<User> GetUser();
        User SaveUser(User request);
        void UpdateUser(User user);
    }
}