namespace WebApp.Models
{
    public record UserNew
    {
        public string Name { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public byte Age { get; init; }
    }
}
