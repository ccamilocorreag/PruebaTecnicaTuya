namespace TuyaPagos.Infraestructure.Exceptions
{
    public class DataException : BaseException
    {
        public DataException(string message) : base(message)
        {
        }

        public DataException(string message, Exception exception) : base(message, exception)
        {
        }
    }
}
