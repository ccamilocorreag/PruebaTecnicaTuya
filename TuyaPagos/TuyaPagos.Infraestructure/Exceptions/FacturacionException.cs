namespace TuyaPagos.Infraestructure.Exceptions
{
    public class FacturacionException: BaseException
    {
        public FacturacionException(string message) : base(message)
        {

        }

        public FacturacionException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
