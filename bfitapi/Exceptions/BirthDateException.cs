﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Exceptions
{
    public class BirthDateException : OperationException
    {
        public DateTime BirthDate { get; }

        public BirthDateException() { }
        public BirthDateException(DateTime birthDate) : this($"The birth date {birthDate.Date} is invalid.")
        {
            BirthDate = birthDate;
        }
        public BirthDateException(string message) : base(message) { }
    }
}
