using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCat.Application.ViewModels.Logger;
using TheCat.Domain.Entities;

namespace TheCat.Application.Interfaces
{
    public interface ILoggerAppServices
    {
        Task LogInformation(LoggerRequestViewModel request);
        Task LogWarning(LoggerRequestViewModel request);
        Task LogError(LoggerRequestViewModel request);
    }
}
