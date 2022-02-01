using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Exceptions
{
    public class OperationException: Exception
    {
        public OperationException()
        {
        }
        public OperationException(string message) : base(message)
        {
        }
    }
}
