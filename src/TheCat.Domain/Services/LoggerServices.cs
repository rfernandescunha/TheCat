using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Context;
using System;
using System.Threading.Tasks;
using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IServices;

namespace TheCat.Domain.Services
{
    public class LoggerServices:ILoggerServices
    {
        private readonly ILogger<LoggerServices> _logger;
        public LoggerServices(ILogger<LoggerServices> logger)
        {
            _logger = logger;
        }

        public async Task LogError(LoggerRequest request)
        {
            var date = DateTime.UtcNow;

            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("InnerMessage", request.Message))
            using (LogContext.PushProperty("StackTrace", request.Message))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() =>  
                    _logger.LogError($"Log Level: Error ApplicationName: {request.ApplicationName} LogMessage: {request.Message} InnerMessage: {request.InnerMessage} StackTrace: {request.StrackTrace} Date: {date}")
                    );
            }
        }

        public async Task LogInformation(LoggerRequest request)
        {
            var date = DateTime.UtcNow;

            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogInformation($"Log Level: Information ApplicationName: {request.ApplicationName} LogMessage: {request.Message} Date: {date}"));
            }
        }

        public async Task LogWarning(LoggerRequest request)
        {
            var date = DateTime.UtcNow;

            using (LogContext.PushProperty("ApplicationName", request.ApplicationName))
            using (LogContext.PushProperty("LogMessage", request.Message))
            using (LogContext.PushProperty("Date", date))
            {
                await Task.Run(() => _logger.LogWarning($"Log Level: Warning ApplicationName: {request.ApplicationName} LogMessage: {request.Message} Date: {date}"));
            }
        }
    }
}
