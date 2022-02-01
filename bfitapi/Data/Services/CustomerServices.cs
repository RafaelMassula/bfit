using bfitapi.Exceptions;
using bfitapi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace bfitapi.Data.Services
{
    public class CustomerServices
    {
        private readonly static List<string> _invalidNumbersOfCpf = new List<string>
        {
                "000.000.000-00",
                "111.111.111-11",
                "222.222.222-22",
                "333.333.333-33",
                "444.444.444-44",
                "555.555.555-55",
                "666.666.666-66",
                "777.777.777-77",
                "888.888.888-88",
                "999.999.999-99"
        };

        public static void CheckedEmail(string email)
        {

        }
        public static void CheckedBirthDate(DateTime birthDate)
        {
            int yearCurrent = DateTime.Now.Year;
            int year = birthDate.Year;
            int yearsOldValid = 18;
            int yearsOld = yearCurrent - birthDate.Year;

            if (DateTime.Now.DayOfYear < birthDate.DayOfYear)
                yearsOld -= 1;
            if (yearsOld < yearsOldValid)
                throw new BirthDateException($"Sale unauthorized for clients minors 18 years old.");
            if (year > yearCurrent)
                throw new BirthDateException();
            if (DateTime.Now.Date.Equals(birthDate))
                throw new BirthDateException();

        }
        public static void CheckedCpf(string cpf)
        {
            if (_invalidNumbersOfCpf.Contains(cpf))
            {
                throw new CpfException("Invalid cpf.");
            }
            CheckDigit(TransformCpf(cpf));
        }
        private static void CheckDigit(int[] cpf)
        {
            for (int l = 2; l > 0; l--)
            {
                int result = 0;
                int initialMultiplier = 2;
                for (int i = l; i < cpf.Length; i++)
                {
                    result += cpf[i] * initialMultiplier;
                    initialMultiplier++;
                }
                result = (result * 10) % cpf.Length;

                int digit = result == 10 ? 0 : result;
                if (digit == cpf[l - 1])
                {
                    continue;
                }
                else
                {
                    throw new CpfException("Invalid cpf.");
                }
            }
        }
        private static int[] TransformCpf(string cpf)
        {
            string pattern = @"[A-Za-z-\W]+";
            char[] charOfCpf = Regex.Replace(cpf, pattern, "").ToArray();
            int[] invertedCPf = new int[11];

            for (int i = 0; i < charOfCpf.Length; i++)
            {
                int position = (charOfCpf.Length - 1) - i;

                invertedCPf[i] = int.Parse(charOfCpf[position].ToString());
            }
            return invertedCPf;
        }
    }
}

