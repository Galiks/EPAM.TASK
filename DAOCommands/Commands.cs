using BUS_Logic;
using DAOInterface;
using Entity.Person;
using System;
using System.IO;

namespace DAOCommands
{
    public class Commands : INote
    {
        Logic logic = new Logic();

        /// <summary>
        /// Method <seealso cref="DeleteInfo"/> delete information from file
        /// if the entered string was found.
        /// For simplicity, the method has been split into several smaller methods like
        /// <seealso cref="DeleteHelper(string)"/> and <seealso cref="FindInfo(string, List{string})"/>
        /// </summary>
        public void DeleteInfo(string pathToFile)
        {
            Console.WriteLine($"Find information, which you want delete{Environment.NewLine}You can write First Name or Last Name or Year of birth or Phonenumber{Environment.NewLine}");

            string info = Console.ReadLine();

            logic.DeleteHelper(pathToFile, info);
        }

        /// <summary>
        /// Method <seealso cref="ReadInfo"/> read information from file
        /// and write her on the console
        /// </summary>
        public void ReadInfo(string pathToFile)
        {
            using (StreamReader file = new StreamReader(pathToFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Method <seealso cref="WriteInfo"/> write information to the file.
        /// User must write information in console:
        /// First Name, Last Name, Year of Birth and Phonenumber.
        /// Also the random created ID is written to the file.
        /// </summary>
        public void WriteInfo(string pathToFile, Person person)
        {
            File.AppendAllText(pathToFile, person.ToString());
        }
    }
}
