using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    public class ExceptionClass
    {
        private const string Pattern = @"\+?\d{11}";

        public bool CheckPhone(string number)
        {
            if (!CheckPhoneWithRegex(number))
            {
                if (CheckLength(number))
                {
                    if (!CheckCorrect(number))
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckPhoneWithRegex(string number)
        {
            if(Regex.IsMatch(number, Pattern))
            {
                return true;
            }
            return false;
        }

        private bool CheckLength(string number)
        {
            if (number.Length != 11)
            {
                if (number.Length != 6)
                { 
                    return false;
                }
            }
            return true;
        }

        private bool CheckCorrect(string number)
        {
            string[] letters = number.Split();
            foreach (char item in number.ToCharArray())
            {
                if (!Char.IsDigit(item))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
