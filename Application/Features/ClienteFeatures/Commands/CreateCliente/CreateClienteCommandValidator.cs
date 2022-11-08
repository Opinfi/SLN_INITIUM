using FluentValidation;

namespace Application.Features.ClienteFeatures.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(x => x.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.Identificacion)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
        }

    }
}
