using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    /// <summary>
    /// Class Person is usual class there the human data are registered.
    /// </summary>
    public class Person
    {
        private ExceptionClass exception = new ExceptionClass();
    
        private int yearOfBirth;
        private string phone;

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Person()
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="age"></param>
        /// <param name="phonenumber"></param>
        public Person(int id, string firstName, string lastName, int age, string phonenumber)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = age;
            Phone = phonenumber;
        }

        private int ID { get; set; }

        private string FirstName { get; set; }

        private string LastName { get; set; }

        private int YearOfBirth
        {
            get
            {
                return yearOfBirth;
            }
            set
            {
                if(value < 1900 || value > DateTime.Now.Year)
                {
                    throw new Exception($"Wrong year");
                }
                else
                {
                    yearOfBirth = value;
                }
            }
        }

        private string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                if (exception.CheckPhone(value))
                {
                    phone = value;
                }
                else
                {
                    throw new Exception($"Wrong phonenumber");
                }
            }
        }

        /// <summary>
        /// Override method for output data.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{ID} : {LastName} : {FirstName} : {YearOfBirth} : {Phone}\r{Environment.NewLine}";
        }
    }
}
