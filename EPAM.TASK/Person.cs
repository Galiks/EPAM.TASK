using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    class Person
    {
        ExceptionClass exception = new ExceptionClass();
    
        int yearOfBirth;
        string phone;

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

        int ID { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        int YearOfBirth
        {
            get
            {
                return yearOfBirth;
            }
            set
            {
                if(value < 1900 && value > DateTime.Now.Year)
                {
                    throw new Exception($"Wrong year");
                }
                else
                {
                    yearOfBirth = value;
                }
            }
        }

        string Phone
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
