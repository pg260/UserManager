using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using FluentValidation.Validators;
using Manager.Domain.Entities;

namespace Manager.Domain.Validators;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(x => x)
            .NotEmpty()
            .WithMessage("A entidade não pode ser vazia.")
            
            .NotNull()
            .WithMessage("A entidade não pode ser nula.");

        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage("O nome não pode ser nulo.")

            .NotEmpty()
            .WithMessage("O nome não pode ser vazio")

            .MinimumLength(3)
            .WithMessage("O nome deve ter no mínimo 3 caracteres.")

            .MaximumLength(80)
            .WithMessage("O nome deve ter no máximo 80 caracteres.");

        RuleFor(x => x.Email)
            .NotNull()
            .WithMessage("O email não pode ser nulo")

            .NotEmpty()
            .WithMessage("O email não pode ser vazio")

            .MinimumLength(10)
            .WithMessage("Email inválido")

            .MaximumLength(180)
            .WithMessage("Email inválido")

            .Matches(
                @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")
            .WithMessage("Email inválido");

        RuleFor(x => x.Password)
            .NotNull()
            .WithMessage("A senha não pode ser nula")

            .NotEmpty()
            .WithMessage("A senha não pode ser vazia")

            .MinimumLength(6)
            .WithMessage("A senha deve conter mais de 6 caracteres")

            .MaximumLength(30)
            .WithMessage("A senha deve conter no máximo 30 caracteres");
    }
}