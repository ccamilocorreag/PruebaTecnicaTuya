namespace TuyaPagos.Infraestructure.Logging
{
    public interface ILogService<T>
    {
        public void Log(string message);
        public void LogError(string message, Exception exception);
    }
}
