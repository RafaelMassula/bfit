using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public abstract class Services<T>
    {
        public abstract Task CheckExistenceOfRecord(T obj);
    }
}


