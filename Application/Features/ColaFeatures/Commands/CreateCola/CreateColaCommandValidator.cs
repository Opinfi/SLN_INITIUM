using FluentValidation;

namespace Application.Features.ColaFeatures.Commands.CreateCola
{
    public class CreateColaCommandValidator : AbstractValidator<CreateColaCommand>
    {
        public CreateColaCommandValidator()
        {
            RuleFor(x => x.Codigo)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .NotEmpty();
            //RuleFor(x => x.TiempoAtencion)
            //    .GreaterThan(0).WithMessage("El tiempo de atencion no debe ser 0");
        }

    }
}
