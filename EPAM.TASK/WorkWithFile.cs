using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    /// <summary>
    /// Class WorkWithFile
    /// works with file.
    /// He has methods for add and delete informations:
    /// <seealso cref="WriteInfo"/> and <seealso cref="DeleteInfo"/>
    /// Also class has method for read information from file:
    /// <seealso cref="ReadInfo"/>
    /// </summary>
    class WorkWithFile
    {
        /// <summary>
        /// For path use <seealso cref="PathToFile"/>
        /// Constructor calls method <seealso cref="StartProgramm"/>,
        /// which calls two methods:
        /// <seealso cref="CreateFile"/> - creates file
        /// and
        /// <seealso cref="ChooseCommand"/> - method for choose command  
        /// </summary>
        private const string PathToFile = "text.txt";

        public WorkWithFile()
        {
           StartProgramm();
        }

        public void StartProgramm()
        {
            CreateFile();
            ChooseCommand();
        }

        /// <summary>
        /// Method <seealso cref="CreateFile"/> is used to create file.
        /// </summary>
        private void CreateFile()
        {
            FileStream fs = new FileStream(PathToFile, FileMode.OpenOrCreate);
            fs.Close();
        }

        /// <summary>
        /// Method <seealso cref="ChooseCommand"/> is used to choose command/method.
        /// </summary>
        private void ChooseCommand()
        { 
            RemoveEmptySpaceFromFile();

            Console.WriteLine($"{Environment.NewLine}Hello, user. What do you want?{Environment.NewLine}1 - Write to file{Environment.NewLine}2 - Read from file{Environment.NewLine}3 - Delete information{Environment.NewLine}4 - Help{Environment.NewLine}5 - Exit{Environment.NewLine}");

            try
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case (ConsoleKey.D1):
                        WriteInfo();
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D2):
                        ReadInfo();
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D3):
                        DeleteInfo();
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D4):
                        Console.WriteLine($"1 - You can add information in file{Environment.NewLine}2 - You can read information from file{Environment.NewLine}3 - You can delete information from file{Environment.NewLine}4 - Information about command{Environment.NewLine}5 - Close programm{Environment.NewLine}");
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D5):
                        ExitFromProgramm();
                        break;
                    default:
                        Console.WriteLine($"I don't know this command. Try again.");
                        ChooseCommand();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oppps. Throw Exception - {e.Message}{Environment.NewLine}Try again.");
                ChooseCommand();
            }
        }

        /// <summary>
        /// Method <seealso cref="WriteInfo"/> write information to the file.
        /// User must write information in console:
        /// First Name, Last Name, Year of Birth and Phonenumber.
        /// Also the random created ID is written to the file.
        /// </summary>
        private void WriteInfo()
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
            Person p = new Person(i, firstName, lastName, yearOfBirth, phone);
            File.AppendAllText(PathToFile,p.ToString());            
        }

        /// <summary>
        /// Method <seealso cref="ReadInfo"/> read information from file
        /// and write her on the console
        /// </summary>
        private void ReadInfo()
        {
            using (StreamReader file = new StreamReader(PathToFile))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }

        /// <summary>
        /// Method <seealso cref="DeleteInfo"/> delete information from file
        /// if the entered string was found.
        /// For simplicity, the method has been split into several smaller methods like
        /// <seealso cref="DeleteHelper(string)"/> and <seealso cref="FindInfo(string, List{string})"/>
        /// </summary>
        private void DeleteInfo()
        {
            Console.WriteLine($"Find information, which you want delete{Environment.NewLine}You can write First Name or Last Name or Year of birth or Phonenumber{Environment.NewLine}");

            string info = Console.ReadLine();
            
            DeleteHelper(info);
        }

        /// <summary>
        /// Method <seealso cref="DeleteHelper(string)"/> takes a string parameter.
        /// Variable "str" that takes from method <seealso cref="FindInfo(string, List{string})"/>.
        /// This variable is used to delete information.
        /// At the end method <seealso cref="RemoveEmptySpaceFromFile"/> delete empty lines in file.
        /// </summary>
        /// <param name="finderWord"></param>
        private void DeleteHelper(string finderWord)
        {
            try
            {
                List<string> lines = new List<string>();

                using (StreamReader read = new StreamReader(PathToFile))
                {
                    string line;
                    while ((line = read.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                //str - позиция удаления
                int str = FindInfo(finderWord, lines);

                using (StreamWriter write = new StreamWriter(PathToFile))
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (i != str)
                        {
                            write.WriteLine(lines[i]);
                        }
                    }
                }
                RemoveEmptySpaceFromFile();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oppps. Throw Exception - {e.Message}{Environment.NewLine}Try again.");
            }
        }

        /// <summary>
        /// Method <seealso cref="FindInfo(string, List{string})"/> finds line and return number of line.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        private int FindInfo(string value, List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                foreach (var item in lines[i].Split(new[] { ':', ' ' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (item == value)
                    {
                        return i;
                    }
                }
            }
            ChooseCommand();
            return 0;
        }

        /// <summary>
        /// Method <seealso cref="ExitFromProgramm"/> is used to exit from programm
        /// </summary>
        private void ExitFromProgramm()
        {
            Console.WriteLine($"Are you sure you want to exit? (Y/N)");

            try
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case (ConsoleKey.Y):
                        Console.WriteLine($"Bye");
                        Environment.Exit(0);
                        break;
                    case (ConsoleKey.N):
                        Console.WriteLine("I know it");
                        ChooseCommand();
                        break;
                    default:
                        Console.WriteLine($"I don't know this command. Try again.");
                        ExitFromProgramm();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oppps. Throw Exception - {e.Message}{Environment.NewLine}Try again.");
                ExitFromProgramm();
            }
        }

        /// <summary>
        /// Method <seealso cref="RemoveEmptySpaceFromFile"/> is used to delete empty lines in file.
        /// </summary>
        private void RemoveEmptySpaceFromFile()
        {
            var lines = File.ReadAllLines(PathToFile).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(PathToFile, lines);
        }
    }
}