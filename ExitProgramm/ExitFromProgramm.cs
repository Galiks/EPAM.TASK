using MainPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExitProgramm
{
    public class ExitFromProgramm
    {
        ChooseProgrammCommand commands = new ChooseProgrammCommand();
        
        public void Exit()
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
                        commands.ChooseCommand();
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
