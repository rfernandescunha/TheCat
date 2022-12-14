using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCat.Domain.Entities
{
    public class LoggerRequest
    {
        public string ApplicationName { get; set; }
        public string Message { get; set; }
        public string InnerMessage { get; set; }
        public string StrackTrace { get; set; }

    }
}
