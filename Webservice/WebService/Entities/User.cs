namespace WebService.Entities
{
    public class User
    {
        public Guid UserId { get; init; }
        public string? Nome { get; init; }
        public string? Email { get; init; }
        public string? UserName { get; init; }
        public string? Senha { get; init; }

        public User() { }
        public User(Guid userId, string nome, string email, string userName, string senha)
        {
            this.UserId = userId;
            this.Nome = nome;
            this.Email = email;
            this.UserName = userName;
            this.Senha = senha;
        }
    }
}