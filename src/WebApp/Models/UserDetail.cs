namespace WebApp.Models
{
    public record UserDetail
    {
        public long Id { get; init; }
        public string FullName { get; init; }
        public string Email { get; init; }
        public string Login { get; init; }
        public byte Age { get; init; }

        public static UserDetail MapFrom(Domain.Entities.User domainUser) =>
            new()
            {
                Id = domainUser.Id,
                FullName = $"{domainUser.Name} {domainUser.LastName}",
                Email = domainUser.Email,
                Login = domainUser.Login,
                Age = domainUser.Age
            };
    }
}
