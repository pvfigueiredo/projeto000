namespace WebService.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; init; }
        public string? Nome { get; init; }
        public string? Email { get; init; }
        public string? UserName { get; init; }
        public string? Senha { get; init; }

        public User() { }
        public User(Guid userId, string nome, string email, string userName, string senha)
        {
            this.Id = userId;
            this.Nome = nome;
            this.Email = email;
            this.UserName = userName;
            this.Senha = senha;
        }
    }
}