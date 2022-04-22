using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsAWS.Infra.Data.Context
{
    public class ProcessedMessage
    {
        public ProcessedMessage(string message, bool hasErrors = false)
        {
            TimeStamp = DateTime.UtcNow;

            Message = message;
            HasErrors = hasErrors;
        }

        public DateTime TimeStamp { get; set; }
        public string Message { get; set; }
        public bool HasErrors { get; set; }
    }
}
