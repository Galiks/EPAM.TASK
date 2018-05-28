using Entity.Person;
using System;

namespace WriteDataOfPerson
{
    public class WritePerson
    {
        public Person Information()
        {
            Console.WriteLine($"Enter data");
            Console.Write($"First Name : ");
            string firstName = Console.ReadLine();
            Console.Write($"Last Name : ");
            string lastName = Console.ReadLine();
            Console.Write($"Year of birth : ");
            int yearOfBirth = int.Parse(Console.ReadLine());
            Console.Write($"Phonenumber : ");
            string phone = Console.ReadLine();

            Random ramdom = new Random();
            int i = ramdom.Next();
            Person person = new Person(i, firstName, lastName, yearOfBirth, phone);

            return person;
        }
    }
}
