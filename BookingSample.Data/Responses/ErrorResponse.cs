using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSample.Data.Responses
{
    public class ErrorResponse : Exception
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public ErrorResponse(int errorCode, string message)
        {

            Message = message;
            Code = errorCode;
        }
    }
}
