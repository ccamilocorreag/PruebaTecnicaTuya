using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuyaPagos.Application.Dtos.Facturacion;
using TuyaPagos.Domain.Interfaces;
using TuyaPagos.Infraestructure.Logging;

namespace TuyaPagos.Application.Services.Facturacion
{
    public class FacturacionAppService : BaseService, IFacturacionAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogService<FacturacionAppService> _logService;

        public FacturacionAppService(IUnitOfWork unitOfWork, ILogService<FacturacionAppService> logService) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _logService = logService;
        }

        public Task CrearFactura(FacturaInputDto facturaInput)
        {
            throw new NotImplementedException();
        }
    }
}
