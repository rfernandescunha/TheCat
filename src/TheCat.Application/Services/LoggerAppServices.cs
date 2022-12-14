
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheCat.Application.Interfaces;
using TheCat.Application.ViewModels.Logger;
using TheCat.Domain.Entities;
using TheCat.Domain.Interfaces.IServices;

namespace TheCat.Application.Services
{
    public class LoggerAppServices: ILoggerAppServices
    {
        private readonly ILoggerServices _loggerServices;
        private readonly IMapper _mapper;

        public LoggerAppServices(ILoggerServices loggerServices, IMapper mapper)
        {
            _loggerServices = loggerServices;
            _mapper = mapper;
        }

        public async Task LogError(LoggerRequestViewModel request)
        {
            var entrada = _mapper.Map<LoggerRequest>(request);

            await _loggerServices.LogError(entrada);
        }

        public async Task LogInformation(LoggerRequestViewModel request)
        {
            var entrada = _mapper.Map<LoggerRequest>(request);

            await _loggerServices.LogInformation(entrada);
        }

        public async Task LogWarning(LoggerRequestViewModel request)
        {
            var entrada = _mapper.Map<LoggerRequest>(request);

            await _loggerServices.LogWarning(entrada);
        }
    }
}
