using FluentValidation;

namespace Application.Features.TicketFeatures.Commands
{
    public class CreateTicketCommandValidator : AbstractValidator<CreateTicketCommand>
    {
        public CreateTicketCommandValidator()
        {
            RuleFor(x => x.Identificacion).NotEmpty().NotEmpty()
                .WithMessage("Ingrese Identificación");
            RuleFor(x => x.Nombre).NotEmpty().NotEmpty()
                .WithMessage("Ingrese Nombre");
        }
    }
}
