using FluentValidation;
using TuyaPagos.Application.Dtos.Pedidos;
using TuyaPagos.Domain.Shared;

namespace TuyaPagos.WebApi.ValidationsModels
{
    public class PedidoInputValidator : AbstractValidator<PedidoInputDto>
    {
        public PedidoInputValidator()
        {
            RuleFor(x => x.FacturaId).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO);
            RuleFor(x => x.Direccion).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(10, 150);
            RuleFor(x => x.Ciudad).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(2, 60);
            RuleFor(x => x.Departamento).NotNull().WithMessage(Constants.ErrorMessages.CAMPO_REQUERIDO)
                .Length(2, 60);
        }
    }
}
