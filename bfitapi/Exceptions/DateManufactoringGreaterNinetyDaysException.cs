using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Exceptions
{
    public class DateManufactoringGreaterNinetyDaysException: Exception
    {
        public DateTime ManufactoringDate { get; }

        public DateManufactoringGreaterNinetyDaysException() { }
        public DateManufactoringGreaterNinetyDaysException(DateTime manufactoringDate) : this($"The manufactoring date {manufactoringDate.Date} is greater than ninetyn days.") 
        {
            ManufactoringDate = manufactoringDate;
        }
        public DateManufactoringGreaterNinetyDaysException(string message) : base(message) { }
    }
}
