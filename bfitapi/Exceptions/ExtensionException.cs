using System;
using System.Runtime.Serialization;

namespace bfitapi.Exceptions
{
    internal class ExtensionException : OperationException
    {
        public ExtensionException() { }
        public ExtensionException(string message) : base(message)
        {

        }
    }
}