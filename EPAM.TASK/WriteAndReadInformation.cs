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
        private string PathToFile = "text.txt";

        public WriteAndReadInformation()
        {

        }

        public void StartProgramm()
        {
            CreateFile();
            ChooseCommand();
        }

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
                        break;
                    case (ConsoleKey.D2):
                        ReadInfo();
                        break;
                    case (ConsoleKey.D3):
                        DeleteInfo();
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

            ChooseCommand();
        }

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
            ChooseCommand();
        }

        private void DeleteInfo()
        {
            Console.WriteLine($"Find information, which you want delete{Environment.NewLine}You can write First Name or Last Name or Year of birth or Phonenumber{Environment.NewLine}");

            string info = Console.ReadLine();
            
            DeleteHelper(info);
            
            ChooseCommand();
        }

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

        private void RemoveEmptySpaceFromFile()
        {
            var lines = File.ReadAllLines(PathToFile).Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(PathToFile, lines);
        }

        private void CreateFile()
        {
            FileStream fs = new FileStream(PathToFile, FileMode.OpenOrCreate);
            fs.Close();
        }
    }
}