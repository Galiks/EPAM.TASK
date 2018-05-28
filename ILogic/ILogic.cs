using System.Collections.Generic;

namespace BUS_ILogic
{
    public interface ILogic
    {
        void DeleteHelper(string pathToFile, string finderWord);
        int FindInfo(string value, List<string> lines);
        void RemoveEmptySpaceFromFile(string pathToFile);
    }
}
