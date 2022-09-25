namespace TuyaPagos.Infraestructure.Exceptions
{
    public class BaseException: Exception
    {
        public BaseException(string message): base(message)
        {

        }

        public BaseException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
