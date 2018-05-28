using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    /// <summary>
    /// Class ExceprionClass works with phonenumber.
    /// </summary>
    public class ExceptionClass
    {
        /// <summary>
        /// Private constant <seealso cref="PatternForPhone"/> is used to save regex. 
        /// </summary>
        private const string PatternForPhone = @"\+?\d{11}";

        private const string PatternForPath = @"[A-Z]{1}:(\\[A-Za-z0-9]*)*";

        /// <summary>
        /// Main method <seealso cref="CheckPhone(string)"/> is used for full check phonenumber.
        /// He uses other methods as <seealso cref="CheckCorrect(string)"/>,
        /// <seealso cref="CheckLength(string)"/> and
        /// <seealso cref="CheckPhoneWithRegex(string)"/>
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method CheckPathToFile checks path to file using pattern
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool CheckPathToFile(string path)
        {
            if(Regex.IsMatch(path, PatternForPath) && !String.IsNullOrEmpty(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method <seealso cref="CheckPhoneWithRegex(string)"/> checks phonenumber using regex
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private bool CheckPhoneWithRegex(string number)
        {
            if (Regex.IsMatch(number, PatternForPhone))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method <seealso cref="CheckLength(string)"/> checks phonenumber's length
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Method <seealso cref="CheckCorrect(string)"/> checks phonenumber for correctness.
        /// All char must be digit
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
