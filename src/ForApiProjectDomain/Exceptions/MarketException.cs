using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForApiProjectDomain.Exceptions
{
    public class MarketException : Exception
    {
        public int StatusCode { get; set; }

        public string Message { get; set; }
        
        public MarketException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
}
