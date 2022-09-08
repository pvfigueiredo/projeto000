using System.Collections.Generic;
using System.Linq.Expressions;
using Webservice.Entities;
using WebService.Entities;

namespace Webservice.Repositories
{
    public class UserRepository
    {
        private List<User> _users;

        public UserRepository()
        {
            _users = new()
            {
                new User(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0452af8"), "Paulo", "paulo@email.com", "Paulo", "123"),
                new User(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0746867"), "Arthur", "arthur@email.com", "arthur", "123"),
                new User(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0238759"), "Amanda", "amanda@email.com", "amanda", "123"),
                new User(Guid.Parse("7a775e1a-3344-4eb3-a04b-cec9a0175390"), "Steffania", "steffania@email.com", "steffania", "123"),
            };
        }

        public List<User> GetUser()
        {
            return _users;
        }
        public User? GetUser(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new User();
            }
            var user = _users.Where(u => id == u.UserId).FirstOrDefault();

            return user;
        }

        public User SaveUser(User request)
        {
            var user = new User()
            {
                UserId = Guid.NewGuid(),
                Nome = request.Nome,
                Email = request.Email,
                UserName = request.UserName,
                Senha = request.Senha,
            };
            _users.Add(user);
            return user;
        }
        // criar update / chamar o get e chamar o save
        //outra opcao
    }
}
