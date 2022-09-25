using FluentValidation;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Domain.Shared;

namespace TuyaPagos.WebApi.ValidationsModels
{
    public class FacturaInputValidator : AbstractValidator<FacturaInputDto>
    {
        public FacturaInputValidator()
        {
            RuleFor(x => x.Cedula).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(5, 10);
            RuleFor(x => x.Nombres).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(2, 60);
            RuleFor(x => x.Apellidos).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(2, 60);
            RuleFor(x => x.DetalleFactura).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO);
            RuleForEach(x => x.DetalleFactura).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO);
        }
    }
}
