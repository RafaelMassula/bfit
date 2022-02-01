using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public class AddressesServices
    {
        public static string GetZipCod(string ZipCod)
        {
            return Regex.Replace(ZipCod, @"[\-]", "");
        }
    }
}
