using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    public class Person
    {
        private ExceptionClass exception = new ExceptionClass();
    
        private int yearOfBirth;
        private string phone;

        public Person()
        {

        }

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

        public override string ToString()
        {
            return $"{ID} : {LastName} : {FirstName} : {YearOfBirth} : {Phone}\r{Environment.NewLine}";
        }
    }
}
