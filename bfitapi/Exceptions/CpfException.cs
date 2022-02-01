using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Exceptions
{
    public class CpfException : OperationException
    {
        public CpfException(string message) : base(message)
        {

        }
    }
}
