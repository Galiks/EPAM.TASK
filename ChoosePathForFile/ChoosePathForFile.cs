using CreateUserFileForProgramm;
using Exceptions;
using System;
using System.IO;

namespace ChoosePath
{
    public class ChoosePathForFile
    {
        CreateUserFile file = new CreateUserFile();
        ExceptionClass exc = new ExceptionClass();
        public string ChoosePath()
        {
            Console.WriteLine($"If you want to choose path for file you can write path to file by pressing button 1.{Environment.NewLine}If you don't want this - press button 2");
            try
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Console.WriteLine($"Example: C:\\temp{Environment.NewLine}Write your path:");
                        string path = Console.ReadLine();

                        if(!exc.CheckPathToFile($"{path}\\text.txt"))
                        {
                            ChoosePath();
                        }

                        Directory.CreateDirectory(path);
                        file.CreateFile($"{path}\\text.txt");
                        //check path!!!!!!
                        return $"{path}\\text.txt";
                    case ConsoleKey.D2:
                        file.CreateFile($"text.txt");
                        return $"text.txt";
                    default:
                        Console.WriteLine($"I don't know this command. Try again.");
                        ChoosePath();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Oppps. Throw Exception - {e.Message}{Environment.NewLine}Try again.");
                ChoosePath();
            }
            return null;
        }
    }
}
