using System;
using System.Collections.Generic;
using System.Linq;
using BUS_ILogic;
using System.IO;

namespace BUS_Logic
{
    public class Logic : ILogic
    {


        /// <summary>
        /// Method <seealso cref="DeleteHelper(string)"/> takes a string parameter.
        /// Variable "str" that takes from method <seealso cref="FindInfo(string, List{string})"/>.
        /// This variable is used to delete information.
        /// At the end method <seealso cref="RemoveEmptySpaceFromFile"/> delete empty lines in file.
        /// </summary>
        /// <param name="finderWord"></param>
        public void DeleteHelper(string pathToFile, string finderWord)
        {
            try
            {
                List<string> lines = new List<string>();

                using (StreamReader read = new StreamReader(pathToFile))
                {
                    string line;
                    while ((line = read.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
                int str = FindInfo(finderWord, lines);

                using (StreamWriter write = new StreamWriter(pathToFile))
                {
                    for (int i = 0; i < lines.Count; i++)
                    {
                        if (i != str)
                        {
                            write.WriteLine(lines[i]);
                        }
                    }
                }
                RemoveEmptySpaceFromFile(pathToFile);
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
        public int FindInfo(string value, List<string> lines)
        {
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
                //ChooseCommand();
                return 0;
            }
        }

        /// <summary>
        /// Method <seealso cref="RemoveEmptySpaceFromFile"/> is used to delete empty lines in file.
        /// </summary>
        public void RemoveEmptySpaceFromFile(string pathToFile)
        {
            var lines = File.ReadAllLines(pathToFile).Where(arg => !String.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(pathToFile, lines);
        }
    }
}
