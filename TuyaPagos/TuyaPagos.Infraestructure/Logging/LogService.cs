using Microsoft.Extensions.Logging;

namespace TuyaPagos.Infraestructure.Logging
{
    public class LogService<T> : ILogService<T>
    {
        public readonly ILogger<T> _logger;

        public LogService(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Log(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogError(string message, Exception exception)
        {
            _logger.LogError(message, exception);
        }
    }
}
