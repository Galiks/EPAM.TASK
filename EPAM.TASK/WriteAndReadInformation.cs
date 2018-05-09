using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.TASK
{
    class WriteAndReadInformation
    {
        public WriteAndReadInformation()
        {

        }

        public void ChooseCommand()
        {
            Console.WriteLine($"Hello, user. What do you want?{Environment.NewLine}1 - Write to file{Environment.NewLine}2 - Read from file{Environment.NewLine}3 - Help{Environment.NewLine}4 - Exit{Environment.NewLine}");

            try
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case (ConsoleKey.D1):
                        WriteInfo();
                        break;
                    case (ConsoleKey.D2):
                        ReadInfo();
                        break;
                    case (ConsoleKey.D3):
                        Console.WriteLine($"1 - You can add information in file{Environment.NewLine}2 - You can read information from file{Environment.NewLine}3 - Information about command{Environment.NewLine}4 - Close programm{Environment.NewLine}");
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D4):
                        ExitFromProgramm();
                        break;
                    default:
                        Console.WriteLine($"I don't know this command. Try again.");
                        ChooseCommand();
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"I don't know this command. Try again.");
                ChooseCommand();
            }
        }

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
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"I don't know this command. Try again.");
                ExitFromProgramm();
            }
        }

        private void WriteInfo()
        {
            Console.WriteLine($"Enter data");
            Console.Write($"First Name : ");
            string firstName = Console.ReadLine();
            Console.Write($"Last Name : ");
            string lastName = Console.ReadLine();
            Console.Write($"Age : ");
            int age = Int32.Parse(Console.ReadLine());
            Console.Write($"Phonenumber : ");
            string phone = Console.ReadLine();

          
            Random ramdom = new Random();
            int i = ramdom.Next();
            Person p = new Person(i, firstName, lastName, age, phone);
            File.AppendAllText("text.txt",p.ToString());            

            ChooseCommand();
        }

        private void ReadInfo()
        {
            using (StreamReader file = new StreamReader("text.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(line);
                }
            }
            ChooseCommand();
        }
    }
}
