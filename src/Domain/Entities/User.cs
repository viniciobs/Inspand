using Domain.Extensions;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User : Entity<User>
    {
        public User()
        {
            const byte StringMaxLength = 255;
            const string MaxLengthErrorMessage = "O {0} é obrigatório e deve ter até {1} caracteres";
            const string RequiredErrorMessage = "O {0} é obrigatório";

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MaximumLength(StringMaxLength)
                .WithMessage(string.Format(MaxLengthErrorMessage, this.GetDisplayName(nameof(Name)), StringMaxLength));

            RuleFor(x => x.LastName)
                .NotNull()
                .NotEmpty()
                .MaximumLength(StringMaxLength)
                .WithMessage(string.Format(MaxLengthErrorMessage, this.GetDisplayName(nameof(LastName)), StringMaxLength));

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(StringMaxLength)
                .WithMessage(string.Format(MaxLengthErrorMessage, this.GetDisplayName(nameof(Email)), StringMaxLength));

            RuleFor(x => x.Login)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(RequiredErrorMessage, this.GetDisplayName(nameof(Login))));

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage(string.Format(RequiredErrorMessage, this.GetDisplayName(nameof(Password))));

            RuleFor(x => x.Age)
                .GreaterThan(byte.MinValue)
                .WithMessage(string.Format(RequiredErrorMessage, this.GetDisplayName(nameof(Password))));
        }

        [Display(Name = "Nome")]
        public string Name { get; init; }

        [Display(Name = "Sobrenome")]
        public string LastName { get; init; }

        [Display(Name = "E-mail")]
        public string Email { get; init; }

        [Display(Name = "Login")]
        public string Login { get; init; }

        [Display(Name = "Senha")]
        public string Password { get; init; }

        [Display(Name = "Idade")]
        public byte Age { get; init; }

        public override bool IsValid() =>
            Validate(this).IsValid;
    }
}
