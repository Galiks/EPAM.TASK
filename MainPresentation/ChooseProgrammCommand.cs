using ChoosePath;
using DAOCommands;
using System;
using WriteDataOfPerson;

namespace MainPresentation
{
    public class ChooseProgrammCommand
    {
        private Commands commands = new Commands();
        ChoosePathForFile userPath = new ChoosePathForFile();
        private WritePerson wp = new WritePerson();

        private string pathToFile;

        public ChooseProgrammCommand()
        {
            ChooseCommand();
        }

        /// <summary>
        /// Method <seealso cref="ChooseCommand"/> is used to choose command/method.
        /// </summary>
        public void ChooseCommand()
        {
            if(String.IsNullOrEmpty(pathToFile))
            {
                pathToFile = userPath.ChoosePath();
            }

            Console.WriteLine($"{Environment.NewLine}Hello, user. What do you want?{Environment.NewLine}1 - Write to file{Environment.NewLine}2 - Read from file{Environment.NewLine}3 - Delete information{Environment.NewLine}4 - Help{Environment.NewLine}5 - Exit{Environment.NewLine}");

            try
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case (ConsoleKey.D1):
                        commands.WriteInfo(pathToFile, wp.Information());
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D2):
                        commands.ReadInfo(pathToFile);
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D3):
                        commands.DeleteInfo(pathToFile);
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D4):
                        Console.WriteLine($"1 - You can add information in file{Environment.NewLine}2 - You can read information from file{Environment.NewLine}3 - You can delete information from file{Environment.NewLine}4 - Information about command{Environment.NewLine}5 - Close programm{Environment.NewLine}");
                        ChooseCommand();
                        break;
                    case (ConsoleKey.D5):
                        Exit();
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

        private void Exit()
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
                        Exit();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oppps. Throw Exception - {e.Message}{Environment.NewLine}Try again.");
                Exit();
            }
        }
    }
}
