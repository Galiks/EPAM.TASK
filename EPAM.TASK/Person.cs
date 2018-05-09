using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    class Person
    {
        public Person()
        {

        }

        public Person(int id, string firstName, string lastName, int age, string phone)
        {
            ID = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Phone = phone;
        }


        int ID { get; set; }
        string LastName { get; set; }
        string FirstName { get; set; }
        int Age { get; set; }
        string Phone { get; set; }

        public override string ToString()
        {
            return $"{ID} : {LastName} : {FirstName} : {Age} : {Phone}";
        }
    }
}
