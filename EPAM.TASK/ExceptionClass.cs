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
        public bool CheckPhone(string number)
        {
            if (!CheckCorrect(number))
            {
                if (!CheckLength(number))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckLength(string number)
        {
            if (number.Length != 8 || number.Length != 6)
            {             
                return false;
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
