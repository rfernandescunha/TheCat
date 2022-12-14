using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCat.Domain.Entities;

namespace TheCat.Domain.Interfaces.IServices
{
    public interface ILoggerServices
    {
        Task LogInformation(LoggerRequest request);
        Task LogWarning(LoggerRequest request);
        Task LogError(LoggerRequest request);
    }
}
