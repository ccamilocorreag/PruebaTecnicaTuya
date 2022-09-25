namespace TuyaPagos.Infraestructure.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
