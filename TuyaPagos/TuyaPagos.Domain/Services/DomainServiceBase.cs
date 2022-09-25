using TuyaPagos.Domain.Interfaces;

namespace TuyaPagos.Domain.Services
{
    public class DomainServiceBase
    {
        public DomainServiceBase(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        protected internal IUnitOfWork UnitOfWork { get; set; }
    }
}
